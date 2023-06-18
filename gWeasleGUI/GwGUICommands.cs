using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        private bool ddCfgFileAvailable = true;

        /// <summary>
        /// Unified argument handling
        /// </summary>
        private void InitializeArgumentFilters()
        {
            this.GWParameters = new Dictionary<string, Action<List<string>>>();
            this.GWParaInterface = new Dictionary<string, Action>();

            // arguments
            this.GWParameters.Add("--pll", (al) => {
                StringBuilder PLL = new StringBuilder();
                if (!string.IsNullOrEmpty(this.gwPLLPeriodTB.Text.Trim())) { PLL.Append(this.gwPLLPeriodTB.Text.Trim()); }
                if (!string.IsNullOrEmpty(this.gwPLLPhaseTB.Text.Trim())) { PLL.Append($":{this.gwPLLPhaseTB.Text.Trim()}"); }
                if (PLL.Length > 0) { al.Add($"--pll {PLL.ToString().Trim(':')}"); }
            });
            this.GWParaInterface.Add("--pll", () => {
                gwPLLPeriodTB.Visible = true; gwPLLPhaseTB.Visible = true;
                gwPLLPeriodLBL.Visible = true; gwPLLPhaseLBL.Visible = true;
            });
            this.GWParameters.Add("--adjust-speed", (al) => {
                if (!string.IsNullOrEmpty(this.gwAdjustSpeedTB.Text.Trim())) { al.Add($"--adjust-speed {this.gwAdjustSpeedTB.Text.Trim()}"); }
            });
            this.GWParaInterface.Add("--adjust-speed", () => {
                gwAdjustSpeedTB.Visible = true; gwAdjustSpeedLBL.Visible = true;
            });
            this.GWParameters.Add("--fake-index", (al) => {
                if (!string.IsNullOrEmpty(this.gwFakeIndexTB.Text.Trim())) { al.Add($"--fake-index {this.gwFakeIndexTB.Text.Trim()}"); }
            });
            this.GWParaInterface.Add("--fake-index", () => {
                gwFakeIndexTB.Visible = true; gwFakeIndexLBL.Visible = true;
            });
            this.GWParameters.Add("--tracks", (al) => {
                StringBuilder TSPEC = new StringBuilder();
                if (!string.IsNullOrEmpty(this.gwTSPECCylTB.Text.Trim())) { TSPEC.Append(this.gwTSPECCylTB.Text.Trim()); }
                if (!string.IsNullOrEmpty(this.gwTSPECHeadsTB.Text.Trim())) { TSPEC.Append($":{this.gwTSPECHeadsTB.Text.Trim()}"); }
                if (!string.IsNullOrEmpty(this.gwTSPECStepTB.Text.Trim())) { TSPEC.Append($":{this.gwTSPECStepTB.Text.Trim()}"); }
                if (!string.IsNullOrEmpty(this.gwTSPECOffsetsTB.Text.Trim())) { TSPEC.Append($":{this.gwTSPECOffsetsTB.Text.Trim()}"); }
                if(this.gwTSPECSwapCB.Checked) { TSPEC.Append(":hswap"); }
                if(TSPEC.Length>0) { al.Add($"--tracks {TSPEC.ToString().Trim(':')}"); }
            });
            this.GWParaInterface.Add("--tracks", () => {
                gwTSPECCylTB.Visible = true; gwTSPECHeadsTB.Visible = true; gwTSPECStepTB.Visible = true; gwTSPECOffsetsTB.Visible = true; gwTSPECSwapCB.Visible = true;
                gwTSPECCylLBL.Visible = true; gwTSPECHeadsLBL.Visible = true; gwTSPECStepLBL.Visible = true; gwTSPECOffsetsLBL.Visible = true;
            });
            this.GWParameters.Add("--out-tracks", (al) => {
                StringBuilder TSPEC = new StringBuilder();
                if (!string.IsNullOrEmpty(this.gwOTTSPECCylTB.Text.Trim())) { TSPEC.Append(this.gwOTTSPECCylTB.Text.Trim()); }
                if (!string.IsNullOrEmpty(this.gwOTTSPECHeadsTB.Text.Trim())) { TSPEC.Append($":{this.gwOTTSPECHeadsTB.Text.Trim()}"); }
                if (!string.IsNullOrEmpty(this.gwOTTSPECStepTB.Text.Trim())) { TSPEC.Append($":{this.gwOTTSPECStepTB.Text.Trim()}"); }
                if (!string.IsNullOrEmpty(this.gwOTTSPECOffsetsTB.Text.Trim())) { TSPEC.Append($":{this.gwOTTSPECOffsetsTB.Text.Trim()}"); }
                if (this.gwOTTSPECSwapCB.Checked) { TSPEC.Append(":hswap"); }
                if (TSPEC.Length > 0) { al.Add($"--out-tracks {TSPEC.ToString().Trim(':')}"); }
            });
            this.GWParaInterface.Add("--out-tracks", () => {
                gwOutTracksLBL.Visible = true;
                gwOTTSPECCylTB.Visible = true; gwOTTSPECHeadsTB.Visible = true; gwOTTSPECStepTB.Visible = true; gwOTTSPECOffsetsTB.Visible = true; gwOTTSPECSwapCB.Visible = true;
                gwOTTSPECCylLBL.Visible = true; gwOTTSPECHeadsLBL.Visible = true; gwOTTSPECStepLBL.Visible = true; gwOTTSPECOffsetsLBL.Visible = true;
            });
            this.GWParameters.Add("--revs", (al) => {
                if (!string.IsNullOrEmpty(this.gwRevsTB.Text.Trim())) { al.Add($"--revs {this.gwRevsTB.Text.Trim()}"); }
            });
            this.GWParaInterface.Add("--revs", () => {
                gwRevsTB.Visible = true; gwRevsLBL.Visible = true;
            });
            this.GWParameters.Add("--seek-retries", (al) => {
                if (!string.IsNullOrEmpty(this.gwSeekRetriesTB.Text.Trim())) { al.Add($"--seek-retries {this.gwSeekRetriesTB.Text.Trim()}"); }
            });
            this.GWParaInterface.Add("--seek-retries", () => {
                gwSeekRetriesTB.Visible = true; gwSeekRetriesLBL.Visible = true;
            });
            this.GWParameters.Add("--retries", (al) => {
                if (!string.IsNullOrEmpty(this.gwRetriesTB.Text.Trim())) { al.Add($"--retries {this.gwRetriesTB.Text.Trim()}"); }
            });
            this.GWParaInterface.Add("--retries", () => {
                gwRetriesTB.Visible = true; gwRetriesLBL.Visible = true;
            });
            this.GWParameters.Add("--diskdefs", (al) => {
                if (!string.IsNullOrEmpty(this.GwDiskDefsFile) && this.gwUseDiskDefFileCB.Checked) { al.Add($"--diskdefs \"{this.GwDiskDefsFile}\""); }
            });
            this.GWParaInterface.Add("--diskdefs", () => {
                this.gwUseDiskDefFileCB.Visible = true; this.ddCfgFileAvailable = true;
            });
            this.GWParameters.Add("--format", (al) => { 
                if (gwFormatTypeCB.SelectedItem.ToString().Trim().ToLower().IndexOf("default") == -1) { al.Add($"--format {gwFormatTypeCB.SelectedItem}"); } 
            });
            this.GWParaInterface.Add("--format", () => {
                gwFormatTypeLBL.Visible = true; gwFormatTypeCB.Visible = true;
            });
            this.GWParameters.Add("--hfreq", (al) => {
                if (gwHFreqCB.Checked) { al.Add($"--hfreq"); }
            });
            this.GWParaInterface.Add("--hfreq", () => {
                gwHFreqCB.Visible = true;
            });
            this.GWParameters.Add("--raw", (al) => { 
                if (gwRawCB.Checked) { al.Add($"--raw"); } 
            });
            this.GWParaInterface.Add("--raw", () => {
                gwRawCB.Visible = true;
            });
            this.GWParameters.Add("--erase-empty", (al) => { 
                if (gwEraseBlankCB.Checked) { al.Add("--erase-empty"); } 
            });
            this.GWParaInterface.Add("--erase-empty", () => {
                gwEraseBlankCB.Visible = true;
            });
            this.GWParameters.Add("--pre-erase", (al) => {
                if (gwPreEraseCB.Checked) { al.Add("--pre-erase"); }
            });
            this.GWParaInterface.Add("--pre-erase", () => {
                gwPreEraseCB.Visible = true;
            });
            this.GWParameters.Add("--no-verify", (al) => { 
                if (gwNoVerifyCB.Checked) { al.Add("--no-verify"); } 
            });
            this.GWParaInterface.Add("--no-verify", () => {
                gwNoVerifyCB.Visible = true;
            });
            this.GWParameters.Add("--motor-on", (al) => {
                if (gwMotorOnCB.Checked) { al.Add("--motor-on"); }
            });
            this.GWParaInterface.Add("--motor-on", () => {
                gwMotorOnCB.Visible = true;
            });
            this.GWParameters.Add("--force", (al) => {
                if (gwForceCB.Checked) { al.Add("--force"); }
            });
            this.GWParaInterface.Add("--force", () => {
                gwForceCB.Visible = true;
            });
            this.GWParameters.Add("--drive", (al) => { 
                if (!string.IsNullOrEmpty(driveTB.Text.Trim()) && driveTB.Text.Trim().ToLower() != "a") { al.Add($"--drive {driveTB.Text.Trim()}"); } 
            });
            this.GWParaInterface.Add("--drive", () => {
                driveTB.Visible = true; driveLBL.Visible = true;
            });
            this.GWParameters.Add("--cyls", (al) => {
                int cyl = 0; if(!string.IsNullOrEmpty(gwCylTB.Text.Trim()) && int.TryParse(gwCylTB.Text.Trim(), out cyl)) { al.Add($"--cyls {cyl}"); }
            });
            this.GWParaInterface.Add("--cyls", () => {
                gwCylLBL.Visible = true; gwCylTB.Visible = true;
            });
            this.GWParameters.Add("--passes", (al) => {
                int passes = 0; if (!string.IsNullOrEmpty(gwPassesTB.Text.Trim()) && int.TryParse(gwPassesTB.Text.Trim(), out passes)) { al.Add($"--passes {passes}"); }
            });
            this.GWParaInterface.Add("--passes", () => {
                gwPassesLBL.Visible = true; gwPassesTB.Visible = true;
            });
            this.GWParameters.Add("--linger", (al) => {
                int linger = 0; if (!string.IsNullOrEmpty(gwLingerTB.Text.Trim()) && int.TryParse(gwLingerTB.Text.Trim(), out linger)) { al.Add($"--linger {linger}"); }
            });
            this.GWParaInterface.Add("--linger", () => {
                gwLingerLBL.Visible = true; gwLingerTB.Visible = true;
            });
            this.GWParameters.Add("--nr", (al) => {
                int nr = 0; if (!string.IsNullOrEmpty(gwNrTB.Text.Trim()) && int.TryParse(gwNrTB.Text.Trim(), out nr)) { al.Add($"--nr {nr}"); }
            });
            this.GWParaInterface.Add("--nr", () => {
                gwNrLBL.Visible = true; gwNrTB.Visible = true;
            });
            this.GWParameters.Add("--file", (al) => {
                if (!string.IsNullOrEmpty(this.GwExistingFile)) { al.Add($"--file \"{this.GwExistingFile}\""); }
            });
            this.GWParaInterface.Add("--file", () => {
                SelectExistingFileBtn.Visible = true;
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

                    if (args is null)
                        this.ddCfgFileAvailable = false; // fix for older versions when --diskdefs is not available

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

                // available gw format types
                gwFormatTypeCB.Items.Clear();
                gwFormatTypeCB.Items.Add("default");

                string[] fileDD = GetDiskFormats();
                if (fileDD != null && fileDD.Count() > 0)
                    gwGetFormatTypes(fileDD);
                else
                    this.gw.GetFormatTypes("read", gwGetFormatTypes);

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

                // available gw format types
                gwFormatTypeCB.Items.Clear();
                gwFormatTypeCB.Items.Add("default");

                string[] fileDD = GetDiskFormats();
                if (fileDD != null && fileDD.Count() > 0)
                    gwGetFormatTypes(fileDD);
                else
                    this.gw.GetFormatTypes("write", gwGetFormatTypes);

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

                // available gw format types
                gwFormatTypeCB.Items.Clear();
                gwFormatTypeCB.Items.Add("default");

                string[] fileDD = GetDiskFormats();
                if (fileDD != null && fileDD.Count() > 0)
                    gwGetFormatTypes(fileDD);
                else
                    this.gw.GetFormatTypes("convert", gwGetFormatTypes);
                
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
                // positional argument is not handled by auto parms
                gwCylLBL.Visible = true;
                gwCylTB.Visible = true;
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
                SelectExistingFileBtn.Enabled = true;
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
