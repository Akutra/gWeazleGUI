﻿using gWeasleGUI.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using static gWeasleGUI.GwTools;

namespace gWeasleGUI
{
    public partial class gWeazleFrm : Form
    {
        ILogger logger;
        ConfigLoader ConfigManager;
        GwTools gw;
        Action ActionComplete, ActionStart, ActionGwDeviceLoaded;
        Action<string> DisplayContentAction, PersistExtConfig;
        int ActionCount = 0;

        string GwNewFile = string.Empty, GwExistingFile = string.Empty, GwDiskDefsFile = string.Empty;

        public gWeazleFrm()
        {
            InitializeComponent();

            // populate product details
            int beta;
            ConfigLoader.Version = Application.ProductVersion;
            ConfigLoader.AppName = Application.ProductName;
            ConfigLoader.VersionDetails = int.TryParse(ConfigLoader.Version.Split('.').Last(), out beta) && beta > 0 ? $"beta {beta}" : "Release";

            // Common Actions
            ActionComplete = () => { this.EnableActionableGUI(); };
            ActionStart = () => { this.BusyActionableGUI(); };
            DisplayContentAction = (content) => { this.DisplayContent(content); };
            ActionGwDeviceLoaded = () => { this.GwDeviceLoaded(); };
        }

        private void gWeasleFrm_Load(object sender, EventArgs e)
        {
            this.ActionStart();

            // initialize the logger
            this.logger = new GuiLogger((msg) => {
                if (msg.Trim().Length > 0) { this.Invoke(new MethodInvoker(delegate { this.DisplayContent(msg); GwCurrentStatus.Text = msg; })); }
            });

            // load persistent config data
            this.ConfigManager = new ConfigLoader(logger, this.ActionStart, this.ActionComplete);
            this.Text = $"{ConfigLoader.AppName} {ConfigLoader.Version} ({ConfigLoader.VersionDetails})";

            // purge missing profiles from config before adding to the interface
            if(this.ConfigManager.ConfigData.profiles.HasChanged)
                this.ConfigManager.WriteConfig();

            this.CmdProfileCB.Items.AddRange(this.ConfigManager.ConfigData.profiles.Keys.ToArray());

            // initialize gw commandline tools
            this.gw = new GwTools(logger,ConfigManager.ConfigData.GwToolsPath, this.ConfigManager.ConfigData.gwport, this.DisplayContentAction, this.ActionComplete, this.ActionStart, this.ActionGwDeviceLoaded);
            portcaptionCB.Items.AddRange(this.gw.SerialPorts.Keys.ToArray());
            portcaptionCB.SelectedIndex = 0;

            // persist file extension to config file
            this.PersistExtConfig = (ext) =>
            {
                if (ConfigManager.ConfigData.LastFileExt != ext)
                {
                    ConfigManager.ConfigData.LastFileExt = ext;
                    ConfigManager.WriteConfig();
                }
            };

            this.InitializeArgumentFilters();
            this.InitializeDDParaHandling();
            this.PopulateConfig();
            this.ActionComplete();
        }

        /// <summary>
        /// Load gw actions into the interface
        /// </summary>
        private void LoadGWOperations()
        {
            //this.ActionStart();
            // Intialize available gw operations
            this.gw.GetOperations((ops) =>
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    actionCB.Items.Clear();
                    actionCB.Items.AddRange(ops);
                    if (actionCB.Items.Count > 0) { actionCB.SelectedIndex = 0; }
                    actionCB.Enabled = true;
                }));
            });
        }

        /// <summary>
        /// After gw load event fires when the device is loaded.
        /// - Validate selected gw and hardware
        /// </summary>
        private void GwDeviceLoaded()
        {
            if( this.gw is null) { this.DisplayContentAction($"Unable to load GreaseWeasle!"); this.DisableInterface(); return; }

            // Verify Host tools version compatibilty
            //if (this.gw.gwHostToolsVersion < 1.12)
            //{
            //    string err = this.gw.gwHostToolsVersion == 0 ? "Greaseweazle Host Tools not found." : $"Greaseweazle Host Tools v{this.gw.gwHostToolsVersion} found.";
            //    string msg = $"{err}{Environment.NewLine}*** Greaseweazle Host Tools version 1.12 or greater is required for {ConfigLoader.AppName}.";
            //    this.DisplayContentAction(msg);

            //    this.Invoke(new MethodInvoker(delegate
            //    {
            //        gwToolsVersion.Text = $"H{this.gw.gwHostToolsVersion}";
            //        this.DisableInterface();
            //        gwPathSelectionTB.Text = this.ConfigManager.ConfigData.GwToolsPath;
            //        gwpathcontainer.Visible = true;
            //    }));
            //    return;
            //}

            // verify device can be loaded
            if (this.gw.gwHostToolsVersion == 0 || this.gw.currentDevice is null || string.IsNullOrEmpty(this.gw.currentDevice.port))
            {
                string gwmsg = this.gw.gwHostToolsVersion == 0 ? "Greaseweazle Host Tools not found." : $"Greaseweazle Host Tools v{this.gw.gwHostToolsFullVersion} found.";
                string err = $"*** Unable to load device on port {this.gwPortTB.Text.Trim()}.";
                string msg = $"{gwmsg}{Environment.NewLine}{err}{Environment.NewLine}*** Greaseweazle device required for {ConfigLoader.AppName}.";
                this.DisplayContentAction(msg);
                // thread safe show options
                this.Invoke(new MethodInvoker(delegate {
                    gwModelValue.Text = "Not Found.";
                    gwMCUValue.Text = string.Empty;
                    gwFirmwareValue.Text = string.Empty;
                    gwSerialValue.Text = string.Empty;
                    gwUSBRateValue.Text = string.Empty;
                    
                    if(this.gw.gwHostToolsVersion>0)
                    {
                        logger.Info(err);
                        gwToolsVersion.Text = $"H{this.gw.gwHostToolsVersion}";
                        gwHostToolsVersionValue.Text = this.gw.gwHostToolsFullVersion;
                        GWTab.SelectedTab = this.deviceTab;
                    }
                    else
                    {
                        logger.Info(gwmsg);
                        gwToolsVersion.Text = "None";
                        GWTab.SelectedTab = this.optionsTab;
                    }
                }));
                return;
            }

            // thread safe populate valid data to the interface
            this.Invoke(new MethodInvoker(delegate
            {
                gwPathSelectionTB.Text = this.ConfigManager.ConfigData.GwToolsPath;
                gwToolsVersion.Text = $"H{this.gw.gwHostToolsVersion}";
                gwHostToolsVersionValue.Text = this.gw.gwHostToolsFullVersion;
                gwPortTB.Text = this.gw.currentDevice.port;
                gwModelValue.Text = this.gw.currentDevice.model;
                gwMCUValue.Text = this.gw.currentDevice.mcu;
                gwFirmwareValue.Text = this.gw.currentDevice.firmwareVersion.ToString();
                gwSerialValue.Text = this.gw.currentDevice.serial;
                gwUSBRateValue.Text = this.gw.currentDevice.usbRate;

                if( !string.IsNullOrEmpty(this.gw.currentDevice.port) &&
                    (this.ConfigManager.ConfigData.gwport is null ||
                    !this.ConfigManager.ConfigData.gwport.Equals(this.gw.currentDevice.port, StringComparison.OrdinalIgnoreCase) ) )
                {
                    this.ConfigManager.ConfigData.gwport = this.gw.currentDevice.port;
                    this.ConfigManager.WriteConfig();
                }

                this.Text = $"{ConfigLoader.AppName} {ConfigLoader.Version} ({ConfigLoader.VersionDetails}) - {this.gw.currentDevice.model} ({this.gw.currentDevice.serial})";
                this.LoadGWOperations(); // load gw actions
            }));            
        }

        /// <summary>
        /// Thread safe event method for adding content to the display window
        /// </summary>
        /// <param name="content">string to be added</param>
        private void DisplayContent(string content)
        {
            this.Invoke(new MethodInvoker(delegate {
               this.outputTB.AppendText($"{content}{Environment.NewLine}");
            }));
        }

        /// <summary>
        /// Thread safe event method for clearing content to the display window
        /// </summary>
        private void ClearDisplayContent()
        {
            this.Invoke(new MethodInvoker(delegate {
                this.outputTB.Clear();
            }));
        }

        /// <summary>
        /// Busy the GUI interface to prevent the user from trying to execute while a command is running async
        /// </summary>
        private void BusyActionableGUI()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                this.ActionCount++;
                //DisableAllOptions();
                busy1.Visible = true;
            }));
        }

        /// <summary>
        /// After an action is completed, check to see if the GUI can be enabled for another action
        /// </summary>
        private void EnableActionableGUI()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                this.ActionCount--;
                if (this.ActionCount <= 0)
                {
                    this.ActionCount = 0; // zero base
                    this.ProcessAction();
                    busy1.Visible = false;
                }
            }));
        }

        /// <summary>
        /// Select an existing file (with path) to be used by an operation
        /// </summary>
        /// <param name="sender">ignored</param>
        /// <param name="e">ignored</param>
        private void SelectExistingFileBtn_Click(object sender, EventArgs e)
        {
            string action = this.actionCB.Text.Trim().ToLower();
            this.ActionStart();

            switch (action)
            {
                // Update has different extensions
                case "update":
                    string[] ext = new[] { "Any File|*.*", "Firmware Update|*.upd" };
                    this.GwExistingFile = utilities.GetFilePath("existing", ext, ext.Last(), null);
                    this.ProcessAction();

                    this.ActionComplete();
                    break;
                default:
                    // Get the extensions from gw
                    this.gw.GetAcceptedSuffixes((suffixes) =>
                    {
                        //Set the source path with persistent file extension
                        this.GwExistingFile = utilities.GetFilePath("existing", suffixes, this.ConfigManager.ConfigData.LastFileExt, this.PersistExtConfig);
                        this.ProcessAction();

                        this.ActionComplete();
                    });
                    break;
            }
        }

        /// <summary>
        /// Select a file (with path) to be created by an output operation
        /// </summary>
        /// <param name="sender">ignored</param>
        /// <param name="e">ignored</param>
        private void SelectNewFileBtn_Click(object sender, EventArgs e)
        {
            this.ActionStart();

            this.gw.GetAcceptedSuffixes((suffixes) =>
            {
                //Set the source path with persistent file extension
                this.GwNewFile = utilities.GetFilePath("new", suffixes, this.ConfigManager.ConfigData.LastFileExt, this.PersistExtConfig);
                this.ProcessAction();

                this.ActionComplete();
            });
        }

        /// <summary>
        /// Select gw host tools path dialog
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectGWPathBtn_Click(object sender, EventArgs e)
        {
            string action = this.actionCB.Text.Trim().ToLower();
            this.ActionStart();

            string[] ext = new[] { "Any File|*.*", "GreaseWeazle EXE|gw.exe" };
            gwPathSelectionTB.Text = utilities.GetFilePath("existing", ext, ext.Last(), null);

            if (!string.IsNullOrEmpty(gwPathSelectionTB.Text) && this.ConfigManager.ConfigData.GwToolsPath != utilities.GetAbsoluteFolder(gwPathSelectionTB.Text.Trim()))
            {
                this.ConfigManager.ConfigData.GwToolsPath = utilities.GetAbsoluteFolder(gwPathSelectionTB.Text.Trim());
                this.ConfigManager.WriteConfig();
                this.gw.ReLoadGW(this.ConfigManager.ConfigData.GwToolsPath);
                //GWTab.SelectedTab = deviceTab;
            }

            this.ActionComplete();
        }

        /// <summary>
        /// Execute the specified gw action with the specified parameters
        /// </summary>
        /// <param name="sender">ignored</param>
        /// <param name="e">ignored</param>
        private void ExecuteBtn_Click(object sender, EventArgs e)
        {
            this.ActionStart();
            gwCommand cmd = new gwCommand()
            {
                time = timeCB.Checked,
                action = actionCB.Text.Trim().ToLower()
            };
            List<gwArgument> args = new List<gwArgument>();
            outputTB.Text = string.Empty; // clear the display for the executing command

            // get the arguments specific to the gw action then execute the command
            this.PopulateArgs(cmd.action, args, () =>
            {
                cmd.args = args;
                GWTab.SelectedTab = actionTab;

                // run the gw action command
                this.gw.RunGWCommand(cmd, this.gwPortTB.Text.Trim());
                this.ActionComplete();
            });
        }

        /// <summary>
        /// Enable the interface for the current selected gw action
        /// </summary>
        /// <param name="sender">ignored</param>
        /// <param name="e">ignored</param>
        private void actionCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            string action = actionCB.Text.Trim();
            if (action.Length > 1)
                action = $"{char.ToUpper(action[0])}{action.Substring(1)}";

            parmTab.Text = $"{action} parameters".Trim();
            this.EnableActionInterface();
        }

        private void EnableActionInterface()
        {
            string current_action = actionCB.Text.Trim().ToLower();
            DisableAllOptions();
            this.PopulateArgs(current_action, null, () => {
                ExecuteBtn.Enabled = true;
                gwCmdHelpBtn.Enabled = true;
            });
        }

        /// <summary>
        /// Allow single switch case for gw command handling
        /// - if arguments is provided all the currently selected arguments relivant to the specific action will be populated
        /// - if arguments is null the interface is enabled specifically for the gw action
        /// </summary>
        /// <param name="action">optional gw action to handle, default uses GUI selector value</param>
        /// <param name="arguments">optional argument list to populate</param>
        private void ProcessAction(string action = null, List<gwArgument> arguments = null)
        {
            string current_action = action ?? actionCB.Text.Trim().ToLower();
            ExecuteBtn.Enabled = true;
            gwCmdHelpBtn.Enabled = true;

            switch (current_action)
            {
                case "info":
                    GwGUI_Info(arguments);
                    break;
                case "read":
                    GwGUI_Read(arguments);
                    break;
                case "write":
                    GwGUI_Write(arguments);
                    break;
                case "convert":
                    GwGUI_Convert(arguments);
                    break;
                case "erase":
                    GwGUI_Erase(arguments);
                    break;
                case "clean":
                    GwGUI_Clean(arguments);
                    break;
                case "seek":
                    GwGUI_Seek(arguments);
                    break;
                case "delays":
                    GwGUI_Delays(arguments);
                    break;
                case "update":
                    GwGUI_Update(arguments); 
                    break;
                case "pin":
                    GwGUI_Pin(arguments);
                    break;
                case "reset":
                    GwGUI_Reset(arguments);
                    break;
                case "bandwidth":
                    GwGUI_Bandwidth(arguments);
                    break;
                case "rpm":
                    GwGUI_Rpm(arguments);
                    break;
                default:
                    if (arguments is null)
                    {
                        DisableAllOptions();
                    } else
                    {
                        this.logger.Info($"Unsupported action: {current_action}");
                    }
                    break;
            }
        }

        /// <summary>
        /// Disable all arguments interface (reset)
        /// </summary>
        private void DisableAllOptions()
        {
            gwTSPECCylTB.Visible = false;
            gwTSPECHeadsTB.Visible = false;
            gwTSPECStepTB.Visible = false;
            gwTSPECOffsetsTB.Visible = false;
            gwTSPECSwapCB.Visible = false;
            gwTSPECCylLBL.Visible = false; 
            gwTSPECHeadsLBL.Visible = false;
            gwTSPECStepLBL.Visible = false; 
            gwTSPECOffsetsLBL.Visible = false;
            gwPLLPeriodTB.Visible = false; 
            gwPLLPhaseTB.Visible = false;
            gwPLLPeriodLBL.Visible = false;
            gwPLLPhaseLBL.Visible = false;
            gwOutTracksLBL.Visible = false;
            gwOTTSPECCylTB.Visible = false; 
            gwOTTSPECHeadsTB.Visible = false; 
            gwOTTSPECStepTB.Visible = false;
            gwOTTSPECOffsetsTB.Visible = false; 
            gwOTTSPECSwapCB.Visible = false;
            gwOTTSPECCylLBL.Visible = false; 
            gwOTTSPECHeadsLBL.Visible = false; 
            gwOTTSPECStepLBL.Visible = false; 
            gwOTTSPECOffsetsLBL.Visible = false;

            gwRawCB.Visible = false;
            gwEraseBlankCB.Visible = false;
            gwNoVerifyCB.Visible = false;
            gwPreEraseCB.Visible = false;
            gwHFreqCB.Visible = false;
            gwMotorOnCB.Visible = false;
            gwForceCB.Visible = false;
            gwUseDiskDefFileCB.Visible = false;

            gwNrLBL.Visible = false;
            gwNrTB.Visible = false;
            gwLingerLBL.Visible = false; 
            gwLingerTB.Visible = false;
            gwPassesLBL.Visible = false;
            gwPassesTB.Visible = false;
            gwFakeIndexTB.Visible = false;
            gwFakeIndexLBL.Visible = false;
            gwAdjustSpeedTB.Visible = false; 
            gwAdjustSpeedLBL.Visible = false;
            gwRevsTB.Visible = false;
            gwRevsLBL.Visible = false;
            gwFormatTypeLBL.Visible = false;
            gwFormatTypeCB.Visible = false;
            driveTB.Visible = false;
            driveLBL.Visible = false;
            gwCylLBL.Visible = false;
            gwCylTB.Visible = false;
            //gwDiskDefsBtn.Enabled = false;
            gwSeekRetriesTB.Visible = false;
            gwSeekRetriesLBL.Visible = false;
            gwRetriesLBL.Visible = false;
            gwRetriesTB.Visible = false;

            GwFileDisplay.Text = string.Empty;
            SelectNewFileBtn.Enabled = false;
            SelectExistingFileBtn.Enabled = false;

            gwCmdHelpBtn.Enabled = false;
            ExecuteBtn.Enabled = false;
        }

        private void DisableInterface()
        {
            DisableAllOptions();
            actionCB.Enabled = false;
        }

        private void gwRawCB_CheckedChanged(object sender, EventArgs e)
        {
            if (ConfigManager.ConfigData.RawFormat != gwRawCB.Checked)
            {
                ConfigManager.ConfigData.RawFormat = gwRawCB.Checked;
                ConfigManager.WriteConfig();
            }
        }

        /// <summary>
        /// Display the options
        /// </summary>
        /// <param name="sender">ignored</param>
        /// <param name="e">ignored</param>
        private void accessoptions_Click(object sender, EventArgs e)
        {
            //gwpathcontainer.Visible = true;
            GWTab.SelectedTab = this.optionsTab;
            gwPathSelectionTB.Text = this.ConfigManager.ConfigData.GwToolsPath;
        }

        private void gwDDfileBtn_Click(object sender, EventArgs e)
        {
            //this.ActionStart();

            string[] ext = new[] { "Any File|*.*", "Disk Configs|*.cfg" };
            string fileSelection = utilities.GetFilePath("new", ext, ext.Last(), null, false);
            if (string.IsNullOrEmpty(fileSelection)) return;

            this.GwDiskDefsFile = fileSelection;
            LoadDD();
            
            this.ProcessAction();
            //this.ActionComplete();
        }

        private void gwDDTrackListLB_SelectedValueChanged(object sender, EventArgs e)
        {
            gwDDRemoveTrackBtn.Enabled = true;
        }

        private void gwDDRemoveTrackBtn_Click(object sender, EventArgs e)
        {
            RemoveTrackDef(gwDDTrackListLB.Text);

            gwDDRemoveTrackBtn.Enabled = false;
        }

        private void gwDDApplyTrackBtn_Click(object sender, EventArgs e)
        {
            if (AddTrackDef())
            {
                gwDDRemoveTrackBtn.Enabled = false;
            }
        }

        private void diskDefApplyBtn_Click(object sender, EventArgs e)
        {
            if(PopulateDiskDef())
            {
                gwDDRemoveTrackBtn.Enabled = false;

                gwDiskConfigCB.Items.Clear();
                gwDiskConfigCB.Items.AddRange(this.gwDD.GetDiskDefinitionsKeys());

                if(gwDiskConfigCB.FindString(diskDefNameTB.Text.Trim()) != ListBox.NoMatches)
                    gwDiskConfigCB.SelectedIndex = gwDiskConfigCB.FindString(diskDefNameTB.Text.Trim());
            }
        }

        private void gwDiskConfigCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDDDisplay(gwDiskConfigCB.SelectedItem.ToString());
        }

        private void gwDDTrackListLB_SelectedIndexChanged(object sender, EventArgs e)
        {
            TrackDefinition track = CurrentDiskDef.Tracks.Where(t => t.ToString() == gwDDTrackListLB.Text).FirstOrDefault();
            PopulateTDDisplay(track);
        }

        private void newDiskConfigBtn_Click(object sender, EventArgs e)
        {
            PopulateDDDisplay();
        }

        private void gwDDReloadBtn_Click(object sender, EventArgs e)
        {
            if (this.gwDD.LoadDiskDefs(this.GwDiskDefsFile))
            {
                gwDiskConfigCB.Items.Clear();
                gwDiskConfigCB.Items.AddRange(this.gwDD.GetDiskDefinitionsKeys());
                PopulateDDDisplay(this.gwDD.GetDiskDefinition(gwDiskConfigCB.Text.Trim()));
            }

            this.ProcessAction();
        }

        private void gwDDSaveBtn_Click(object sender, EventArgs e)
        {
            this.gwDD.SaveDiskDefs(this.GwDiskDefsFile);
        }

        private void removeDiskConfigBtn_Click(object sender, EventArgs e)
        {
            string ddName = gwDiskConfigCB.Text.Trim();
            this.gwDD.RemoveDefinition(ddName);

            if (gwDiskConfigCB.FindString(ddName) != ListBox.NoMatches)
                gwDiskConfigCB.Items.RemoveAt(gwDiskConfigCB.FindString(ddName));

            this.ProcessAction();
        }

        private void SelectGWProfileBtn_Click(object sender, EventArgs e)
        {
            this.ActionStart();

            //if (string.IsNullOrEmpty(this.gwProfileFileTB.Text))
            //{
                string[] ext = new[] { "Any File|*.*", "eXtensible Markup Language|*.xml" };
                this.gwProfileFileTB.Text = utilities.GetFilePath("existing", ext, ext.Last(), null);
            //}

            LoadProfile(this.gwProfileFileTB.Text);

            this.ActionComplete();
        }

        private bool LoadProfile(string fileName)
        {
            gwCommand cmdProfile = new gwCommand();
            if (File.Exists(fileName))
            {
                cmdProfile = utilities.DeserializeProfile(fileName, logger);
                if (cmdProfile is null) { return false; }
            }
            else
            {
                logger.Info($"Unable to load profile because the file does not exist {fileName}");
                return false;
            }

            if (!SetAction(cmdProfile.action))
                logger.Info($"Warning: unable to set action to: '{cmdProfile.action}'");

            timeCB.Checked = cmdProfile.time;
            ProfileNameTB.Text = cmdProfile.name;


            // load the attribnutes
            foreach (gwArgument arg in cmdProfile.args)
            {
                // Disk Defs can determine if the specified format is available so process it before the format attribute
                if (arg.Key.Equals("--diskdefs", StringComparison.OrdinalIgnoreCase))
                {
                    this.GwDiskDefsFile = string.Empty;
                    if (File.Exists(arg.Value.ToString()))
                    {
                        this.GwDiskDefsFile = arg.Value.ToString();
                        gwUseDiskDefFileCB.Checked = cmdProfile.useDiskDefs;
                        LoadDD();
                    }
                    continue;
                }
                // positional unhandled arguments
                if (arg.Key.Equals(NewFileArgName)) { this.GwNewFile = arg.Value.ToString(); continue; }
                if (arg.Key.Equals(ExistingFileArgName)) { this.GwExistingFile = arg.Value.ToString(); continue; }
                if (arg.Key.Equals(CylindersArgName)) { gwCylTB.Text = arg.Value.ToString(); continue; }

                utilities.ArgPopulate(arg, GetValueFields(arg.Key));
            }

            ProcessAction();

            if (UpdateProfile(cmdProfile.name, fileName))
                this.ConfigManager.WriteConfig();

            return true;
        }

        private bool SetAction(string action)
        {
            if (actionCB.Items.Contains(action))
            {
                actionCB.SelectedItem = action;
                return true;
            }
            else
            {
                return false;
            }
        }

        private void gwUseDiskDefFileCB_CheckedChanged(object sender, EventArgs e)
        {
            if (this.gwUseDiskDefFileCB.Checked != this.ConfigManager.ConfigData.LastUseDiskDefsCfgFile)
            {
                this.ConfigManager.ConfigData.LastUseDiskDefsCfgFile = this.gwUseDiskDefFileCB.Checked;
                this.ConfigManager.WriteConfig();
            }

            this.ProcessAction();
        }

        private void SelectProfilePathBtn_Click(object sender, EventArgs e)
        {
            this.ActionStart();

            string[] ext = new[] { "Any File|*.*", "eXtensible Markup Language|*.xml" };
            this.gwProfileFileTB.Text = utilities.GetFilePath("select", ext, ext.Last(), null);
            this.gwProfileFileTB.ValidationFailure = true;

            this.ActionComplete();
        }

        private void SaveProfileBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.gwProfileFileTB.Text)) {
                this.gwProfileFileTB.ValidationFailure = true;
                return; }

            this.gwProfileFileTB.ValidationFailure = false;

            this.ActionStart();
            gwCommand cmd = new gwCommand()
            {
                name = ProfileNameTB.Text,
                time = timeCB.Checked,
                action = actionCB.Text.Trim().ToLower(),
                useDiskDefs = gwUseDiskDefFileCB.Checked
            };

            // get all the arguments
            this.PopulateArgs(cmd.action, cmd.args);

            string fileName = gwProfileFileTB.Text.Trim();
            GWTab.SelectedTab = actionTab;

            // store the gw action command
            utilities.SerializeProfile(fileName, cmd, this.logger);

            if(UpdateProfile(cmd.name, fileName))
                this.ConfigManager.WriteConfig();

            this.gwProfileFileTB.ValidationFailure = false;
            this.ActionComplete();
        }

        private bool UpdateProfile(string key, string value)
        {
            if (File.Exists(value))
            {
                if (this.ConfigManager.ConfigData.profiles.ContainsKey(key) && 
                    this.ConfigManager.ConfigData.profiles[key] !=value)
                {
                    this.ConfigManager.ConfigData.profiles[key] = value;
                    return true;
                }

                if (!this.ConfigManager.ConfigData.profiles.ContainsKey(key))
                {
                    // If the user changed the name, there will be a duplicate with the same file, but a different name.
                    List<string> dups = this.ConfigManager.ConfigData.profiles.Where(p => p.Value == value).Select(p => p.Key).ToList();
                    foreach (string dup in dups)
                    {
                        this.ConfigManager.ConfigData.profiles.Remove(dup);
                        if (CmdProfileCB.Items.Contains(dup))
                            CmdProfileCB.Items.Remove(dup);
                    }

                    this.ConfigManager.ConfigData.profiles.Add(key, value);

                    if( !CmdProfileCB.Items.Contains(key) )
                        CmdProfileCB.Items.Add(key);

                    CmdProfileCB.SelectedItem = key;
                    return true;
                }
            }
            return false;
        }

        private void ProfileClearBtn_Click(object sender, EventArgs e)
        {
            gwProfileFileTB.Text = string.Empty;
            ProfileNameTB.Text = string.Empty;
            CmdProfileCB.SelectedIndex = -1;
        }

        private void timeCB_CheckedChanged(object sender, EventArgs e)
        {
            if(ConfigManager.ConfigData.Time != timeCB.Checked)
            {
                ConfigManager.ConfigData.Time = timeCB.Checked;
                ConfigManager.WriteConfig();
            }
        }

        private void CmdProfileCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ActionStart();

            if( this.ConfigManager.ConfigData.profiles.ContainsKey(CmdProfileCB.Text) )
            {
                this.gwProfileFileTB.Text = this.ConfigManager.ConfigData.profiles[CmdProfileCB.Text];
                if( !LoadProfile(this.gwProfileFileTB.Text) )
                {
                    logger.Info($"Unable to load profile removing it from the selector.");
                    this.ConfigManager.ConfigData.profiles.Remove(CmdProfileCB.Text);
                    this.ConfigManager.WriteConfig();
                    CmdProfileCB.Items.Remove(CmdProfileCB.Text);
                }
            }

            this.ActionComplete();
        }

        private void gwFormatTypeCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if( !string.IsNullOrEmpty(gwFormatTypeCB.Text) &&
            //    this.ConfigManager.ConfigData.LastFormatType != gwFormatTypeCB.Text)
            //{
            //    this.ConfigManager.ConfigData.LastFormatType = gwFormatTypeCB.Text;
            //    this.ConfigManager.WriteConfig();
            //}
        }

        private void portcaptionCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.gw.SerialPorts.ContainsKey(portcaptionCB.Text))
            {
                GW_PnPEntity selectedPort = this.gw.SerialPorts[portcaptionCB.Text];
                portnameValue.Text = selectedPort.Name;
                portbusdescValue.Text = selectedPort.Bus_Description;
                portdescValue.Text = selectedPort.Description;
                portdeviceIdValue.Text = selectedPort.DeviceID;
                portClassGuidValue.Text = selectedPort.ClassGuid;
                portserviceValue.Text = selectedPort.Service;
                portstatusValue.Text = selectedPort.Status;
                porterrordescValue.Text = selectedPort.ErrorDescription;
            }
        }

        private void gwReloadBtn_Click(object sender, EventArgs e)
        {
            this.ActionStart();

            this.gw.ReLoadGW(this.ConfigManager.ConfigData.GwToolsPath, this.gwPortTB.Text.Trim());

            this.ActionComplete();
        }

        /// <summary>
        /// Execute a trimmed down version of the selected gw action with help parameter
        /// </summary>
        /// <param name="sender">ignored</param>
        /// <param name="e">ignored</param>
        private void gwCmdHelpBtn_Click(object sender, EventArgs e)
        {
            this.gw.GetActionHelp(actionCB.Text.ToLower(), (response) =>
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    GWTab.SelectedTab = actionTab;
                    outputTB.Text = response;
                }));
            });
        }

        private void UpdateFormatConfig()
        {
            if (ConfigManager.ConfigData.LastFormatType != gwFormatTypeCB.Text)
            {
                ConfigManager.ConfigData.LastFormatType = gwFormatTypeCB.Text;
                ConfigManager.WriteConfig();
            }
        }

        /// <summary>
        /// update interface from config data
        /// </summary>
        private void PopulateConfig()
        {
            timeCB.Checked = ConfigManager.ConfigData.Time;
            gwRawCB.Checked = ConfigManager.ConfigData.RawFormat;
            this.GwDiskDefsFile = ConfigManager.ConfigData.LastDiskDefsCfgFile;
            gwUseDiskDefFileCB.Checked = ConfigManager.ConfigData.LastUseDiskDefsCfgFile;
            LoadDD();
        }

        private void LoadDD()
        {
            this.gwDDfileLBL.Text = utilities.MaxSizeFileName(this.GwDiskDefsFile, this.gwDDfileLBL.MaximumSize.Width);

            // Reset
            gwDiskConfigCB.Items.Clear();
            this.gwDD?.Clear();
            this.ddTracks?.Clear();
            this.CurrentDiskDef = new GwDiskDefsValue();

            // Load the new file if it exists
            if (File.Exists(this.GwDiskDefsFile) && this.gwDD.LoadDiskDefs(this.GwDiskDefsFile))
            {
                if (this.ConfigManager.ConfigData.LastDiskDefsCfgFile != this.GwDiskDefsFile)
                {
                    this.ConfigManager.ConfigData.LastDiskDefsCfgFile = this.GwDiskDefsFile;
                    this.ConfigManager.WriteConfig();
                }
                gwDiskConfigCB.Items.AddRange(this.gwDD.GetDiskDefinitionsKeys());
            }
        }
    }
}
