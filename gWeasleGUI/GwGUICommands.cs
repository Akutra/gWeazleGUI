using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace gWeasleGUI
{
    public partial class gWeazleFrm : Form
    {
        private Func<templates, IgwArgValue> gwAdditionalArgs;
        private Func<templates, IgwArgValue> gwNewFile, gwExistingFile, gwCylinders;
        private Action<string[]> gwGetFormatTypes;

        private Dictionary<string, Func<templates, IgwArgValue>> GWParameters;
        private Dictionary<string, List<Control>> GWParaInterface;

        // some statics for consistency
        public static string AdditionalArgsName = "additional-arguments";
        public static string NewFileArgName = "new-file";
        public static string ExistingFileArgName = "exisiting-file";
        public static string CylindersArgName = "cylinders";
        //private bool ddCfgFileAvailable = true;

        /// <summary>
        /// Unified argument handling
        /// </summary>
        private void InitializeArgumentFilters()
        {
            this.GWParameters = new Dictionary<string, Func<templates, IgwArgValue>>();
            this.GWParaInterface = new Dictionary<string, List<Control>>();

            // arguments
            //this.ArgValueTypes = new List<IgwArgValue>() { new GwTracksValue(), new GwPLLValue(), new GwIntValue(), new GwBoolValue(), new GwStringValue() };
            this.GWParameters.Add("--pll", (t) => {
                return ArgProcessTemplate(argKey: "--pll", templateType: t);
            });
            this.GWParaInterface.Add("--pll", new List<Control>() { gwPLLPeriodTB, gwPLLPhaseTB, gwPLLPeriodLBL, gwPLLPhaseLBL, gwPLLLowPassLBL, gwPLLLowPassTB });

            this.GWParameters.Add("--adjust-speed", (t) => {
                return ArgProcessTemplate(argKey: "--adjust-speed", templateType: t);
            });
            this.GWParaInterface.Add("--adjust-speed", new List<Control>() { gwAdjustSpeedTB, gwAdjustSpeedLBL } );

            this.GWParameters.Add("--fake-index", (t) => {
                return ArgProcessTemplate(argKey: "--fake-index", templateType: t);
            });
            this.GWParaInterface.Add("--fake-index", new List<Control>() { gwFakeIndexTB, gwFakeIndexLBL } );

            this.GWParameters.Add("--tracks", (t) => {
                return ArgProcessTemplate(argKey: "--tracks", templateType: t);
            });
            this.GWParaInterface.Add("--tracks", new List<Control>() { 
                gwTSPECCylTB, gwTSPECHeadsTB, gwTSPECStepTB, gwTSPECOffsetsTB, gwTSPECSwapCB,
                gwTSPECCylLBL, gwTSPECHeadsLBL, gwTSPECStepLBL, gwTSPECOffsetsLBL });

            this.GWParameters.Add("--out-tracks", (t) => {
                return ArgProcessTemplate(argKey: "--out-tracks", templateType: t);
            });
            this.GWParaInterface.Add("--out-tracks", new List<Control>() {
                gwOutTracksLBL, gwOTTSPECCylTB, gwOTTSPECHeadsTB, gwOTTSPECStepTB, gwOTTSPECOffsetsTB, gwOTTSPECSwapCB,
                gwOTTSPECCylLBL, gwOTTSPECHeadsLBL, gwOTTSPECStepLBL, gwOTTSPECOffsetsLBL });

            this.GWParameters.Add("--revs", (t) => {
                return ArgProcessTemplate(argKey: "--revs", templateType: t, parmType: typeof(GwIntValue));
            });
            this.GWParaInterface.Add("--revs", new List<Control>() {  gwRevsTB, gwRevsLBL });

            this.GWParameters.Add("--seek-retries", (t) => {
                return ArgProcessTemplate(argKey: "--seek-retries", templateType: t, parmType: typeof(GwIntValue));
            });
            this.GWParaInterface.Add("--seek-retries", new List<Control>() { gwSeekRetriesTB, gwSeekRetriesLBL });

            this.GWParameters.Add("--retries", (t) => {
                return ArgProcessTemplate(argKey: "--retries", templateType: t, def: (int)3, parmType: typeof(GwIntValue));
            });
            this.GWParaInterface.Add("--retries", new List<Control>() { gwRetriesTB, gwRetriesLBL });

            this.GWParameters.Add("--diskdefs", (t) => {
                if (this.gwUseDiskDefFileCB.Checked && gwFormatTypeCB.Text.Trim().ToLower() != "default")
                    return ArgProcessTemplate(argKey: "--diskdefs", templateType: t, argControls: null, def: this.GwDiskDefsFile.Trim());

                return new GwStringValue();
            });
            this.GWParaInterface.Add("--diskdefs", new List<Control>() ); // , gwUseDiskDefFileCB ddCfgFileAvailable = true;

            this.GWParameters.Add("--format", (t) => {
                return ArgProcessTemplate(argKey: "--format", templateType: t, def: "default");
            });
            this.GWParaInterface.Add("--format", new List<Control>() { gwFormatTypeLBL, gwFormatTypeCB });

            this.GWParameters.Add("--hfreq", (t) => {
                return ArgProcessTemplate(argKey: "--hfreq", templateType: t);
            });
            this.GWParaInterface.Add("--hfreq", new List<Control>() { gwHFreqCB });

            this.GWParameters.Add("--raw", (t) => {
                return ArgProcessTemplate(argKey: "--raw", templateType: t);
            });
            this.GWParaInterface.Add("--raw", new List<Control>() { gwRawCB });

            this.GWParameters.Add("--erase-empty", (t) => {
                return ArgProcessTemplate(argKey: "--erase-empty", templateType: t);
            });
            this.GWParaInterface.Add("--erase-empty", new List<Control>() { gwEraseBlankCB });

            this.GWParameters.Add("--pre-erase", (t) => {
                return ArgProcessTemplate(argKey: "--pre-erase", templateType: t);
            });
            this.GWParaInterface.Add("--pre-erase", new List<Control>() { gwPreEraseCB });

            this.GWParameters.Add("--no-verify", (t) => {
                return ArgProcessTemplate(argKey: "--no-verify", templateType: t);
            });
            this.GWParaInterface.Add("--no-verify", new List<Control>() { gwNoVerifyCB });

            this.GWParameters.Add("--motor-on", (t) => {
                return ArgProcessTemplate(argKey: "--motor-on", templateType: t);
            });
            this.GWParaInterface.Add("--motor-on", new List<Control>() { gwMotorOnCB });

            this.GWParameters.Add("--force", (t) => {
                return ArgProcessTemplate(argKey: "--force", templateType: t);
            });
            this.GWParaInterface.Add("--force", new List<Control>() { gwForceCB });

            this.GWParameters.Add("--no-clobber", (t) => {
                return ArgProcessTemplate(argKey: "--no-clobber", templateType: t);
            });
            this.GWParaInterface.Add("--no-clobber", new List<Control>() { gwNoClobberCB });

            this.GWParameters.Add("--hard-sectors", (t) => {
                return ArgProcessTemplate(argKey: "--hard-sectors", templateType: t);
            });
            this.GWParaInterface.Add("--hard-sectors", new List<Control>() { gwHardSectorsCB });

            this.GWParameters.Add("--drive", (t) => {
                return ArgProcessTemplate(argKey: "--drive", templateType: t, def: "a");
            });
            this.GWParaInterface.Add("--drive", new List<Control>() { driveTB, driveLBL });

            this.GWParameters.Add("--cyls", (t) => {
                return ArgProcessTemplate(argKey: "--cyls", templateType: t, def: (int)80, parmType: typeof(GwIntValue));
            });
            this.GWParaInterface.Add("--cyls", new List<Control>() { gwCylLBL, gwCylTB });

            this.GWParameters.Add("--passes", (t) => {
                return ArgProcessTemplate(argKey: "--passes", templateType: t, def: (int)3, parmType: typeof(GwIntValue));
            });
            this.GWParaInterface.Add("--passes", new List<Control>() { gwPassesLBL, gwPassesTB });

            this.GWParameters.Add("--linger", (t) => {
                return ArgProcessTemplate(argKey: "--linger", templateType: t, def: (int)100, parmType: typeof(GwIntValue));
            });
            this.GWParaInterface.Add("--linger", new List<Control>() { gwLingerLBL, gwLingerTB });

            this.GWParameters.Add("--nr", (t) => {
                return ArgProcessTemplate(argKey: "--nr", templateType: t, def: (int)1, parmType: typeof(GwIntValue));
            });
            this.GWParaInterface.Add("--nr", new List<Control>() { gwNrLBL, gwNrTB });

            // currently the Update command is the only command with this
            this.GWParameters.Add("--file", (t) => {
                return ArgProcessTemplate(argKey: "--file", templateType: t, argControls: null, def: this.GwUpdateFile.Trim());
            });

            this.GWParaInterface.Add("--file", new List<Control>() { SelectExistingFileBtn });

            this.GWParameters.Add("--dd", (t) => {
                return ArgProcessTemplate(argKey: "--dd", templateType: t, def: "H", alt: "L");
            });
            this.GWParaInterface.Add("--dd", new List<Control>() { gwDDcb });

            this.GWParameters.Add("--densel", (t) => {
                return ArgProcessTemplate(argKey: "--dd", templateType: t, def: "H", alt: "L");
            });
            this.GWParaInterface.Add("--densel", new List<Control>() { gwDDcb });

            this.GWParameters.Add("--reverse", (t) => {
                return ArgProcessTemplate(argKey: "--reverse", templateType: t);
            });
            this.GWParaInterface.Add("--reverse", new List<Control>() { gwReverseCB });

            this.GWParameters.Add("--tag", (t) => {
                return ArgProcessTemplate(argKey: "--tag", templateType: t);
            });
            this.GWParaInterface.Add("--tag", new List<Control>() { gwTagTB, gwTagLBL });

            this.GWParameters.Add("--delays", (t) => {
                return ArgProcessTemplate(argKey: "--delays", templateType: t);
            });
            this.GWParaInterface.Add("--delays", new List<Control>() { gwDelaysCB });

            this.gwAdditionalArgs = (t) =>
            {
                return ArgProcessTemplate(argKey: AdditionalArgsName, templateType: t, argControls: new List<Control>() { additonalArgsTB });
            };
            this.GWParaInterface.Add(AdditionalArgsName, new List<Control>() { additonalArgsTB });

            // positional arguments
            this.gwNewFile = (t) =>
            {
                return ArgProcessTemplate(argKey: NewFileArgName, templateType: t, argControls: null, def: this.GwNewFile.Trim());
            };
            this.gwExistingFile = (t) =>
            {
                return ArgProcessTemplate(argKey: ExistingFileArgName, templateType: t, argControls: null, def: this.GwExistingFile.Trim());
            };
            this.gwCylinders = (t) =>
            {
                return ArgProcessTemplate(argKey: CylindersArgName, templateType: t, argControls: new List<Control>() { gwCylTB }, parmType: typeof(GwIntValue));
            };

            // Callback for loading the format types directly from gw into the interface
            // - action to handle results from async call to gw
            gwGetFormatTypes = (t) =>
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    string existing_selection = string.IsNullOrEmpty(gwFormatTypeCB.Text) ? this.ConfigManager.ConfigData.LastFormatType : gwFormatTypeCB.Text;

                    // available gw format types
                    gwFormatTypeCB.Items.Clear();
                    gwFormatTypeCB.Items.Add("default");
                    gwFormatTypeCB.Items.AddRange(t);
                    if (gwFormatTypeCB.Items.Contains(existing_selection))
                    {
                        gwFormatTypeCB.SelectedIndex = gwFormatTypeCB.Items.IndexOf(existing_selection);
                    }
                    else
                    {
                        gwFormatTypeCB.SelectedIndex = 0;
                    }
                }));
            };
        }

        private void PopulateArgs(string gwaction, List<gwArgument> args, Action ArgsComplete)
        {
            this.gw.GetActionHelp(gwaction, (response) =>
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    List<string> available = utilities.ExtractGroup(new[] { "optional arguments:", "options:" }, response);

                    // fix for older versions when --diskdefs is not available
                    if (args is null && available.Where(p => p.Trim().ToLower().StartsWith("--diskdefs")).Count()>0)
                        this.gwUseDiskDefFileCB.Visible = true;

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
                                IgwArgValue argValue = this.GWParameters[sanitizedArg](templates.CmdArg);
                                if (!string.IsNullOrEmpty(argValue.ToString()))
                                    args.Add(new gwArgument(sanitizedArg,argValue));
                            }
                                
                        }
                    }

                    // Load the accepted suffixes if provided by GWTools
                    this.gw.LoadAcceptedSuffixes(response);

                    // complete the arg list with any additional details specific to the gw action
                    this.ProcessAction(gwaction, args);

                    ArgsComplete();
                }));
            });
        }

        private void PopulateArgs(string gwaction, List<gwArgument> args)
        {
            //get all arguments
            foreach (string arg in GWParameters.Keys)
            {
                if (args is null)
                {
                    if (this.GWParaInterface.ContainsKey(arg))
                        this.ArgVisibility(arg, true);
                }
                else
                {
                    if (this.GWParameters.ContainsKey(arg))
                    {
                        IgwArgValue argValue = this.GWParameters[arg](templates.CmdArg);

                        // disk defs has no controls, for a complete list we need to intercept it
                        if (arg.Equals("--diskdefs", StringComparison.OrdinalIgnoreCase) && 
                            !string.IsNullOrEmpty(this.GwDiskDefsFile) )
                        {
                            argValue = new GwStringValue(this.GwDiskDefsFile);
                        }

                        args.Add(new gwArgument(arg, argValue));
                    }

                }
            }
            //complete the arg list with any additional details specific to the gw action
            this.ProcessAction(gwaction, args);
        }

        enum templates
        {
            CmdArg,
            ObjectType
        }

        /// <summary>
        /// Argument processing via a template using the built in control list
        /// - the argkey will determine the control list
        /// </summary>
        /// <param name="argKey"></param>
        /// <param name="templateType"></param>
        /// <param name="def"></param>
        /// <param name="parmType"></param>
        /// <returns></returns>
        private IgwArgValue ArgProcessTemplate(string argKey, templates templateType, object def = null, object alt = null, Type parmType = null)
        {
            IEnumerable<Control> argControls = GetValueFields(argKey);
            return ArgProcessTemplate(argKey, templateType, argControls, def, alt, parmType);
        }

        /// <summary>
        /// Argument processing via a template using the provided control list
        /// - the control list is used to populate the values with the content of the System.Windows.Forms.Controls
        /// - a null control list will populate it with the default value
        /// </summary>
        /// <param name="argKey">key to determine argument type</param>
        /// <param name="templateType">template action</param>
        /// <param name="argControls">control list for argument content</param>
        /// <param name="def">default value</param>
        /// <param name="parmType">optional addtional parameter details (i.e. int, string)</param>
        /// <returns></returns>
        private IgwArgValue ArgProcessTemplate(string argKey, templates templateType, IEnumerable<Control>  argControls, object def = null, object alt = null, Type parmType = null)
        {
            switch (templateType)
            {
                case templates.CmdArg:
                    return utilities.CmdArgTemplate(argKey, argControls, def, alt, parmType);
                //case templates.ObjectType:
                //    return utilities.ObjectFactory(argKey, def, parmType);
            }
            return null;
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

        private void AddToArgs(string ArgName, List<gwArgument> args, Func<templates, IgwArgValue> argFunc, bool positional = false)
        {
            IgwArgValue addargs = argFunc(templates.CmdArg);
            if (!string.IsNullOrEmpty(addargs?.ToString()))
                args.Add(new gwArgument(ArgName, addargs, positional));
        }

        public void UIUpdateDiskFormats(string gwCmd)
        {
            string[] fileDD = GetDiskFormats();
            if (fileDD != null && fileDD.Count() > 0)
            {
                gwGetFormatTypes(fileDD);
            }
            else
            {
                if (!string.IsNullOrEmpty(gwCmd))
                {
                    this.gw.GetFormatTypes(gwCmd, gwGetFormatTypes);
                }
            }
        }

        /// <summary>
        /// gw info
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Info(List<gwArgument> args = null)
        {
            if (args is null)
            {
                // interface

            } else
            {
                // options
                AddToArgs(AdditionalArgsName, args, gwAdditionalArgs);
            }
        }

        /// <summary>
        /// gw read
        /// TODO: gui access to additional args
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Read(List<gwArgument> args = null)
        {
            if (args is null)
            {
                // interface
                SelectNewFileBtn.Enabled = true;
                //gwUseDiskDefFileCB.Visible = true;
                GwFileDisplay.Text = $">> {this.GwNewFile}";
                gweazleTips.SetToolTip(GwFileDisplay, GwFileDisplay.Text);

                //UIUpdateDiskFormats("read");

            } else
            {
                // options
                AddToArgs(AdditionalArgsName, args, gwAdditionalArgs);

                // File is positional so it must come after the options
                AddToArgs(NewFileArgName, args, gwNewFile, true);

                // update config file for options that persist
                UpdateFormatConfig();
            }
        }

        /// <summary>
        /// gw write
        /// TODO: gui access to additional args
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Write(List<gwArgument> args = null)
        {
            if (args is null)
            {
                // interface
                SelectExistingFileBtn.Enabled = true;
                //gwUseDiskDefFileCB.Visible = true;
                GwFileDisplay.Text = $"<< {this.GwExistingFile}";
                gweazleTips.SetToolTip(GwFileDisplay, GwFileDisplay.Text);

                //UIUpdateDiskFormats("write");

            } else
            {
                // options
                AddToArgs(AdditionalArgsName, args, gwAdditionalArgs);

                // File is positional so it must come after the options
                AddToArgs(ExistingFileArgName, args, gwExistingFile, true);

                // update config file for options that persist
                UpdateFormatConfig();
            }
        }

        /// <summary>
        /// gw convert
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Convert(List<gwArgument> args = null)
        {
            if (args is null)
            {
                // interface
                SelectNewFileBtn.Enabled = true;
                SelectExistingFileBtn.Enabled = true;
                //gwUseDiskDefFileCB.Visible = true;
                GwFileDisplay.Text = $"{this.GwExistingFile} >> {this.GwNewFile}";
                gweazleTips.SetToolTip(GwFileDisplay, GwFileDisplay.Text);

                //UIUpdateDiskFormats("convert");
                
            }
            else
            {
                // options
                AddToArgs(AdditionalArgsName, args, gwAdditionalArgs);

                // File is positional so it must come after the options
                AddToArgs(ExistingFileArgName, args, gwExistingFile, true);
                AddToArgs(NewFileArgName, args, gwNewFile, true);

                // update config file for options that persist
                UpdateFormatConfig();
            }
        }

        /// <summary>
        /// gw erase
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Erase(List<gwArgument> args = null)
        {
            if (args is null)
            {
                // interface
            }
            else
            {
                // options
                AddToArgs(AdditionalArgsName, args, gwAdditionalArgs);
            }
        }

        /// <summary>
        /// gw clean
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Clean(List<gwArgument> args = null)
        {
            if (args is null)
            {
                // interface
            }
            else
            {
                // options
                AddToArgs(AdditionalArgsName, args, gwAdditionalArgs);
            }
        }

        /// <summary>
        /// gw seek
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Seek(List<gwArgument> args = null)
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
                AddToArgs(AdditionalArgsName, args, gwAdditionalArgs);

                // positional arguments
                AddToArgs(CylindersArgName, args, gwCylinders, true);
            }
        }

        /// <summary>
        /// gw delays
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Delays(List<gwArgument> args = null)
        {
            if (args is null)
            {
                // interface
            }
            else
            {
                // options
                AddToArgs(AdditionalArgsName, args, gwAdditionalArgs);
            }
        }

        /// <summary>
        /// gw update
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Update(List<gwArgument> args = null)
        {
            if (args is null)
            {
                // interface
                GwFileDisplay.Text = $"<< {this.GwUpdateFile}";
                SelectExistingFileBtn.Enabled = true;
            }
            else
            {
                // options
                AddToArgs(AdditionalArgsName, args, gwAdditionalArgs);
            }
        }

        /// <summary>
        /// gw pin
        /// TODO: better implementation
        /// - currently requires manual input into additional args
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Pin(List<gwArgument> args = null)
        {
            if (args is null)
            {
                // interface
            }
            else
            {
                // options
                AddToArgs(AdditionalArgsName, args, gwAdditionalArgs);
            }
        }

        /// <summary>
        /// gw reset
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Reset(List<gwArgument> args = null)
        {
            if (args is null)
            {
                // interface
            }
            else
            {
                // options
                AddToArgs(AdditionalArgsName, args, gwAdditionalArgs);
            }
        }

        /// <summary>
        /// gw bandwidth
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Bandwidth(List<gwArgument> args = null)
        {
            if (args is null)
            {
                // interface
            }
            else
            {
                // options
                AddToArgs(AdditionalArgsName, args, gwAdditionalArgs);
            }
        }

        /// <summary>
        /// gw rpm
        /// </summary>
        /// <param name="args">optional argument list to populate</param>
        private void GwGUI_Rpm(List<gwArgument> args = null)
        {
            if (args is null)
            {
                // interface
            }
            else
            {
                // options
                AddToArgs(AdditionalArgsName, args, gwAdditionalArgs);
            }
        }
    }
}
