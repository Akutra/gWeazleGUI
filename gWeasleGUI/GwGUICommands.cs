using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace gWeasleGUI
{
    public partial class gWeazleFrm : Form
    {
        private Action<List<string>> gwAdditionalArgs;
        private Action<List<string>> gwNewFile, gwExistingFile, gwCylinders;
        private Action<string[]> gwGetFormatTypes;

        private Dictionary<string, Action<List<string>>> GWParameters;
        private Dictionary<string, Action> GWParaInterface;

        /// <summary>
        /// Unified argument handling
        /// </summary>
        private void InitializeArgumentFilters()
        {
            this.GWParameters = new Dictionary<string, Action<List<string>>>();
            this.GWParaInterface = new Dictionary<string, Action>();

            // arguments
            this.GWParameters.Add("--diskdefs", (al) => {
                if (!string.IsNullOrEmpty(this.GwDiskDefsFile)) { al.Add($"--diskdefs \"{this.GwDiskDefsFile}\""); }
            });
            this.GWParaInterface.Add("--diskdefs", () => {
                diskdefsBtn.Enabled = true; diskdefsLBL.Enabled = true;
            });
            this.GWParameters.Add("--format", (al) => { 
                if (gwFormatTypeCB.SelectedItem.ToString().Trim().ToLower().IndexOf("default") == -1) { al.Add($"--format {gwFormatTypeCB.SelectedItem}"); } 
            });
            this.GWParaInterface.Add("--format", () => {
                gwFormatTypeLBL.Enabled = true; gwFormatTypeCB.Enabled = true;
            });
            this.GWParameters.Add("--raw", (al) => { 
                if (gwRawCB.Checked) { al.Add($"--raw"); } 
            });
            this.GWParaInterface.Add("--raw", () => {
                gwRawCB.Enabled = true;
            });
            this.GWParameters.Add("--erase-empty", (al) => { 
                if (gwEraseBlankCB.Checked) { al.Add("--erase-empty"); } 
            });
            this.GWParaInterface.Add("--erase-empty", () => {
                gwEraseBlankCB.Enabled = true;
            });
            this.GWParameters.Add("--no-verify", (al) => { 
                if (gwNoVerifyCB.Checked) { al.Add("--no-verify"); } 
            });
            this.GWParaInterface.Add("--no-verify", () => {
                gwNoVerifyCB.Enabled = true;
            });
            this.GWParameters.Add("--drive", (al) => { 
                if (!string.IsNullOrEmpty(driveTB.Text.Trim()) && driveTB.Text.Trim().ToLower() != "a") { al.Add($"--drive {driveTB.Text.Trim()}"); } 
            });
            this.GWParaInterface.Add("--drive", () => {
                driveTB.Enabled = true; driveLBL.Enabled = true;
            });
            this.GWParameters.Add("--cyls", (al) => {
                int cyl = 0; if(!string.IsNullOrEmpty(gwCylTB.Text.Trim()) && int.TryParse(gwCylTB.Text.Trim(), out cyl)) { al.Add($"--cyls {cyl}"); }
            });
            this.GWParaInterface.Add("--cyls", () => {
                gwCylLBL.Enabled = true; gwCylTB.Enabled = true;
            });
            this.GWParameters.Add("--file", (al) => {
                if (!string.IsNullOrEmpty(this.GwExistingFile)) { al.Add($"--file \"{this.GwExistingFile}\""); }
            });
            this.GWParaInterface.Add("--file", () => {
                SelectExistingFileBtn.Enabled = true;
            });
            this.gwAdditionalArgs = (al) => {
                if (!string.IsNullOrEmpty(additonalArgsTB.Text.Trim())) { al.Add(additonalArgsTB.Text.Trim()); }
            };

            // positional arguments
            this.gwNewFile = (al) =>
            {
                if(!string.IsNullOrEmpty(this.GwNewFile.Trim())) { al.Add($"\"{this.GwNewFile.Trim()}\""); }
            };
            this.gwExistingFile = (al) =>
            {
                if (!string.IsNullOrEmpty(this.GwExistingFile.Trim())) { al.Add($"\"{this.GwExistingFile.Trim()}\""); }
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

        private void PopulateArgs(string gwaction, List<string> args, Action ArgsComplete)
        {
            this.gw.GetActionHelp(gwaction, (response) =>
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    List<string> available = utilities.ExtractGroup("optional arguments:", response);

                    // get argument list directly from gw tools
                    foreach (string arg in available)
                    {
                        string sanitizedArg = utilities.ExtractDDArg(arg);
                        if(args is null)
                        {
                            if (this.GWParaInterface.ContainsKey(sanitizedArg))
                                this.GWParaInterface[sanitizedArg]();
                        }
                        else
                        {
                            if (this.GWParameters.ContainsKey(sanitizedArg))
                                this.GWParameters[sanitizedArg](args);
                        }
                    }
                    // complete the arg list with any additional details specific to the gw action
                    this.ProcessAction(gwaction, args);

                    ArgsComplete();
                }));
            });
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
                SelectNewFileBtn.Enabled = true;
                GwFileDisplay.Text = $">> {this.GwNewFile}";

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
                gwAdditionalArgs(args);

                // File is positional so it must come after the options
                gwNewFile(args);

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
                SelectExistingFileBtn.Enabled = true;
                GwFileDisplay.Text = $"<< {this.GwExistingFile}";

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
                gwAdditionalArgs(args);

                // File is positional so it must come after the options
                gwExistingFile(args);

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
                SelectNewFileBtn.Enabled = true;
                SelectExistingFileBtn.Enabled = true;
                GwFileDisplay.Text = $"{this.GwExistingFile} >> {this.GwNewFile}";

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
                gwAdditionalArgs(args);

                // File is positional so it must come after the options
                gwExistingFile(args);
                gwNewFile(args);

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
            }
            else
            {
                // options
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
            }
            else
            {
                // options
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
            }
            else
            {
                // options
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
                GwFileDisplay.Text = $"<< {this.GwExistingFile}";
            }
            else
            {
                // options
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
            }
            else
            {
                // options
                gwAdditionalArgs(args);
            }
        }
    }
}
