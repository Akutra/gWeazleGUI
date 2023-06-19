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
        private Func<templates, object> gwAdditionalArgs;
        private Func<templates, object> gwNewFile, gwExistingFile, gwCylinders;
        private Action<string[]> gwGetFormatTypes;

        private Dictionary<string, Func<templates, object>> GWParameters;
        private Dictionary<string, List<Control>> GWParaInterface;

        //private bool ddCfgFileAvailable = true;

        /// <summary>
        /// Unified argument handling
        /// </summary>
        private void InitializeArgumentFilters()
        {
            this.GWParameters = new Dictionary<string, Func<templates, object>>();
            this.GWParaInterface = new Dictionary<string, List<Control>>();

            // arguments
            this.GWParameters.Add("--pll", (t) => {
                return ArgProcessTemplate("--pll", t);
            });
            this.GWParaInterface.Add("--pll", new List<Control>() { gwPLLPeriodTB, gwPLLPhaseTB, gwPLLPeriodLBL, gwPLLPhaseLBL });

            this.GWParameters.Add("--adjust-speed", (t) => {
                return ArgProcessTemplate("--adjust-speed", t);
            });
            this.GWParaInterface.Add("--adjust-speed", new List<Control>() { gwAdjustSpeedTB, gwAdjustSpeedLBL } );

            this.GWParameters.Add("--fake-index", (t) => {
                return ArgProcessTemplate("--fake-index", t);
            });
            this.GWParaInterface.Add("--fake-index", new List<Control>() { gwFakeIndexTB, gwFakeIndexLBL } );

            this.GWParameters.Add("--tracks", (t) => {
                return ArgProcessTemplate("--tracks", t);
            });
            this.GWParaInterface.Add("--tracks", new List<Control>() { 
                gwTSPECCylTB, gwTSPECHeadsTB, gwTSPECStepTB, gwTSPECOffsetsTB, gwTSPECSwapCB,
                gwTSPECCylLBL, gwTSPECHeadsLBL, gwTSPECStepLBL, gwTSPECOffsetsLBL });

            this.GWParameters.Add("--out-tracks", (t) => {
                return ArgProcessTemplate("--out-tracks", t);
            });
            this.GWParaInterface.Add("--out-tracks", new List<Control>() {
                gwOutTracksLBL, gwOTTSPECCylTB, gwOTTSPECHeadsTB, gwOTTSPECStepTB, gwOTTSPECOffsetsTB, gwOTTSPECSwapCB,
                gwOTTSPECCylLBL, gwOTTSPECHeadsLBL, gwOTTSPECStepLBL, gwOTTSPECOffsetsLBL });

            this.GWParameters.Add("--revs", (t) => {
                return ArgProcessTemplate("--revs", t, false, null, typeof(int));
            });
            this.GWParaInterface.Add("--revs", new List<Control>() {  gwRevsTB, gwRevsLBL });

            this.GWParameters.Add("--seek-retries", (t) => {
                return ArgProcessTemplate("--seek-retries", t);
            });
            this.GWParaInterface.Add("--seek-retries", new List<Control>() { gwSeekRetriesTB, gwSeekRetriesLBL });

            this.GWParameters.Add("--retries", (t) => {
                return ArgProcessTemplate("--retries", t);
            });
            this.GWParaInterface.Add("--retries", new List<Control>() { gwRetriesTB, gwRetriesLBL });

            this.GWParameters.Add("--diskdefs", (t) => {
                if (this.gwUseDiskDefFileCB.Checked && gwFormatTypeCB.Text.Trim().ToLower() != "default")
                    return ArgProcessTemplate("--diskdefs", t, new List<Control>() { gwDiskDefsFileTB }, true);

                return string.Empty;
            });
            this.GWParaInterface.Add("--diskdefs", new List<Control>() ); // , gwUseDiskDefFileCB ddCfgFileAvailable = true;

            this.GWParameters.Add("--format", (t) => {
                return ArgProcessTemplate("--format", t, false, "default");
            });
            this.GWParaInterface.Add("--format", new List<Control>() { gwFormatTypeLBL, gwFormatTypeCB });

            this.GWParameters.Add("--hfreq", (t) => {
                return ArgProcessTemplate("--hfreq", t);
            });
            this.GWParaInterface.Add("--hfreq", new List<Control>() { gwHFreqCB });

            this.GWParameters.Add("--raw", (t) => {
                return ArgProcessTemplate("--raw", t);
            });
            this.GWParaInterface.Add("--raw", new List<Control>() { gwRawCB });

            this.GWParameters.Add("--erase-empty", (t) => {
                return ArgProcessTemplate("--erase-empty", t);
            });
            this.GWParaInterface.Add("--erase-empty", new List<Control>() { gwEraseBlankCB });

            this.GWParameters.Add("--pre-erase", (t) => {
                return ArgProcessTemplate("--pre-erase", t);
            });
            this.GWParaInterface.Add("--pre-erase", new List<Control>() { gwPreEraseCB });

            this.GWParameters.Add("--no-verify", (t) => {
                return ArgProcessTemplate("--format", t);
            });
            this.GWParaInterface.Add("--no-verify", new List<Control>() { gwNoVerifyCB });

            this.GWParameters.Add("--motor-on", (t) => {
                return ArgProcessTemplate("--motor-on", t);
            });
            this.GWParaInterface.Add("--motor-on", new List<Control>() { gwMotorOnCB });

            this.GWParameters.Add("--force", (t) => {
                return ArgProcessTemplate("--force", t);
            });
            this.GWParaInterface.Add("--force", new List<Control>() { gwForceCB });

            this.GWParameters.Add("--drive", (t) => {
                return ArgProcessTemplate("--drive", t, false, "a");
            });
            this.GWParaInterface.Add("--drive", new List<Control>() { driveTB, driveLBL });

            this.GWParameters.Add("--cyls", (t) => {
                return ArgProcessTemplate("--cyls", t, false, null, typeof(int));
            });
            this.GWParaInterface.Add("--cyls", new List<Control>() { gwCylLBL, gwCylTB });

            this.GWParameters.Add("--passes", (t) => {
                return ArgProcessTemplate("--passes", t, false, null, typeof(int));
            });
            this.GWParaInterface.Add("--passes", new List<Control>() { gwPassesLBL, gwPassesTB });

            this.GWParameters.Add("--linger", (t) => {
                return ArgProcessTemplate("--linger", t, false, null, typeof(int));
            });
            this.GWParaInterface.Add("--linger", new List<Control>() { gwLingerLBL, gwLingerTB });

            this.GWParameters.Add("--nr", (t) => {
                return ArgProcessTemplate("--nr", t, false, null, typeof(int));
            });
            this.GWParaInterface.Add("--nr", new List<Control>() { gwNrLBL, gwNrTB });

            this.GWParameters.Add("--file", (t) => {
                return ArgProcessTemplate("--file", t, true);
            });
            this.GWParaInterface.Add("--file", new List<Control>() { SelectExistingFileBtn });

            this.gwAdditionalArgs = (t) => {
                return ArgProcessTemplate("additional-arguments", t, new List<Control>() { additonalArgsTB }, false, null, null, false);
                //if (!string.IsNullOrEmpty(additonalArgsTB.Text.Trim())) { al.Add(additonalArgsTB.Text.Trim()); }
            };

            // positional arguments
            this.gwNewFile = (t) =>
            {
                return ArgProcessTemplate("new-file", t, null, true, this.GwNewFile.Trim(), null, false);
                //if (!string.IsNullOrEmpty(this.GwNewFile.Trim())) { al.Add($"\"{this.GwNewFile.Trim()}\""); }
            };
            this.gwExistingFile = (t) =>
            {
                return ArgProcessTemplate("exisiting-file", t, null, true, this.GwExistingFile.Trim(), null, false);
                //if (!string.IsNullOrEmpty(this.GwExistingFile.Trim())) { al.Add($"\"{this.GwExistingFile.Trim()}\""); }
            };
            this.gwCylinders = (t) =>
            {
                return ArgProcessTemplate("cylinders", t, new List<Control>() { gwCylTB }, false, null, typeof(int), false);
                //int cyl = 0;
                //if (!string.IsNullOrEmpty(gwCylTB.Text.Trim()) && int.TryParse(gwCylTB.Text.Trim(), out cyl)) { al.Add($"{cyl}"); }
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

                    if (args is null && available.Where(p => p.Trim().ToLower().StartsWith("--diskdefs")).Count()>0)
                        this.gwUseDiskDefFileCB.Visible = true; // fix for older versions when --diskdefs is not available

                    // get argument list directly from gw tools
                    foreach (string arg in available)
                    {
                        string sanitizedArg = utilities.ExtractDDArg(arg);
                        if(args is null)
                        {
                            if (this.GWParaInterface.ContainsKey(sanitizedArg))
                                this.ArgVisibility(sanitizedArg, true);
                        }
                        else
                        {
                            if (this.GWParameters.ContainsKey(sanitizedArg))
                            {
                                string argValue = this.GWParameters[sanitizedArg](templates.CmdArg).ToString();
                                if (!string.IsNullOrEmpty(argValue))
                                    args.Add(argValue);
                            }
                                
                        }
                    }
                    // complete the arg list with any additional details specific to the gw action
                    this.ProcessAction(gwaction, args);

                    ArgsComplete();
                }));
            });
        }

        private void PopulateArgs(string gwaction, List<object> args)
        {
            if (args is null) return;

            //get all arguments
            foreach (var arg in GWParameters.Values)
            {
                //string sanitizedArg = utilities.ExtractDDArg(arg);

                var argValue = arg(templates.JsonObject);
                if (argValue != null)
                        args.Add(argValue);

            }
            //complete the arg list with any additional details specific to the gw action
            //this.ProcessAction(gwaction, args);
        }

        enum templates
        {
            CmdArg,
            JsonObject
        }

        private object ArgProcessTemplate(string argKey, templates templateType, bool quote = false, object def = null, Type parmType = null, bool includeKey = true)
        {
            IEnumerable<Control> argControls = GetValueFields(argKey);
            return ArgProcessTemplate(argKey, templateType, argControls, quote, def, parmType, includeKey);
        }

        private object ArgProcessTemplate(string argKey, templates templateType, IEnumerable<Control>  argControls, bool quote = false, object def = null, Type parmType = null, bool includeKey = true)
        {
            switch (templateType)
            {
                case templates.CmdArg:
                    return CmdArgTemplate(argKey, argControls, quote, def, parmType, includeKey);
                case templates.JsonObject:
                    //todo
                    break;
            }
            return null;
        }

        private string CmdArgTemplate(string argKey, IEnumerable<Control> argControls, bool quote = false, object def = null, Type parmType = null, bool includeKey = true)
        {
            string quotation = quote ? "\"" : string.Empty;
            string prefix = includeKey ? $"{argKey} " : string.Empty;

            if(argControls is null)
            {
                string value = def?.ToString();
                if( !string.IsNullOrEmpty(value) )
                    return $"{quotation}{value}{quotation}";
            }
            if( argControls.Count()==1 )
            {
                Control input = argControls.First();

                if ((input.GetType() == typeof(ComboBox) || input.GetType() == typeof(TextBox) || input.GetType() == typeof(vTextParam)) && !string.IsNullOrEmpty(input.Text.Trim()))
                {
                    if (parmType == typeof(int))
                    {
                        int defInt;
                        if (int.TryParse(input.Text.Trim(), out defInt))
                            return $"{prefix}{quotation}{input.Text}{quotation}";
                    }
                    else
                    {
                        string defValue = def?.ToString().ToLower();
                        if (input.Text.Trim().ToLower() != defValue)
                            return $"{prefix}{quotation}{input.Text}{quotation}";
                    }
                }

                if (input.GetType() == typeof(CheckBox) && ((CheckBox)input).Checked)
                {
                    return $"{prefix}".Trim();
                }
            }
            if( argControls.Count()>1 )
            {
                List<string> ctrlValues = new List<string>();

                IEnumerable<Control> tbControls = argControls.Where(c => (c.GetType() == typeof(TextBox) || c.GetType() == typeof(vTextParam)) && !string.IsNullOrEmpty(c.Text.Trim()) && !string.IsNullOrEmpty(c.Tag?.ToString().Trim()));
                if (tbControls.Count() > 0) ctrlValues.AddRange(tbControls.Select(c => $"{c.Tag.ToString().Trim()}={c.Text.Trim()}"));

                IEnumerable<Control> cbControls = argControls.Where(c => c.GetType() == typeof(CheckBox) && ((CheckBox)c).Checked && c.Tag != null);
                if (cbControls.Count() > 0) ctrlValues.AddRange(cbControls.Select(c => c.Tag.ToString().Trim()));

                string argcomposite = string.Join(":", ctrlValues.ToArray()).Trim(':');

                if (!string.IsNullOrEmpty(argcomposite))
                    return $"{argKey} {argcomposite}";
            }
            return string.Empty;
        }

        private IEnumerable<Control> GetValueFields(string argKey)
        {
            List<Control> controls = GWParaInterface[argKey] ?? new List<Control>();
            IEnumerable<Control> rt = controls.Where(c => c.GetType() == typeof(vTextParam) || c.GetType() == typeof(TextBox) || c.GetType() == typeof(CheckBox) || c.GetType() == typeof(ComboBox));
            return rt;
        }

        public void ArgVisibility(string argKey, bool visible)
        {
            List<Control> controls = GWParaInterface[argKey];
            foreach (Control control in controls)
            {
                if (control != null)
                {
                    control.Visible = visible;
                }
            }
        }

        private void AddToArgs(List<string> args, Func<templates, object> argFunc)
        {
            string addargs = argFunc(templates.CmdArg)?.ToString();
            if( !string.IsNullOrEmpty(addargs) )
                args.Add(addargs);
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
                AddToArgs(args, gwAdditionalArgs);
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
                //gwUseDiskDefFileCB.Visible = true;
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
                AddToArgs(args, gwAdditionalArgs);

                // File is positional so it must come after the options
                AddToArgs(args, gwNewFile);

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
                //gwUseDiskDefFileCB.Visible = true;
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
                AddToArgs(args, gwAdditionalArgs);

                // File is positional so it must come after the options
                AddToArgs(args, gwExistingFile);

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
                //gwUseDiskDefFileCB.Visible = true;
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
                AddToArgs(args, gwAdditionalArgs);

                // File is positional so it must come after the options
                AddToArgs(args, gwExistingFile);
                AddToArgs(args, gwNewFile);

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
                AddToArgs(args, gwAdditionalArgs);
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
                AddToArgs(args, gwAdditionalArgs);
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
                AddToArgs(args, gwAdditionalArgs);

                // positional arguments
                AddToArgs(args, gwCylinders);
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
                AddToArgs(args, gwAdditionalArgs);
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
                AddToArgs(args, gwAdditionalArgs);
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
                AddToArgs(args, gwAdditionalArgs);
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
                AddToArgs(args, gwAdditionalArgs);
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
                AddToArgs(args, gwAdditionalArgs);
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
                AddToArgs(args, gwAdditionalArgs);
            }
        }
    }
}
