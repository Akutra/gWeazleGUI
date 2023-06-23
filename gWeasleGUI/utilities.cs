using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace gWeasleGUI
{
    public class utilities
    {
        public static readonly int ERROR_BAD_ARGUMENTS = 0xA0;

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
        public static List<string> ExtractGroup(string start, string rawContent)
        {
            StringReader contentStream = new StringReader(rawContent);
            string current = string.Empty;
            List<string> values = new List<string>();

            while (current != start && contentStream.Peek() > -1)
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

        public static bool WriteJSON(string FileName, GwTools.gwCommand cmd, ILogger logger)
        {
            bool success = true;
            TextWriter writer = null;

            try
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Formatting = Formatting.Indented;
                writer = new StreamWriter(FileName);
                serializer.Serialize(writer, cmd);
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
    }
}
