using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace gWeasleGUI
{
    public class utilities
    {
        /// <summary>
        /// File path dialog helper with extension handling
        /// </summary>
        /// <param name="filetype">dialog type 'existing' means look for an existing file, otherwise the file does not need to exist</param>
        /// <param name="extensions">list of possible file extensions</param>
        /// <param name="ext">starting extension</param>
        /// <param name="selectedExt">event action used for reporting the extension of freshly selected file</param>
        /// <returns>the file with full path</returns>
        public static string GetFilePath(string filetype, string[] extensions, string ext, Action<string> selectedExt)
        {
            FileDialog dialog;
            int pIdx = Array.IndexOf(extensions, ext);

            if (filetype == "existing")
            {
                dialog = new System.Windows.Forms.OpenFileDialog();
                dialog.Title = "Select Existing Image";
            }
            else
            {
                dialog = new System.Windows.Forms.SaveFileDialog();
                dialog.Title = "Select Image to Create";
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
    }
}
