using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace gWeasleGUI
{
    public class GwTools
    {
        public class gwdevice
        {
            public string port = string.Empty;
            public string model;
            public string mcu;
            public double firmwareVersion = 0;
            public string serial;
            public string usbRate;
        }

        public class serialport
        {
            public string port;
            public string name;
            public string description;

            public override string ToString()
            {
                return $"{this.description} ({this.port} {this.name})";
            }
        }

        public double gwHostToolsVersion { get; private set; } = 0;
        public string gwHostToolsFullVersion { get; private set; } = string.Empty;
        public gwdevice currentDevice { get; private set; }
        public string gw_exe { get; private set; } = "gw";
        public string GwToolsPath { get; private set; }
        public string LastGetFormatsAction { get; private set; } = string.Empty;
        public string LastGetHelpAction { get; private set; } = string.Empty;

        public Dictionary<string, GW_PnPEntity> SerialPorts { get; private set; }

        private ILogger logger;
        private char separator = Path.DirectorySeparatorChar;
        private static Action<string> gw_output;
        private Action StartAction, DoneAction, DeviceLoaded;
        private string LastExecutedCommand = string.Empty;
        private Dictionary<string, string> gw_helpCache = new Dictionary<string, string>();
        private static Dictionary<string, StringBuilder> processMsg = new Dictionary<string, StringBuilder>();

        // if not provided by GW, hardcode values accepted by gw v1.12
        private string[] extensions = new[]
        {
        "A2R|*.a2r", "ADF|*.adf", "ADS|*.ads", "ADM|*.adm", "ADL|*.adl", "D64|*.d64", "D88|*.d81", "D88|*.d88", "DCP|*.dcp", "DIM|*.dim",
        "DSD|*.dsd", "DSK|*.dsk", "FDI|*.fdi", "HDM|*.hdm", "HFE|*.hfe", "IMG|*.img;*.ima;*.st", "IMD|*.imd", "IPF|*.ipf", "MGT|*.mgt",
        "MSA|*.msa", "KryoFlux|*.raw", "SF7|*.sf7", "SCP|*.scp", "SSD|*.ssd", "XDF|*.xdf"
        };

    /// <summary>
    /// Initialize the GwTools class for interfacing with the commandline gw tools
    /// </summary>
    /// <param name="logger">logger to be used for operations</param>
    /// <param name="gwToolsPath">path to gw commandline tools</param>
    /// <param name="output">action event used to output to the current display</param>
    /// <param name="doneAction">action event to execute upon completion of commands</param>
    /// <param name="deviceLoaded">action event to execute after the device has loaded</param>
    public GwTools(ILogger logger, string gwHostToolsPath, string port, Action<string> output, Action doneAction, Action beginAction, Action deviceLoaded)
        {
            this.logger = logger;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                this.gw_exe = "gw.exe";
            }
            SerialPorts = GetPorts().ToDictionary(k => k.Caption, v => v, StringComparer.OrdinalIgnoreCase);

            gw_output = output;
            DoneAction = doneAction;
            StartAction = beginAction;
            DeviceLoaded = deviceLoaded;
            ReLoadGW(gwHostToolsPath, port);
        }

        /// <summary>
        /// Update the gw host tools path location and then load again
        /// </summary>
        /// <param name="gwHostToolsPath">gw host tools path</param>
        public void ReLoadGW(string gwHostToolsPath, string port = null)
        {
            this.GwToolsPath = gwHostToolsPath;
            LoadGW(port?.Trim());
        }

        /// <summary>
        /// GUI accesspoint for running gw action command
        /// </summary>
        /// <param name="cmd">gw command object with the details for the command</param>
        /// <param name="gwport">serial port to use</param>
        public void RunGWCommand(gwCommand cmd, string gwport)
        {
            string cmdArgs, cmdPort = gwport.Trim();

            if (cmdPort != this.currentDevice.port)
            {
                this.LoadGW(cmdPort, cmd);
                return;
            }

            cmdArgs = ArgsStandardTemplate(cmd);
            if (!string.IsNullOrEmpty(cmdArgs))
            {
                ExecuteGWCommand(cmdArgs);
            }
            else
            {
                //this.DoneAction();
            }
        }

        /// <summary>
        /// Load the gw
        /// - obtain device information and gw host tools version
        /// </summary>
        /// <param name="deviceport">optional comm port to check</param>
        /// <param name="AfterLoad">gw action command to be executed after loading is complete</param>
        public void LoadGW(string deviceport = null, gwCommand AfterLoad = null)
        {
            string args = "info";
            if (!string.IsNullOrEmpty(deviceport)) { args = $"{args} --device {deviceport}"; }

            ExecuteGWCommand(args, (response) =>
            {
                this.currentDevice = new gwdevice();
                this.gwHostToolsVersion = 0;
                StringReader input = new StringReader(response);
                string[] parameter;

                while (input.Peek() > -1)
                {
                    parameter = input.ReadLine().Trim().Split(':');
                    if (parameter.Length == 2 && !string.IsNullOrEmpty(parameter[1]))
                    {
                        switch (parameter[0].Trim())
                        {
                            case "Host Tools":
                                this.gwHostToolsFullVersion = parameter[1].Trim();
                                string NumberOnly = utilities.arraytodecimal(Regex.Match(this.gwHostToolsFullVersion, @"[0-9.]+").Value.Trim('.').Split('.'));
                                this.gwHostToolsVersion = double.Parse(NumberOnly);
                                break;
                            case "Port":
                                this.currentDevice.port = parameter[1].Trim();
                                break;
                            case "Model":
                                this.currentDevice.model = parameter[1].Trim();
                                break;
                            case "MCU":
                                this.currentDevice.mcu = parameter[1].Trim();
                                break;
                            case "Firmware":
                                this.currentDevice.firmwareVersion = double.Parse(parameter[1].Trim());
                                break;
                            case "Serial":
                                this.currentDevice.serial = parameter[1].Trim();
                                break;
                            case "USB Rate":
                            case "USB":
                                this.currentDevice.usbRate = parameter[1].Trim();
                                break;
                        }
                    }
                }
                this.gw_helpCache.Clear();

                // Events after initialize
                this.DeviceLoaded();
                if (AfterLoad != null && !string.IsNullOrEmpty(this.currentDevice.port))
                {
                    RunGWCommand(AfterLoad, this.currentDevice.port);
                }
            }, (ex) => { this.DeviceLoaded(); }, "Loading Greaseweasle Host Tools.");
        }

        /// <summary>
        /// Get the help for a specific action direct from gw
        /// </summary>
        /// <param name="gwaction">action to use for this help command</param>
        /// <param name="responseAction">callback action to handle async call results</param>
        public void GetActionHelp(string gwaction, Action<string> responseAction)
        {
            string args = $"{gwaction} --help";

            if (this.gw_helpCache.ContainsKey(gwaction))
            {
                this.LastGetHelpAction = gwaction;
                //this.DoneAction();
                responseAction(this.gw_helpCache[gwaction]);
            }
            else
            {
                ExecuteGWCommand(args, (response) =>
                {
                    gw_helpCache[gwaction] = response;
                    responseAction(response);
                    this.LastGetHelpAction = gwaction;
                }, null, $"Loading '{gwaction}' parameters.");
            }
        }

        /// <summary>
        /// Load the acceptable actions for gw
        /// - get the action values directly from gw
        /// </summary>
        /// <param name="LoadOperations">action to handle results after async call</param>
        public void GetOperations(Action<string[]> LoadOperations)
        {
            string args = "--help";

            ExecuteGWCommand(args, (response) =>
            {
                List<string> operations = new List<string>();
                List<string> items = utilities.ExtractGroup(new[] { @"Actions:" }, response);

                foreach (string item in items)
                {
                    operations.Add(item.Trim().Split(' ').FirstOrDefault());
                }
                this.logger.Info($"{operations.Count} actions loaded.");

                LoadOperations(operations.ToArray());
            }, null, "Loading available operations.");
        }

        public void LoadAcceptedSuffixes(string helpContent)
        {
            List<string> items = utilities.ExtractGroup(new[] { @"Supported file suffixes:" }, helpContent);
            List<string> suffixes = new List<string>();

            foreach (string item in items)
            {
                // Allow nwer columned output
                IEnumerable<string> parts = item.Trim().Split(' ').Where(i => !string.IsNullOrEmpty(i));
                if (parts.Count() > 0)
                {
                    suffixes.AddRange(parts);
                }
            }

            if (suffixes.Count > 0)
            {
                List<string> ext = new List<string>();
                foreach (string item in suffixes)
                {
                    ext.Add($"{item.Trim('.').ToUpper()}|*{item.ToLower()}");
                }
                this.extensions = ext.ToArray();
            }
        }

        /// <summary>
        /// Load the acceptable file suffixes/extensions
        /// </summary>
        /// <returns>Extensions from last GW output</returns>
        public string[] GetAcceptedSuffixes()
        {
            return this.extensions;
        }

        /// <summary>
        /// Load format types direct from gw
        /// </summary>
        /// <param name="gwaction">action to use for this help command</param>
        /// <param name="LoadTypes">callback action to handle async call results</param>
        public void GetFormatTypes(string gwaction, Action<string[]> LoadTypes)
        {
            string args = $"{gwaction} --help";
            // Action to handle response
            Action<string> processResponse = (response) =>
            {
                List<string> types = new List<string>();
                List<string> items = utilities.ExtractGroup(new[] { @"FORMAT options:" }, response);

                foreach (string item in items)
                {
                    // Allow nwer columned output
                    IEnumerable<string> parts = item.Trim().Split(' ').Where(i => !string.IsNullOrEmpty(i));
                    if (parts.Count() > 0)
                    {
                        types.AddRange(parts);
                    }
                }
                //this.logger.Info($"{types.Count} formats loaded.");

                if (!gw_helpCache.ContainsKey(gwaction))
                    gw_helpCache[gwaction] = response;

                LoadTypes(types.ToArray());
                this.LastGetFormatsAction = gwaction;
            };

            if (gw_helpCache.ContainsKey(gwaction))
            {
                processResponse(gw_helpCache[gwaction]);
            }
            else
            {
                ExecuteGWCommand(args, processResponse, null, "Loading File Formats.");
                this.LastGetHelpAction = gwaction;
            }
        }

        /// <summary>
        /// Format command from gwCommand class into a command line version
        /// </summary>
        /// <param name="cmd">command class for this</param>
        /// <returns>commandline version of the gw command</returns>
        private string ArgsStandardTemplate(gwCommand cmd)
        {
            string cmdArgs = string.Empty;
            string cmdtime = cmd.time ? "--time " : string.Empty;
            string extraArgs = string.Join(" ", cmd.args.Select(a => a.ToString()).ToArray()).Trim();

            // Arg templates
            switch (cmd.action)
            {
                case "info":
                case "read":
                case "write":
                case "conver":
                case "erase":
                case "clean":
                case "seek":
                case "delays":
                case "reset":
                case "update":
                case "bandwidth":
                case "rpm":
                    cmdArgs = $"{cmdtime}{cmd.action} --device {this.currentDevice.port} {extraArgs}".Trim();
                    break;
                // No device for actions: convert, pin
                case "convert":
                case "pin":
                    cmdArgs = $"{cmdtime}{cmd.action} {extraArgs}".Trim();
                    break;
                default:
                    // Always allow help
                    if (extraArgs.IndexOf("--help") > -1)
                    {
                        cmdArgs = $"{cmdtime}{cmd.action} {extraArgs}".Trim();
                    }
                    else
                    {
                        cmdArgs = string.Empty;
                        this.logger.Info($"Unsupported template request for action: {cmd.action}");
                    }
                    break;
            }
            return cmdArgs;
        }

        /// <summary>
        /// Wrapper object for executing gw commandline tools
        /// </summary>
        /// <param name="args">gw arguments as would be accepted on an actual commandline</param>
        /// <param name="processResponse">optional event handler to handle response data after completion, when not provided all data goes to the standard async handler</param>
        private void ExecuteGWCommand(string args, Action<string> processResponse = null, Action<Exception> errorResponse = null, string CmdMsg = "")
        {
            string cmd = $"\"{this.GwToolsPath}{this.separator}{this.gw_exe}\""; // "powershell";
            if (string.IsNullOrEmpty(this.GwToolsPath))
                cmd = this.gw_exe;

            //args = $".{this.separator}{this.gw_exe} {args}";
            ExecuteCommand(cmd, args, processResponse, errorResponse, CmdMsg);
        }

        /// <summary>
        /// Raw command execution method
        /// </summary>
        /// <param name="exe">executable</param>
        /// <param name="args">arguments</param>
        /// <param name="processResponse">optional event handler to handle response data after completion, when not provided all data goes to the standard async handler</param>
        private void ExecuteCommand(
            string exe,
            string args,
            Action<string> processResponse = null,
            Action<Exception> errorResponse = null,
            string CmdMsg = "")
        {
            string rt = string.Empty, err = string.Empty;
            Task exe_task;

            this.LastExecutedCommand = $"{utilities.MaxSizeFileName(exe)} {args}";
            string startOut = string.IsNullOrEmpty(CmdMsg) ? $"Executing command: {this.LastExecutedCommand}" : CmdMsg;
            //gw_output(startOut);
            this.logger.Info(startOut);

            // Start the command on it's own thread.
            exe_task = Task.Factory.StartNew(
                () =>
                {
                    try
                    {
                        StartAction();
                        ProcessStartInfo procStartInfo = new ProcessStartInfo()
                        {
                            UseShellExecute = false,
                            CreateNoWindow = true,
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            WorkingDirectory = this.GwToolsPath,
                            FileName = exe,
                            Arguments = args
                        };

                        if (procStartInfo.Environment["PATH"].IndexOf(this.GwToolsPath) == -1)
                        {
                            //procStartInfo.Environment["PATH"] = procStartInfo.Environment["PATH"] + $";{this.GwToolsPath}";
                        }

                        Process p = new Process();
                        p.StartInfo = procStartInfo;
                        p.EnableRaisingEvents = true;
                        p.Exited += (s, e) =>
                        {
                            p.WaitForExit();
                            if (processResponse != null)
                            {
                                if (processMsg.ContainsKey(p.Id.ToString()))
                                {
                                    rt = processMsg[p.Id.ToString()].ToString();
                                    processMsg.Remove(p.Id.ToString());
                                }
                                else
                                {
                                    //p.WaitForExit();
                                    rt = p.StandardOutput.ReadToEnd();

                                    // Bug fix for when output shows in standard error
                                    err = p.StandardError.ReadToEnd();
                                    if (string.IsNullOrEmpty(rt)) { rt = err; }
                                }

                                processResponse(rt);
                            }

                            if (string.IsNullOrEmpty(CmdMsg))
                            {
                                string endOut = $"Command completed: {utilities.MaxSizeFileName(p.StartInfo.FileName)} {p.StartInfo.Arguments}";
                                //gw_output(endOut);
                                this.logger.Info(endOut);
                            }
                            this.DoneAction();
                        };

                        //if (processResponse is null || args.StartsWith("read"))
                        //{
                        
                        if (string.IsNullOrEmpty(CmdMsg))
                            p.ErrorDataReceived += OutputHandler;
                        else
                            p.ErrorDataReceived += QuietOutputHandler;

                            //p.OutputDataReceived += OutputHandler;
                        //}

                        // Execute the command
                        p.Start();

                        //if (processResponse is null || args.StartsWith("read") )
                        //{
                            processMsg[p.Id.ToString()] = new StringBuilder();
                            p.BeginErrorReadLine();
                            p.BeginOutputReadLine();
                        //}
                    }
                    catch (Exception ex)
                    {
                        this.logger.Error($"Error occured while executing the command {args}", ex);
                        //gw_output($"Error occured while executing the command {args}{Environment.NewLine}Exception: {ex}");
                        if (errorResponse != null) { errorResponse(ex); }
                        this.DoneAction();
                    }
                });
        }

        /// <summary>
        /// Quiet Event handler to handle ouput
        /// </summary>
        /// <param name="sendingProcess">ignored</param>
        /// <param name="outLine">handler data</param>
        private static void QuietOutputHandler(object sendingProcess,
            DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                if (!processMsg.ContainsKey(((Process)sendingProcess).Id.ToString()))
                    processMsg[((Process)sendingProcess).Id.ToString()] = new StringBuilder();

                processMsg[((Process)sendingProcess).Id.ToString()].AppendLine(outLine.Data);
            }
        }

        /// <summary>
        /// Event handler to handle ouput
        /// </summary>
        /// <param name="sendingProcess">ignored</param>
        /// <param name="outLine">handler data</param>
        private static void OutputHandler(object sendingProcess,
            DataReceivedEventArgs outLine)
        {
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                if (!processMsg.ContainsKey(((Process)sendingProcess).Id.ToString()))
                    processMsg[((Process)sendingProcess).Id.ToString()] = new StringBuilder();

                processMsg[((Process)sendingProcess).Id.ToString()].AppendLine(outLine.Data);

                gw_output(outLine.Data);
            }
        }

        public static List<GW_PnPEntity> GetPorts()
        {
            List<GW_PnPEntity> devices = new List<GW_PnPEntity>();
            GW_PnPEntity gW_PnPEntity = null;

            try // port data is information purposes and should not crash.
            {
                ManagementObjectSearcher queryResult = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_PnPEntity WHERE PNPClass = 'Ports'");
                uint portIndex = 0;
                foreach (ManagementObject foundObj in queryResult.Get())
                {
                    if (foundObj != null)
                    {
                        gW_PnPEntity = new GW_PnPEntity();

                        try
                        {
                            gW_PnPEntity.Availability = utilities.SafeChangeType<uint>(foundObj["Availability"], 0);
                            gW_PnPEntity.Caption = (string)foundObj["Caption"];
                            gW_PnPEntity.ClassGuid = (string)foundObj["ClassGuid"];
                            gW_PnPEntity.CompatibleID = (string[])foundObj["CompatibleID"];
                            gW_PnPEntity.ConfigManagerErrorCode = (uint)foundObj["ConfigManagerErrorCode"];
                            gW_PnPEntity.ConfigManagerUserConfig = (bool)foundObj["ConfigManagerUserConfig"];
                            gW_PnPEntity.CreationClassName = (string)foundObj["CreationClassName"];
                            gW_PnPEntity.Description = (string)foundObj["Description"];
                            gW_PnPEntity.DeviceID = (string)foundObj["DeviceID"];
                            gW_PnPEntity.ErrorCleared = utilities.SafeChangeType<bool>(foundObj["ErrorCleared"], true);
                            gW_PnPEntity.ErrorDescription = (string)foundObj["ErrorDescription"];
                            gW_PnPEntity.HardwareID = (string[])foundObj["HardwareID"];
                            gW_PnPEntity.InstallDate = utilities.SafeChangeType<DateTime>(foundObj["InstallDate"]?.ToString(), DateTime.Now).ToString();
                            gW_PnPEntity.LastErrorCode = utilities.SafeChangeType<uint>(foundObj["LastErrorCode"], 0);
                            gW_PnPEntity.Manufacturer = (string)foundObj["Manufacturer"];
                            gW_PnPEntity.Name = (string)foundObj["Name"];
                            gW_PnPEntity.UseValue = $"COM{gW_PnPEntity.Name.Substring(gW_PnPEntity.Name.IndexOf("COM") + 3).Trim(')')}";
                            gW_PnPEntity.PNPClass = (string)foundObj["PNPClass"];
                            gW_PnPEntity.PNPDeviceID = (string)foundObj["PNPDeviceID"];
                            gW_PnPEntity.PowerManagementCapabilities = (uint[])foundObj["PowerManagementCapabilities"];
                            gW_PnPEntity.PowerManagementSupported = utilities.SafeChangeType<bool>(foundObj["PowerManagementSupported"], false);
                            gW_PnPEntity.Present = utilities.SafeChangeType<bool>(foundObj["Present"], false);
                            gW_PnPEntity.Service = (string)foundObj["Service"];
                            gW_PnPEntity.Status = (string)foundObj["Status"];
                            gW_PnPEntity.StatusInfo = utilities.SafeChangeType<uint>(foundObj["StatusInfo"], 0);
                            gW_PnPEntity.SystemCreationClassName = (string)foundObj["SystemCreationClassName"];
                            gW_PnPEntity.SystemName = (string)foundObj["SystemName"];
                            gW_PnPEntity.Bus_Description = Win32Device.GetDeviceBusDescription(new Guid(gW_PnPEntity.ClassGuid), portIndex);
                            portIndex++;
                        }
                        catch
                        {
                            // for now just skip it.
                        }

                        devices.Add(gW_PnPEntity);
                    }
                }
            } catch { }

            return devices;
        }

        public class GW_PnPEntity
        {
            public uint Availability;
            public string Caption;
            public string UseValue;
            public string ClassGuid;
            public string[] CompatibleID;
            public uint ConfigManagerErrorCode;
            public bool ConfigManagerUserConfig;
            public string CreationClassName;
            public string Description;
            public string Bus_Description;
            public string DeviceID;
            public bool ErrorCleared;
            public string ErrorDescription;
            public string[] HardwareID;
            public string InstallDate;
            public uint LastErrorCode;
            public string Manufacturer;
            public string Name;
            public string PNPClass;
            public string PNPDeviceID;
            public uint[] PowerManagementCapabilities;
            public bool PowerManagementSupported;
            public bool Present;
            public string Service;
            public string Status;
            public uint StatusInfo;
            public string SystemCreationClassName;
            public string SystemName;
        };

        public class Win32Device
        {
            [Flags]
            public enum DiGetClassFlags : uint
            {
                DIGCF_DEFAULT = 0x00000001,  // only valid with DIGCF_DEVICEINTERFACE
                DIGCF_PRESENT = 0x00000002,
                DIGCF_ALLCLASSES = 0x00000004,
                DIGCF_PROFILE = 0x00000008,
                DIGCF_DEVICEINTERFACE = 0x00000010,
            }

            /// <summary>
            /// The SP_DEVINFO_DATA structure defines a device instance that is a member of a device information set.
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            private struct SP_DEVINFO_DATA
            {
                public UInt32 cbSize;
                public Guid ClassGuid;
                public UInt32 DevInst;
                public UIntPtr Reserved;
            };

            [StructLayout(LayoutKind.Sequential)]
            struct DEVPROPKEY
            {
                public Guid fmtid;
                public UInt32 pid;
            }

            [DllImport("setupapi.dll")]
            private static extern Int32 SetupDiDestroyDeviceInfoList(IntPtr DeviceInfoSet);

            [DllImport("setupapi.dll", SetLastError = true)]
            private static extern bool SetupDiEnumDeviceInfo(IntPtr DeviceInfoSet, UInt32 MemberIndex, ref SP_DEVINFO_DATA DeviceInterfaceData);

            [DllImport("setupapi.dll", SetLastError = true)]
            private static extern IntPtr SetupDiGetClassDevs(ref Guid gClass, UInt32 iEnumerator, UInt32 hParent, DiGetClassFlags nFlags);

            //[DllImport("kernel32.dll")]
            //private static extern Int32 GetLastError();

            const int BUFFER_SIZE = 1024;

            [DllImport("setupapi.dll", SetLastError = true)]
            static extern bool SetupDiGetDevicePropertyW(
                IntPtr deviceInfoSet,
                [In] ref SP_DEVINFO_DATA DeviceInfoData,
                [In] ref DEVPROPKEY propertyKey,
                [Out] out UInt32 propertyType,
                byte[] propertyBuffer,
                UInt32 propertyBufferSize,
                out UInt32 requiredSize,
                UInt32 flags);

            const int utf16terminatorSize_bytes = 2;

            static Win32Device()
            {

            }

            public static string GetDeviceBusDescription(Guid deviceId, uint index)
            {
                byte[] ptrBuf = new byte[BUFFER_SIZE];
                uint propRegDataType;
                uint RequiredSize;

                DEVPROPKEY DEVPKEY_Device_BusReportedDeviceDesc = new DEVPROPKEY()
                {
                    fmtid = new Guid("540b947e-8b40-45bc-a8a2-6a0b894cbda2"),
                    pid = 4
                };

                IntPtr hDeviceInfoSet = SetupDiGetClassDevs(ref deviceId, 0, 0, DiGetClassFlags.DIGCF_PRESENT);
                if (hDeviceInfoSet == IntPtr.Zero)
                {
                    //throw new Exception("Failed to get device information set for the COM ports");
                    return string.Empty;
                }

                SP_DEVINFO_DATA deviceInfoData = new SP_DEVINFO_DATA();
                deviceInfoData.cbSize = (uint)Marshal.SizeOf(typeof(SP_DEVINFO_DATA));
                bool success = SetupDiEnumDeviceInfo(hDeviceInfoSet, index, ref deviceInfoData);
                if (!success)
                {
                    return string.Empty;
                }

                success = SetupDiGetDevicePropertyW(hDeviceInfoSet, ref deviceInfoData, ref DEVPKEY_Device_BusReportedDeviceDesc,
                    out propRegDataType, ptrBuf, BUFFER_SIZE, out RequiredSize, 0);
                if (!success)
                {
                    //throw new Exception("Can not read Bus provided device description device " + deviceInfoData.ClassGuid);
                    return string.Empty;
                }
                SetupDiDestroyDeviceInfoList(hDeviceInfoSet);

                return System.Text.UnicodeEncoding.Unicode.GetString(ptrBuf, 0, (int)RequiredSize - utf16terminatorSize_bytes);
            }
        }
    }
}

