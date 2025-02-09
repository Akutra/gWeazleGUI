using gWeasleGUI.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace gWeasleGUI
{
    public class utilities
    {
        public static List<IgwArgValue> ArgValueTypes = new List<IgwArgValue>() { new GwTracksValue(), new GwPLLValue(), new GwIntValue(), new GwBoolValue(), new GwStringValue(), new GwToggleValue() };

        public static readonly int ERROR_BAD_ARGUMENTS = 0xA0;

        public static string arraytodecimal(string[] numbers)
        {
            string rt = string.Empty;
            if (numbers.Length > 0)
                rt = numbers[0];
            
            if(numbers.Length > 1)
                rt += $".{numbers[1]}";

            return rt;
        }
        /// <summary>
        /// File path dialog helper with extension handling
        /// </summary>
        /// <param name="filetype">dialog type 'existing' means look for an existing file, otherwise the file does not need to exist</param>
        /// <param name="extensions">list of possible file extensions</param>
        /// <param name="ext">starting extension</param>
        /// <param name="selectedExt">event action used for reporting the extension of freshly selected file</param>
        /// <returns>the file with full path</returns>
        public static string GetFilePath(string filetype, string[] extensions, string ext, Action<string> selectedExt, bool overwriteprompt = true)
        {
            FileDialog dialog;
            int pIdx = Array.IndexOf(extensions, ext);

            if (filetype == "existing")
            {
                dialog = new System.Windows.Forms.OpenFileDialog();
                dialog.Title = "Select existing file";
            }
            else
            {
                dialog = new System.Windows.Forms.SaveFileDialog();
                dialog.Title = "Select a file";
                ((SaveFileDialog)dialog).OverwritePrompt = overwriteprompt;
                
            }

            dialog.Filter = string.Join("|", extensions);
            dialog.FilterIndex = pIdx > -1 ? pIdx+1 : 1;

            DialogResult dr = dialog.ShowDialog();

            //If selected OK then set the path
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                // get the extension from the selected filename
                string nExt = GetFileExt(dialog.FileName);
                // get the full extension name via extensions array
                int nIdx = Array.FindIndex(extensions, str => str.IndexOf(nExt)>-1);
                
                // if we have a valid selected extension alert the caller
                if (nIdx > -1 && selectedExt != null)
                {
                    selectedExt(extensions[nIdx]);
                }

                // return the file to the caller
                return dialog.FileName;
            }
            return null;
        }

        /// <summary>
        /// Extract the actual final file extension from a path
        /// </summary>
        /// <param name="filePath">file</param>
        /// <returns>ending suffix in lowercase</returns>
        public static string GetFileExt(string filePath)
        {
            string[] parts = filePath.Split('.');
            return $".{parts.Last().ToLower()}";
        }

        /// <summary>
        /// Strip file names, but keep ALL path data
        /// </summary>
        /// <param name="FileName">path or path with filename</param>
        /// <returns>only complete path data</returns>
        public static string GetAbsoluteFolder(string FileName)
        {
            if(File.Exists(FileName))
            {
                return Path.GetDirectoryName(FileName);
            }
            return FileName;
        }

        /// <summary>
        /// Extract a group/list of items from string with mixed content
        /// </summary>
        /// <param name="start">line to look for marking the start of the group</param>
        /// <param name="rawContent">full content string</param>
        /// <returns>list of items extracted</returns>
        public static List<string> ExtractGroup(string[] start, string rawContent)
        {
            StringReader contentStream = new StringReader(rawContent);
            string current = string.Empty;
            List<string> values = new List<string>();
            List<string> starters = new List<string>(start);

            while (!starters.Contains(current) && contentStream.Peek() > -1)
            {
                current = contentStream.ReadLine().Trim();
            }

            while (!string.IsNullOrEmpty(current) || contentStream.Peek() > -1)
            {
                current = contentStream.ReadLine();
                if (string.IsNullOrEmpty(current))
                    continue;

                // there may be another group after.
                // group heading should end with a colon whereas a normal item would not.
                if(current.Trim().EndsWith(":"))
                    break;

                values.Add(current);
            }
            return values;
        }

        public static string ExtractDDArg(string fullargument)
        {
            string[] _arg_temp;
            _arg_temp = fullargument.Trim().Split(' ');

            foreach (string arg in _arg_temp)
            {
                if(arg.Trim().StartsWith("--"))
                {
                    return arg;
                }
            }
            return string.Empty;
        }

        public static string MaxSizeFileName(string fileName, int length = 200)
        {
            if(fileName is null) { return string.Empty; }

            int chars = length / 8;
            if(fileName.Length > chars)
            {
                string[] parts = fileName.Split(Path.DirectorySeparatorChar);
                return $"{parts.First()}{Path.DirectorySeparatorChar}...{Path.DirectorySeparatorChar}{parts.Last()}";
            }
            return fileName;
        }

        public static bool WriteXML(string FileName, gwCommand cmd, ILogger logger)
        {
            bool success = true;
            TextWriter writer = null;

            try
            {   
                XmlSerializer serializer = new XmlSerializer(typeof(gwCommand));
                writer = new StreamWriter(FileName);
                serializer.Serialize(writer, new gwCommand());
            }
            catch (Exception ex)
            {
                // report and return false
                logger.Error($"Write object file failed", ex);
                System.Environment.Exit(ERROR_BAD_ARGUMENTS);
                success = false;
            }
            writer?.Close();

            return success;
        }

        public static T SafeChangeType<T>(object input, T defValue)
        {
            
            try
            {
                T value = (T)Convert.ChangeType(input, typeof(T));
                if(value == null ) 
                    return defValue;

                return value;
            }
            catch
            {
                return defValue;
            }
        }

        public static void SerializeProfile(string FileName, gwCommand cmd, ILogger logger)
        {
            TextWriter writer = null;

            logger.Info($"Writing command profile to file: {FileName}");

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(gwCommand));
                writer = new StreamWriter(FileName);

                serializer.Serialize(writer, cmd);
            } catch(Exception ex)
            {
                logger.Error("Writing command profile failed", ex);
            }
            writer?.Close();
            logger.Info("Completed writing command profile.");
        }

        public static gwCommand DeserializeProfile(string FileName, ILogger logger)
        {
            FileStream fs = null;
            gwCommand _gwCmd = null;

            if (File.Exists(FileName))
            {
                logger.Info($"Reading command profile from file: {FileName}");
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(gwCommand));
                    fs = new FileStream(FileName, FileMode.Open);

                    _gwCmd = (gwCommand)serializer.Deserialize(fs);
                }
                catch (Exception ex)
                {
                    logger.Error("Reading command profile failed", ex);
                    _gwCmd = null;
                }
            }
            fs?.Close();
            logger.Info("Completed reading command profile.");

            if (_gwCmd is null)
            {
                logger.Info("Empty or invalid profile, profile not loaded.");
            }

            logger.Info("Completed processing command profile.");
            return _gwCmd;
        }

        public static IgwArgValue FindClass(string ClassName)
        {
            foreach (IgwArgValue argType in ArgValueTypes)
            {
                if( argType.GetType().Name.Equals( ClassName, StringComparison.OrdinalIgnoreCase ))
                    return argType;

                //if ( argType.ClassName.Equals(ClassName, StringComparison.OrdinalIgnoreCase) )
                //    return (IgwArgValue)argType;
            }
            return null;
        }

        public static IgwArgValue ObjectFactory(string argName, object def = null, Type parmType = null)
        {
            // Value object template
            string argKey = parmType?.Name ?? argName;
            if(argKey.IndexOf("Value") == -1)
                argKey = $"Gw{argKey.Split('-').Last().Trim('-')}Value";

            // If we have a class specific to this Argument use that
            IgwArgValue arg = FindClass(argKey);
            if (arg != null) { return (IgwArgValue)arg.NewInstance(def); }

            // all other use string value
            string defValue = def?.ToString() ?? string.Empty;
            return new GwStringValue() { DefValue = defValue };
        }

        public static IgwArgValue CmdArgTemplate(string argKey, IEnumerable<Control> argControls, object def = null, object alt = null, Type parmType = null)
        {
            IgwArgValue pObj = utilities.ObjectFactory(argKey, def, parmType);
            Dictionary<string, string> parms = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);

            if (argControls is null || argControls.Count() == 0)
            {
                string value = def is null ? string.Empty : def.ToString();
                return new GwStringValue(value.Trim());
            }
            if (argControls.Count() == 1)
            {
                Control input = argControls.First();
                if (input.GetType() == typeof(CheckBox))// && ((CheckBox)input).Checked)
                {
                    if (alt is null)
                    {
                        // Bool
                        return new GwBoolValue(((CheckBox)input).Checked);
                    } else
                    {
                        // toggle will have an alternate value
                        GwToggleValue toggleValue = new GwToggleValue()
                        {
                            DefValue = def?.ToString() ?? string.Empty,
                            AltValue = alt?.ToString() ?? string.Empty,
                        };
                        toggleValue.SetToggle(((CheckBox)input).Checked);
                        return toggleValue;
                    }
                }

                parms.Add("DefValue", def?.ToString() ?? string.Empty);
                parms.Add("Value", input.Text.Trim());
                parms.Add("defined", string.IsNullOrEmpty(input.Text.Trim()) ? "false" : "true");
                if ((input.GetType() == typeof(ComboBox) || input.GetType() == typeof(TextBox) || input.GetType() == typeof(vTextParam)))// && !string.IsNullOrEmpty(input.Text.Trim()))
                {
                    if(pObj != null)
                    {
                        return (IgwArgValue)pObj.NewInstance(parms);
                    }
                }
            }
            if (argControls.Count() > 1)
            {
                IEnumerable<Control> tbControls = argControls.Where(c => (c.GetType() == typeof(TextBox) || c.GetType() == typeof(vTextParam)) && !string.IsNullOrEmpty(c.Text.Trim()) && !string.IsNullOrEmpty(c.Tag?.ToString().Trim()));
                parms.Merge(tbControls.ToDictionary(tk => tk.Tag.ToString().Trim(), tv => tv.Text.Trim()));

                IEnumerable<Control> cbControls = argControls.Where(c => c.GetType() == typeof(CheckBox) && ((CheckBox)c).Checked && c.Tag != null);
                parms.Merge(cbControls.ToDictionary(tk => tk.Tag.ToString().Trim(), tv => "true"));

                // Arg Factory will determine argument class and populate the values
                object Arg = pObj.NewInstance(parms);

                if (Arg is null) { return pObj; }

                // non-populated argument objects always return an empty string
                //if (!string.IsNullOrEmpty(Arg.ToString()))
                return Arg as IgwArgValue;
            }
            return new GwStringValue();
        }

        public static bool ArgPopulate(gwArgument arg, IEnumerable<Control> argControls)
        {
            if (argControls is null) { return false; }

            if (argControls.Count() == 1)
            {
                Control input = argControls.First();
                if (input.GetType() == typeof(CheckBox) && arg.Value.GetType() == typeof(GwBoolValue))
                {
                    ((CheckBox)input).Checked = ((GwBoolValue)arg.Value).Value;
                    return true;
                }

                if (input.GetType() == typeof(CheckBox) && arg.Value.GetType() == typeof(GwToggleValue))
                {
                    ((CheckBox)input).Checked = ((GwToggleValue)arg.Value).GetToggle();
                    return true;
                }

                if ((input.GetType() == typeof(TextBox) || input.GetType() == typeof(vTextParam)))
                {
                    Dictionary<string, string> parms = arg.Value.GetValues();
                    bool defined = parms.ContainsKey("defined") ? parms["defined"].Equals("true", StringComparison.OrdinalIgnoreCase) : true;
                    if ( defined )
                    {
                        input.Text = arg.Value.ToString() ?? string.Empty;
                    }
                    return true;
                }

                if (input.GetType() == typeof(ComboBox))
                {
                    try
                    {
                        if (string.IsNullOrEmpty(arg.Value.ToString()))
                        {
                            // Handle no-selectable value and default selection
                            if (((ComboBox)input).Items.Count > 0)
                                ((ComboBox)input).SelectedIndex = 0;
                        }
                        else
                        {
                            ((ComboBox)input).SelectedItem = arg.Value.ToString();
                        }
                        return true;
                    } catch { 
                        return false;
                    }
                }
            }
            if (argControls.Count() > 1)
            {
                Dictionary<string,string> parms = arg.Value.GetValues();

                IEnumerable<Control> tbControls = argControls.Where(c => (c.GetType() == typeof(TextBox) || c.GetType() == typeof(vTextParam)) && !string.IsNullOrEmpty(c.Tag?.ToString().Trim()));
                foreach (Control control in tbControls)
                {
                    control.Text = parms.ContainsKey(control.Tag.ToString().Trim()) ? parms[control.Tag.ToString().Trim()] : string.Empty;
                }

                IEnumerable<Control> cbControls = argControls.Where(c => c.GetType() == typeof(CheckBox) && c.Tag != null);
                foreach (Control control in cbControls)
                {
                    if (parms.ContainsKey(control.Tag.ToString().Trim()))
                        ((CheckBox)control).Checked = utilities.SafeChangeType(parms[control.Tag.ToString().Trim()], false);
                }
                return true;
            }
            return false;
        }
    }
}
