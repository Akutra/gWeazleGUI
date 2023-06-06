using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using static gWeasleGUI.GwTools;

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

        public class gwCommand
        {
            public string action;
            public bool time = true;
            public string[] args = new string[0];
        }

        public double gwHostToolsVersion { get; private set; } = 0;
        public gwdevice currentDevice { get; private set; }
        public string gw_exe { get; private set; } = "gw";
        public string GwToolsPath { get; private set; }
        public string LastGetFormatsAction { get; private set; } = string.Empty;
        public string LastGetHelpAction { get; private set; } = string.Empty;

        private ILogger logger;
        private char separator = Path.DirectorySeparatorChar;
        private static Action<string> gw_output;
        private Action StartAction, DoneAction, DeviceLoaded;
        private string LastExecutedCommand = string.Empty;
        private Dictionary<string, string> gw_helpCache = new Dictionary<string, string>();

        /// <summary>
        /// Initialize the GwTools class for interfacing with the commandline gw tools
        /// </summary>
        /// <param name="logger">logger to be used for operations</param>
        /// <param name="gwToolsPath">path to gw commandline tools</param>
        /// <param name="output">action event used to output to the current display</param>
        /// <param name="doneAction">action event to execute upon completion of commands</param>
        /// <param name="deviceLoaded">action event to execute after the device has loaded</param>
        public GwTools(ILogger logger, string gwHostToolsPath, Action<string> output, Action doneAction, Action beginAction, Action deviceLoaded)
        {
            this.logger = logger;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                this.gw_exe = "gw.exe";
            }

            gw_output = output;
            DoneAction = doneAction;
            StartAction = beginAction;
            DeviceLoaded = deviceLoaded;
            ReLoadGW(gwHostToolsPath);
        }

        /// <summary>
        /// Update the gw host tools path location and then load again
        /// </summary>
        /// <param name="gwHostToolsPath">gw host tools path</param>
        public void ReLoadGW(string gwHostToolsPath)
        {
            this.GwToolsPath = gwHostToolsPath;
            LoadGW();
        }

        /// <summary>
        /// GUI accesspoint for running gw action command
        /// </summary>
        /// <param name="cmd">gw command object with the details for the command</param>
        /// <param name="gwport">serial port to use</param>
        public void RunGWCommand(gwCommand cmd, string gwport)
        {
            string cmdArgs, cmdPort = gwport.Trim();

            if(cmdPort != this.currentDevice.port)
            {
                this.LoadGW(cmdPort, cmd);
                return;
            }

            cmdArgs = ArgsStandardTemplate(cmd);
            if (!string.IsNullOrEmpty(cmdArgs))
            {
                ExecuteGWCommand(cmdArgs);
            } else
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
            if( !string.IsNullOrEmpty(deviceport) ) { args = $"{args} --device {deviceport}"; }

            ExecuteGWCommand(args, (response) =>
            {
                this.currentDevice = new gwdevice();
                this.gwHostToolsVersion = 0;
                StringReader input = new StringReader(response);
                string[] parameter;

                while (input.Peek()>-1)
                {
                    parameter = input.ReadLine().Trim().Split(':');
                    if (parameter.Length == 2 && !string.IsNullOrEmpty(parameter[1]))
                    {
                        switch (parameter[0].Trim())
                        {
                            case "Host Tools":
                                this.gwHostToolsVersion = double.Parse(parameter[1].Trim());
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
                                this.currentDevice.usbRate = parameter[1].Trim();
                                break;
                        }
                    }
                }
                this.gw_helpCache.Clear();

                // Events after initialize
                this.DeviceLoaded();
                if(AfterLoad != null && !string.IsNullOrEmpty(this.currentDevice.port))
                {
                    RunGWCommand(AfterLoad, this.currentDevice.port);
                }
            }, (ex) => { this.DeviceLoaded(); });
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
                });
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
                List<string> items = utilities.ExtractGroup(@"Actions:", response);

                foreach (string item in items)
                {
                    operations.Add(item.Trim().Split(' ').FirstOrDefault());
                }
                this.logger.Info($"{operations.Count} actions loaded.");

                LoadOperations(operations.ToArray());
            });
        }

        /// <summary>
        /// Load the acceptable file suffixes/extensions
        /// TODO: get the suffix values directly from gw
        /// </summary>
        /// <param name="LoadAcceptedSuffixes">action to handle results</param>
        public void GetAcceptedSuffixes(Action<string[]> LoadAcceptedSuffixes)
        {
            // TODO: Until gw provides a way to get this data, hardcode values accepted by gw v1.13
            string[] ext = new[]
            {
                "A2R|*.a2r", "ADF|*.adf", "ADS|*.ads", "ADM|*.adm", "ADL|*.adl", "D64|*.d64", "D88|*.d81", "D88|*.d88", "DCP|*.dcp", "DIM|*.dim", 
                "DSD|*.dsd", "DSK|*.dsk", "FDI|*.fdi", "HDM|*.hdm", "HFE|*.hfe", "IMG|*.img;*.ima;*.st", "IMD|*.imd", "IPF|*.ipf", "MGT|*.mgt", 
                "MSA|*.msa", "KryoFlux|*.raw", "SF7|*.sf7", "SCP|*.scp", "SSD|*.ssd", "XDF|*.xdf"
            };
            LoadAcceptedSuffixes(ext);
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
                List<string> items = utilities.ExtractGroup(@"FORMAT options:", response);

                foreach (string item in items)
                {
                    // Allow nwer columned output
                    IEnumerable<string> parts = item.Trim().Split(' ').Where(i => !string.IsNullOrEmpty(i));
                    if (parts.Count() > 0)
                    {
                        types.AddRange(parts);
                    }
                }
                this.logger.Info($"{types.Count} formats loaded.");

                if (!gw_helpCache.ContainsKey(gwaction))
                    gw_helpCache[gwaction] = response;

                LoadTypes(types.ToArray());
                this.LastGetFormatsAction = gwaction;
            };

            if(gw_helpCache.ContainsKey(gwaction))
            {
                processResponse(gw_helpCache[gwaction]);
            } else
            {
                ExecuteGWCommand(args, processResponse);
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
            string extraArgs = string.Join(" ", cmd.args).Trim();

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
                    if (extraArgs.IndexOf("--help")>-1 )
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
        private void ExecuteGWCommand(string args, Action<string> processResponse = null, Action<Exception> errorResponse = null)
        {
            string cmd = $"\"{this.GwToolsPath}{this.separator}{this.gw_exe}\""; // "powershell";
            if (string.IsNullOrEmpty(this.GwToolsPath))
                cmd = this.gw_exe;

            //args = $".{this.separator}{this.gw_exe} {args}";
            ExecuteCommand(cmd, args, processResponse, errorResponse);
        }

        /// <summary>
        /// Raw command execution method
        /// </summary>
        /// <param name="exe">executable</param>
        /// <param name="args">arguments</param>
        /// <param name="processResponse">optional event handler to handle response data after completion, when not provided all data goes to the standard async handler</param>
        private void ExecuteCommand(string exe, string args, Action<string> processResponse = null, Action<Exception> errorResponse = null)
        {
            string rt = string.Empty, err = string.Empty;
            Task exe_task;
            this.LastExecutedCommand = $"{utilities.MaxSizeFileName(exe)} {args}";
            string startOut = $"Executing command: {this.LastExecutedCommand}";
            gw_output(startOut);
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
                            procStartInfo.Environment["PATH"] = procStartInfo.Environment["PATH"] + $";{this.GwToolsPath}";
                        }

                        Process p = new Process();
                        p.StartInfo = procStartInfo;
                        p.EnableRaisingEvents = true;
                        p.Exited += (s, e) =>
                        {
                            if (processResponse != null)
                            {
                                //p.WaitForExit();
                                rt = p.StandardOutput.ReadToEnd();

                                // Bug fix for when output shows in standard error
                                err = p.StandardError.ReadToEnd();
                                if (string.IsNullOrEmpty(rt)) { rt = err; }

                                processResponse(rt);
                            }

                            string endOut = $"Command completed: {utilities.MaxSizeFileName(p.StartInfo.FileName)} {p.StartInfo.Arguments}";
                            gw_output(endOut);
                            this.logger.Info(endOut);
                            this.DoneAction();
                        };

                        if (processResponse is null)
                        {
                            p.ErrorDataReceived += OutputHandler;
                            //p.OutputDataReceived += OutputHandler;
                        }

                        // Execute the command
                        p.Start();

                        if (processResponse is null)
                        {
                            p.BeginErrorReadLine();
                            p.BeginOutputReadLine();
                        }
                    }
                    catch (Exception ex)
                    {
                        this.logger.Error($"Error occured while executing the command {args}", ex);
                        gw_output($"Error occured while executing the command {args}{Environment.NewLine}Exception: {ex}");
                        if(errorResponse != null) { errorResponse(ex); }
                        this.DoneAction();
                    }
                });
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
                gw_output(outLine.Data);
            }
        }
    }
}
