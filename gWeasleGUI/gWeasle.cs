using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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

        string GwInFile = string.Empty, GwOutFile = string.Empty;

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
                if (msg.Trim().Length > 0) { this.Invoke(new MethodInvoker(delegate { GwCurrentStatus.Text = msg; })); }
            });

            // load persistent config data
            this.ConfigManager = new ConfigLoader(logger, this.ActionStart, this.ActionComplete);
            this.Text = $"{ConfigLoader.AppName} {ConfigLoader.Version} ({ConfigLoader.VersionDetails})";
            PopulateConfig();

            // initialize gw commandline tools
            this.gw = new GwTools(logger,ConfigManager.ConfigData.GwToolsPath, this.DisplayContentAction, this.ActionComplete, ActionGwDeviceLoaded);

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
        }

        /// <summary>
        /// Load gw actions into the interface
        /// </summary>
        private void LoadGWOperations()
        {
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
            if( this.gw is null) { this.DisplayContentAction($"Unable to load GreaseWeasle!"); return; }

            // Verify Host tools version compatibilty
            if (this.gw.gwHostToolsVersion < 1.12)
            {
                string err = this.gw.gwHostToolsVersion == 0 ? "Greaseweazle Host Tools not found." : $"Greaseweazle Host Tools v{this.gw.gwHostToolsVersion} found.";
                string msg = $"{err}{Environment.NewLine}*** Greaseweazle Host Tools version 1.12 or greater is required for {ConfigLoader.AppName}.";
                this.DisplayContentAction(msg);

                this.Invoke(new MethodInvoker(delegate
                {
                    gwToolsVersion.Text = $"H{this.gw.gwHostToolsVersion}";
                    this.DisableInterface();
                    gwPathSelectionTB.Text = this.ConfigManager.ConfigData.GwToolsPath;
                    gwpathcontainer.Visible = true;
                }));
                return;
            }

            // verify device can be loaded
            if (string.IsNullOrEmpty(this.gw.currentDevice.port))
            {
                string gwmsg = this.gw.gwHostToolsVersion == 0 ? "Greaseweazle Host Tools not found." : $"Greaseweazle Host Tools v{this.gw.gwHostToolsVersion} found.";
                string err = $"*** Unable to load device on port {this.gwPortTB.Text.Trim()}.";
                string msg = $"{gwmsg}{Environment.NewLine}{err}{Environment.NewLine}*** Greaseweazle device required for {ConfigLoader.AppName}.";
                this.DisplayContentAction(msg);
                return;
            }

            // thread safe populate valid data to the interface
            this.Invoke(new MethodInvoker(delegate
            {
                gwToolsVersion.Text = $"H{this.gw.gwHostToolsVersion}";
                gwPortTB.Text = this.gw.currentDevice.port;
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
        /// Busy the GUI interface to prevent the user from trying to execute while a command is running async
        /// </summary>
        private void BusyActionableGUI()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                this.ActionCount++;
                DisableAllOptions();
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
                    this.GwOutFile = utilities.GetFilePath("existing", ext, ext.Last(), null);
                    this.ProcessAction();

                    this.ActionComplete();
                    break;
                default:
                    // Get the extensions from gw
                    this.gw.GetAcceptedSuffixes((suffixes) =>
                    {
                        //Set the source path with persistent file extension
                        this.GwOutFile = utilities.GetFilePath("existing", suffixes, this.ConfigManager.ConfigData.LastFileExt, this.PersistExtConfig);
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
                this.GwInFile = utilities.GetFilePath("new", suffixes, this.ConfigManager.ConfigData.LastFileExt, this.PersistExtConfig);
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
            GwTools.gwCommand cmd = new GwTools.gwCommand()
            {
                time = timeCB.Checked,
                action = actionCB.Text.Trim().ToLower()
            };
            List<string> args = new List<string>();

            // get the arguments specific to the gw action
            this.ProcessAction(cmd.action, args);
            cmd.args = args.ToArray();

            // run the gw action command
            outputTB.Text = string.Empty; // clear the display for the executing command
            gw.RunGWCommand(cmd, this.gwPortTB.Text.Trim());
        }

        /// <summary>
        /// Enable the interface for the current selected gw action
        /// </summary>
        /// <param name="sender">ignored</param>
        /// <param name="e">ignored</param>
        private void actionCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ProcessAction();
        }

        /// <summary>
        /// Allow single switch case for gw command handling
        /// - if arguments is provided all the currently selected arguments relivant to the specific action will be populated
        /// - if arguments is null the interface is enabled specifically for the gw action
        /// </summary>
        /// <param name="action">optional gw action to handle, default uses GUI selector value</param>
        /// <param name="arguments">optional argument list to populate</param>
        private void ProcessAction(string action = null, List<string> arguments = null)
        {
            string current_action = action ?? actionCB.Text.Trim().ToLower();
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
                        this.ActionComplete();
                    }
                    break;
            }
        }

        /// <summary>
        /// Disable all arguments interface (reset)
        /// </summary>
        private void DisableAllOptions()
        {
            gwFormatTypeLBL.Enabled = false;
            gwFormatTypeCB.Enabled = false;
            gwRawCB.Enabled = false;
            gwEraseBlankCB.Enabled = false;
            gwNoVerifyCB.Enabled = false;
            driveTB.Enabled = false;
            driveLBL.Enabled = false;
            gwCylLBL.Enabled = false;
            gwCylTB.Enabled = false;

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
        /// update gw host tools path with the textbox text in options
        /// </summary>
        /// <param name="sender">ignored</param>
        /// <param name="e">ignored</param>
        private void acceptGWLocationBtn_Click(object sender, EventArgs e)
        {
            if (this.ConfigManager.ConfigData.GwToolsPath != utilities.GetAbsoluteFolder(gwPathSelectionTB.Text.Trim()))
            {
                this.ConfigManager.ConfigData.GwToolsPath = utilities.GetAbsoluteFolder(gwPathSelectionTB.Text.Trim());
                this.ConfigManager.WriteConfig();
                this.gw.ReLoadGW(this.ConfigManager.ConfigData.GwToolsPath);
            }
            gwpathcontainer.Visible = false;
        }

        /// <summary>
        /// Display the options
        /// </summary>
        /// <param name="sender">ignored</param>
        /// <param name="e">ignored</param>
        private void accessoptions_Click(object sender, EventArgs e)
        {
            gwpathcontainer.Visible = true;
            gwPathSelectionTB.Text = this.ConfigManager.ConfigData.GwToolsPath;
        }

        /// <summary>
        /// Close the option popup
        /// </summary>
        /// <param name="sender">ignored</param>
        /// <param name="e">ignored</param>
        private void closeGWOptionsBtn_Click(object sender, EventArgs e)
        {
            gwpathcontainer.Visible = false;
        }

        private void timeCB_CheckedChanged(object sender, EventArgs e)
        {
            if(ConfigManager.ConfigData.Time != timeCB.Checked)
            {
                ConfigManager.ConfigData.Time = timeCB.Checked;
                ConfigManager.WriteConfig();
            }
        }

        /// <summary>
        /// Execute a timmed down version of the selected gw action with help parameter
        /// </summary>
        /// <param name="sender">ignored</param>
        /// <param name="e">ignored</param>
        private void gwCmdHelpBtn_Click(object sender, EventArgs e)
        {
            this.ActionStart();
            GwTools.gwCommand cmd = new GwTools.gwCommand()
            {
                time = false,
                action = actionCB.Text.ToLower(),
                args = new[] { "--help" }
            };

            outputTB.Text = string.Empty;
            gw.RunGWCommand(cmd, this.gw.currentDevice.port);
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
        }
    }
}
