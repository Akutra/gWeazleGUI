using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace gWeasleGUI
{
    public partial class gWeazleFrm : Form
    {
        private Action<List<string>> gwAdditionalArgs, gwFormatTypeArg, gwRawArg, gwEraseBlankArg, gwNoVerifyArg, gwDriveArg, gwCylArg;
        private Action<List<string>> gwInFile, gwOutFile, gwExistingFileArg, gwCylinders;
        private Action<string[]> gwGetFormatTypes;

        private string LastGetFormatsAction = string.Empty;

        /// <summary>
        /// Unified argument handling
        /// </summary>
        private void InitializeArgumentFilters()
        {
            // arguments
            this.gwAdditionalArgs = (al) => { 
                if (!string.IsNullOrEmpty(additonalArgsTB.Text.Trim())) { al.Add(additonalArgsTB.Text.Trim()); } 
            };
            this.gwFormatTypeArg = (al) => { 
                if (gwFormatTypeCB.SelectedItem.ToString().Trim().ToLower().IndexOf("default") == -1) { al.Add($"--format {gwFormatTypeCB.SelectedItem}"); } 
            };
            this.gwRawArg = (al) => { 
                if (gwRawCB.Checked) { al.Add($"--raw"); } 
            };
            this.gwEraseBlankArg = (al) => { 
                if (gwEraseBlankCB.Checked) { al.Add("--erase-empty"); } 
            };
            this.gwNoVerifyArg = (al) => { 
                if (gwNoVerifyCB.Checked) { al.Add("--no-verify"); } 
            };
            this.gwDriveArg = (al) => { 
                if (!string.IsNullOrEmpty(driveTB.Text.Trim()) && driveTB.Text.Trim().ToLower() != "a") { al.Add($"--drive {driveTB.Text.Trim()}"); } 
            };
            this.gwCylArg = (al) => {
                int cyl = 0;
                if(!string.IsNullOrEmpty(gwCylTB.Text.Trim()) && int.TryParse(gwCylTB.Text.Trim(), out cyl)) { al.Add($"--cyls {cyl}"); }
            };
            this.gwExistingFileArg = (al) => {
                if (!string.IsNullOrEmpty(this.GwOutFile)) { al.Add($"--file \"{this.GwOutFile}\""); }
            };

            // positional arguments
            this.gwInFile = (al) =>
            {
                if(!string.IsNullOrEmpty(this.GwInFile.Trim())) { al.Add($"\"{this.GwInFile.Trim()}\""); }
            };
            this.gwOutFile = (al) =>
            {
                if (!string.IsNullOrEmpty(this.GwOutFile.Trim())) { al.Add($"\"{this.GwOutFile.Trim()}\""); }
            };
            this.gwCylinders = (al) =>
            {
                int cyl = 0;
                if (!string.IsNullOrEmpty(gwCylTB.Text.Trim()) && int.TryParse(gwCylTB.Text.Trim(), out cyl)) { al.Add($"{cyl}"); }
            };

            // Callback for loading the format types directly from gw into the interface
            // - action to handle results from async call to gw
            gwGetFormatTypes = (t) =>
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    gwFormatTypeCB.Items.AddRange(t);
                    if (gwFormatTypeCB.Items.Contains(this.ConfigManager.ConfigData.LastFormatType))
                    {
                        gwFormatTypeCB.SelectedIndex = gwFormatTypeCB.Items.IndexOf(this.ConfigManager.ConfigData.LastFormatType);
                    }
                    else
                    {
                        gwFormatTypeCB.SelectedIndex = 0;
                    }
                }));
            };
        }

        /// <summary>
        /// gw info
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Info(List<string> args = null)
        {
            if (args is null)
            {
                // interface
                DisableAllOptions();
                ExecuteBtn.Enabled = true;
                gwCmdHelpBtn.Enabled = true;
            } else
            {
                // options
                gwAdditionalArgs(args);
            }
        }

        /// <summary>
        /// gw read
        /// TODO: gui access to additional args
        /// </summary>
        /// <param name="args">optional argument list to populate</param>

        private void GwGUI_Read(List<string> args = null)
        {
            if (args is null)
            {
                // interface
                DisableAllOptions();
                gwFormatTypeLBL.Enabled = true;
                gwFormatTypeCB.Enabled = true;
                gwRawCB.Enabled = true;
                driveTB.Enabled = true;
                driveLBL.Enabled = true;
                SelectNewFileBtn.Enabled = true;
                GwFileDisplay.Text = $">> {this.GwInFile}";
                ExecuteBtn.Enabled = true;
                gwCmdHelpBtn.Enabled = true;

                // only load format types if necessary
                if (gwFormatTypeCB.Items.Count < 2 || this.gw.LastGetFormatsAction != "read")
                {
                    // available gw format types
                    gwFormatTypeCB.Items.Clear();
                    gwFormatTypeCB.Items.Add("default");
                    this.gw.GetFormatTypes("read", gwGetFormatTypes);
                }
            } else
            {
                // options
                gwDriveArg(args);
                gwFormatTypeArg(args);
                gwRawArg(args);
                gwAdditionalArgs(args);

                // File is positional so it must come after the options
                gwInFile(args);

                // update config file for options that persist
                UpdateFormatConfig();
            }
        }

        /// <summary>
        /// gw write
        /// TODO: gui access to additional args
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Write(List<string> args = null)
        {
            if (args is null)
            {
                // interface
                DisableAllOptions();
                gwFormatTypeLBL.Enabled = true;
                gwFormatTypeCB.Enabled = true;
                gwEraseBlankCB.Enabled = true;
                gwNoVerifyCB.Enabled = true;
                driveTB.Enabled = true;
                driveLBL.Enabled = true;
                SelectExistingFileBtn.Enabled = true;
                GwFileDisplay.Text = $"<< {this.GwOutFile}";
                ExecuteBtn.Enabled = true;
                gwCmdHelpBtn.Enabled = true;

                // only load format types if necessary
                if (gwFormatTypeCB.Items.Count < 2 || this.gw.LastGetFormatsAction != "write")
                {
                    // available gw format types
                    gwFormatTypeCB.Items.Clear();
                    gwFormatTypeCB.Items.Add("default");
                    this.gw.GetFormatTypes("write", gwGetFormatTypes);
                }
            } else
            {
                // options
                gwDriveArg(args);
                gwFormatTypeArg(args);
                gwEraseBlankArg(args);
                gwNoVerifyArg(args);
                gwAdditionalArgs(args);

                // File is positional so it must come after the options
                gwOutFile(args);

                // update config file for options that persist
                UpdateFormatConfig();
            }
        }

        /// <summary>
        /// gw convert
        /// TODO: gui access to additional args
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Convert(List<string> args)
        {
            if (args is null)
            {
                // interface
                DisableAllOptions();
                gwFormatTypeLBL.Enabled = true;
                gwFormatTypeCB.Enabled = true;
                SelectNewFileBtn.Enabled = true;
                SelectExistingFileBtn.Enabled = true;
                GwFileDisplay.Text = $"{this.GwOutFile} >> {this.GwInFile}";
                ExecuteBtn.Enabled = true;
                gwCmdHelpBtn.Enabled = true;

                // only load format types if necessary
                if (gwFormatTypeCB.Items.Count < 2 || this.gw.LastGetFormatsAction != "convert")
                {
                    // available gw format types
                    gwFormatTypeCB.Items.Clear();
                    gwFormatTypeCB.Items.Add("default");
                    this.gw.GetFormatTypes("convert", gwGetFormatTypes);
                }
            }
            else
            {
                // options
                gwFormatTypeArg(args);
                gwAdditionalArgs(args);

                // File is positional so it must come after the options
                gwOutFile(args);
                gwInFile(args);

                // update config file for options that persist
                UpdateFormatConfig();
            }
        }

        /// <summary>
        /// gw erase
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Erase(List<string> args)
        {
            if (args is null)
            {
                // interface
                DisableAllOptions();
                driveTB.Enabled = true;
                driveLBL.Enabled = true;
                ExecuteBtn.Enabled = true;
                gwCmdHelpBtn.Enabled = true;
            }
            else
            {
                // options
                gwDriveArg(args);
                gwAdditionalArgs(args);
            }
        }

        /// <summary>
        /// gw clean
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Clean(List<string> args)
        {
            if (args is null)
            {
                // interface
                DisableAllOptions();
                driveTB.Enabled = true;
                driveLBL.Enabled = true;
                gwCylLBL.Enabled = true;
                gwCylTB.Enabled = true;
                ExecuteBtn.Enabled = true;
                gwCmdHelpBtn.Enabled = true;
            }
            else
            {
                // options
                gwDriveArg(args);
                gwCylArg(args);
                gwAdditionalArgs(args);
            }
        }

        /// <summary>
        /// gw seek
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Seek(List<string> args)
        {
            if (args is null)
            {
                // interface
                DisableAllOptions();
                driveTB.Enabled = true;
                driveLBL.Enabled = true;
                gwCylLBL.Enabled = true;
                gwCylTB.Enabled = true;
                ExecuteBtn.Enabled = true;
                gwCmdHelpBtn.Enabled = true;
            }
            else
            {
                // options
                gwDriveArg(args);
                gwAdditionalArgs(args);

                // positional arguments
                gwCylinders(args);
            }
        }

        /// <summary>
        /// gw delays
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Delays(List<string> args)
        {
            if (args is null)
            {
                // interface
                DisableAllOptions();
                ExecuteBtn.Enabled = true;
                gwCmdHelpBtn.Enabled = true;
            }
            else
            {
                // options
                gwAdditionalArgs(args);
            }
        }

        /// <summary>
        /// gw update
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Update(List<string> args)
        {
            if (args is null)
            {
                // interface
                DisableAllOptions();
                SelectExistingFileBtn.Enabled = true;
                ExecuteBtn.Enabled = true;
                gwCmdHelpBtn.Enabled = true;
                GwFileDisplay.Text = $"<< {this.GwOutFile}";
            }
            else
            {
                // options
                gwExistingFileArg(args);
                gwAdditionalArgs(args);
            }
        }

        /// <summary>
        /// gw pin
        /// TODO: better implementation
        /// - currently requires manual input into additional args
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Pin(List<string> args)
        {
            if (args is null)
            {
                // interface
                DisableAllOptions();
                ExecuteBtn.Enabled = true;
                gwCmdHelpBtn.Enabled = true;
            }
            else
            {
                // options
                gwAdditionalArgs(args);
            }
        }

        /// <summary>
        /// gw reset
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Reset(List<string> args)
        {
            if (args is null)
            {
                // interface
                DisableAllOptions();
                ExecuteBtn.Enabled = true;
                gwCmdHelpBtn.Enabled = true;
            }
            else
            {
                // options
                gwAdditionalArgs(args);
            }
        }

        /// <summary>
        /// gw bandwidth
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Bandwidth(List<string> args)
        {
            if (args is null)
            {
                // interface
                DisableAllOptions();
                ExecuteBtn.Enabled = true;
                gwCmdHelpBtn.Enabled = true;
            }
            else
            {
                // options
                gwAdditionalArgs(args);
            }
        }

        /// <summary>
        /// gw rpm
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Rpm(List<string> args)
        {
            if (args is null)
            {
                // interface
                DisableAllOptions();
                driveTB.Enabled = true;
                driveLBL.Enabled = true;
                ExecuteBtn.Enabled = true;
                gwCmdHelpBtn.Enabled = true;
            }
            else
            {
                // options
                gwDriveArg(args);
                gwAdditionalArgs(args);
            }
        }
    }
}
