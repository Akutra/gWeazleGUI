using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static gWeasleGUI.GwDiskDefs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace gWeasleGUI
{
    public partial class gWeazleFrm : Form
    {
        private GwDiskDefs gwDD;

        private Dictionary<string, Func<GwDiskDefs.DiskDefinition, bool>> GWDiskDefPara;
        private Dictionary<string, Func<GwDiskDefs.TrackDefinition, bool>> GWDiskDefTrackPara;
        private Dictionary<string, Action<GwDiskDefs.TrackDefinition>> GWTrackDefDisplay;

        private GwDiskDefs.DiskDefinition CurrentDiskDef = new GwDiskDefs.DiskDefinition();
        private Dictionary<string, GwDiskDefs.TrackDefinition> ddTracks = new Dictionary<string, GwDiskDefs.TrackDefinition>();

        // at least we will have the correct characters
        public static readonly Regex TrackValidator = new Regex(@"^[0-9*-.]+$");
        public static readonly Regex FormatValidator = new Regex(@"^[0-9a-z_.]+$");
        public static readonly Regex BpsValidator = new Regex(@"^[0-9,*-]+$");

        /// <summary>
        /// Unified parameter handling
        /// </summary>
        private void InitializeDDParaHandling()
        {
            GWDiskDefPara = new Dictionary<string, Func<GwDiskDefs.DiskDefinition, bool>>();
            GWDiskDefTrackPara = new Dictionary<string, Func<GwDiskDefs.TrackDefinition, bool>>();
            int c;

            gwDD = new GwDiskDefs(logger, this.ActionStart, this.ActionComplete, this.ConfigManager.ConfigData.LastDiskDefsCfgFile);

            // disk def parms
            GWDiskDefPara.Add("name", (dd) =>
            {
                diskDefNameTB.ValidationFailure = !FormatValidator.IsMatch(diskDefNameTB.Text.Trim());
                dd.Name = diskDefNameTB.Text.Trim();
                return diskDefNameTB.ValidationFailure;
            });
            GWDiskDefPara.Add("cyls", (dd) =>
            {
                gwDDCylsTB.ValidationFailure = string.IsNullOrEmpty(gwDDCylsTB.Text.Trim()) || !NumericValidator(gwDDCylsTB.Text.Trim());
                dd.Cylinders = gwDDCylsTB.Text.Trim();
                return gwDDCylsTB.ValidationFailure;
            });
            GWDiskDefPara.Add("heads", (dd) =>
            {
                gwDDHeadsTB.ValidationFailure = string.IsNullOrEmpty(gwDDCylsTB.Text.Trim()) || !NumericValidator(gwDDHeadsTB.Text.Trim(), 2);
                dd.Heads = gwDDHeadsTB.Text.Trim();
                return gwDDHeadsTB.ValidationFailure;
            });
            GWDiskDefPara.Add("step", (dd) =>
            {
                gwDDStepTB.ValidationFailure = !NumericValidator(gwDDStepTB.Text.Trim(), 4);
                dd.step = gwDDStepTB.Text.Trim();
                return gwDDStepTB.ValidationFailure;
            });

            // track def parms
            GWDiskDefTrackPara.Add("tracks", (td) =>
            {
                gwDDtracksTB.ValidationFailure = !(string.IsNullOrEmpty(gwDDtracksTB.Text.Trim()) || TrackValidator.IsMatch(gwDDtracksTB.Text.Trim()));
                td.Tracks = gwDDtracksTB.Text.Trim();
                return gwDDtracksTB.ValidationFailure;
            });
            GWDiskDefTrackPara.Add("trackformat", (td) =>
            {
                gwDDformatTB.ValidationFailure = !(string.IsNullOrEmpty(gwDDformatTB.Text.Trim()) || FormatValidator.IsMatch(gwDDformatTB.Text.Trim()));
                td.Format = gwDDformatTB.Text.Trim();
                return gwDDformatTB.ValidationFailure;
            });
            GWDiskDefTrackPara.Add("secs", (td) =>
            {
                gwDDsectorsTB.ValidationFailure = !NumericValidator(gwDDsectorsTB.Text.Trim(), 256, 0);
                td.parameters["secs"] = gwDDsectorsTB.Text.Trim();
                return gwDDsectorsTB.ValidationFailure;
            });
            GWDiskDefTrackPara.Add("bps", (td) =>
            {
                gwDDbpsTB.ValidationFailure = !(string.IsNullOrEmpty(gwDDbpsTB.Text.Trim()) || BpsValidator.IsMatch(gwDDbpsTB.Text.Trim()));
                td.parameters["bps"] = gwDDbpsTB.Text.Trim();
                return gwDDbpsTB.ValidationFailure;
            });
            GWDiskDefTrackPara.Add("iam", (td) =>
            {
                td.parameters["iam"] = gwDDiamCB.Checked ? "" : "no";
                return false;
            });
            GWDiskDefTrackPara.Add("cskew", (td) =>
            {
                gwDDcskewTB.ValidationFailure = !NumericValidator(gwDDcskewTB.Text.Trim(), 255, 0);
                td.parameters["cskew"] = gwDDcskewTB.Text.Trim();
                return gwDDcskewTB.ValidationFailure;
            });
            GWDiskDefTrackPara.Add("hskew", (td) =>
            {
                gwDDhskewTB.ValidationFailure = !NumericValidator(gwDDhskewTB.Text.Trim(), 255, 0);
                td.parameters["hskew"] = gwDDhskewTB.Text.Trim();
                return gwDDhskewTB.ValidationFailure;
            });
            GWDiskDefTrackPara.Add("interleave", (td) =>
            {
                gwDDinterleaveTB.ValidationFailure = !NumericValidator(gwDDinterleaveTB.Text.Trim());
                td.parameters["interleave"] = gwDDinterleaveTB.Text.Trim();
                return gwDDinterleaveTB.ValidationFailure;
            });
            GWDiskDefTrackPara.Add("id", (td) =>
            {
                gwDDidTB.ValidationFailure = !NumericValidator(gwDDidTB.Text.Trim(), 255, 0);
                td.parameters["id"] = gwDDidTB.Text.Trim();
                return gwDDidTB.ValidationFailure;
            });
            GWDiskDefTrackPara.Add("h", (td) =>
            {
                gwDDhTB.ValidationFailure = !NumericValidator(gwDDhTB.Text.Trim(), 255, 0);
                td.parameters["h"] = gwDDhTB.Text.Trim();
                return gwDDhTB.ValidationFailure;
            });
            GWDiskDefTrackPara.Add("gap1", (td) =>
            {
                gwDDgap1TB.ValidationFailure = !NumericValidator(gwDDgap1TB.Text.Trim(), 255, 0);
                td.parameters["gap1"] = gwDDgap1TB.Text.Trim();
                return gwDDgap1TB.ValidationFailure;
            });
            GWDiskDefTrackPara.Add("gap2", (td) =>
            {
                gwDDgap2TB.ValidationFailure = !NumericValidator(gwDDgap2TB.Text.Trim(), 255, 0);
                td.parameters["gap2"] = gwDDgap2TB.Text.Trim();
                return gwDDgap2TB.ValidationFailure;
            });
            GWDiskDefTrackPara.Add("gap3", (td) =>
            {
                gwDDgap3TB.ValidationFailure = !NumericValidator(gwDDgap3TB.Text.Trim(), 255, 0);
                td.parameters["gap3"] = gwDDgap3TB.Text.Trim();
                return gwDDgap3TB.ValidationFailure;
            });
            GWDiskDefTrackPara.Add("gap4a", (td) =>
            {
                gwDDgap4aTB.ValidationFailure = !NumericValidator(gwDDgap4aTB.Text.Trim(), 255, 0);
                td.parameters["gap4a"] = gwDDgap4aTB.Text.Trim();
                return gwDDgap4aTB.ValidationFailure;
            });
            GWDiskDefTrackPara.Add("gapbyte", (td) =>
            {
                gwDDgapbyteTB.ValidationFailure = !NumericValidator(gwDDgapbyteTB.Text.Trim(), 255, 0);
                td.parameters["gapbyte"] = gwDDgapbyteTB.Text.Trim();
                return gwDDgapbyteTB.ValidationFailure;
            });
            GWDiskDefTrackPara.Add("rate", (td) =>
            {
                gwDDrateTB.ValidationFailure = !NumericValidator(gwDDrateTB.Text.Trim(), 2000);
                td.parameters["rate"] = gwDDrateTB.Text.Trim();
                return gwDDrateTB.ValidationFailure;
            });
            GWDiskDefTrackPara.Add("rpm", (td) =>
            {
                gwDDrpmTB.ValidationFailure = !NumericValidator(gwDDrpmTB.Text.Trim(), 2000);
                td.parameters["rpm"] = gwDDrpmTB.Text.Trim();
                return gwDDrpmTB.ValidationFailure;
            });
            GWDiskDefTrackPara.Add("img_bps", (td) =>
            {
                gwDDimgbpsTB.ValidationFailure = !(string.IsNullOrEmpty(gwDDimgbpsTB.Text.Trim()) || int.TryParse(gwDDimgbpsTB.Text.Trim(), out c));
                td.parameters["img_bps"] = gwDDimgbpsTB.Text.Trim();
                return gwDDimgbpsTB.ValidationFailure;
            });
            GWDiskDefTrackPara.Add("clock", (td) =>
            {
                double clk;
                gwDDclockTB.ValidationFailure = !(string.IsNullOrEmpty(gwDDclockTB.Text.Trim()) || double.TryParse(gwDDclockTB.Text.Trim(), out clk));
                td.parameters["clock"] = gwDDclockTB.Text.Trim();
                return gwDDclockTB.ValidationFailure;
            });
            GWDiskDefTrackPara.Add("format", (td) =>
            {
                gwDDsubformatTB.ValidationFailure = false;
                td.parameters["format"] = gwDDsubformatTB.Text.Trim();
                return gwDDsubformatTB.ValidationFailure;
            });

            GWTrackDefDisplay = new Dictionary<string, Action<GwDiskDefs.TrackDefinition>>()
            {
                { "secs", (tg) => { gwDDsectorsTB.Text = tg.parameters.ContainsKey("secs") ? tg.parameters["secs"] : string.Empty; } },
                { "bps", (tg) => { gwDDbpsTB.Text = tg.parameters.ContainsKey("bps") ? tg.parameters["bps"] : string.Empty; } },
                { "iam", (tg) => {gwDDiamCB.Checked = tg.parameters.ContainsKey("iam") && tg.parameters["iam"] == "no" ? false : true; } },
                { "cskew", (tg) => {gwDDcskewTB.Text = tg.parameters.ContainsKey("cskew") ? tg.parameters["cskew"] : string.Empty;} },
                { "hskew", (tg) => {gwDDhskewTB.Text = tg.parameters.ContainsKey("hskew") ? tg.parameters["hskew"] : string.Empty;} },
                { "interleave", (tg) => {gwDDinterleaveTB.Text = tg.parameters.ContainsKey("interleave") ? tg.parameters["interleave"] : string.Empty;} },
                { "id", (tg) => {gwDDidTB.Text = tg.parameters.ContainsKey("id") ? tg.parameters["id"] : string.Empty;} },
                { "h", (tg) => {gwDDhTB.Text = tg.parameters.ContainsKey("h") ? tg.parameters["h"] : string.Empty;} },
                { "gap1", (tg) => {gwDDgap1TB.Text = tg.parameters.ContainsKey("gap1") ? tg.parameters["gap1"] : string.Empty;} },
                { "gap2", (tg) => {gwDDgap2TB.Text = tg.parameters.ContainsKey("gap2") ? tg.parameters["gap2"] : string.Empty;} },
                { "gap3", (tg) => {gwDDgap3TB.Text = tg.parameters.ContainsKey("gap3") ? tg.parameters["gap3"] : string.Empty;} },
                { "gap4a", (tg) => {gwDDgap4aTB.Text = tg.parameters.ContainsKey("gap4a") ? tg.parameters["gap4a"] : string.Empty;} },
                { "gapbyte", (tg) => {gwDDgapbyteTB.Text = tg.parameters.ContainsKey("gapbyte") ? tg.parameters["gapbyte"] : string.Empty;} },
                { "rate", (tg) => {gwDDrateTB.Text = tg.parameters.ContainsKey("rate") ? tg.parameters["rate"] : string.Empty;} },
                { "rpm", (tg) => {gwDDrpmTB.Text = tg.parameters.ContainsKey("rpm") ? tg.parameters["rpm"] : string.Empty;} },
                { "img_bps", (tg) => {gwDDimgbpsTB.Text = tg.parameters.ContainsKey("img_bps") ? tg.parameters["img_bps"] : string.Empty;} },
                { "clock", (tg) => {gwDDclockTB.Text = tg.parameters.ContainsKey("clock") ? tg.parameters["clock"] : string.Empty;} },
                { "format", (tg) => {gwDDsubformatTB.Text = tg.parameters.ContainsKey("format") ? tg.parameters["format"] : string.Empty; }}
            };
        }

        /// <summary>
        /// Common validator string value as an integer
        /// </summary>
        /// <param name="value">string content</param>
        /// <param name="bottom">lowest number accepted, default of 1</param>
        /// <param name="top">highest number accepted, default of 255</param>
        /// <returns>returns true if it meets the criteria or is empty</returns>
        public bool NumericValidator(string value, int top = 255, int bottom = 1)
        {
            if(string.IsNullOrEmpty(value)) return true; // empty value means reset and should pass

            int c;
            return (int.TryParse(value, out c) && (c >= bottom && c <= top));
        }

        public bool PopulateDiskDef()
        {
            if (CurrentDiskDef.Name != diskDefNameTB.Text.Trim())
                CurrentDiskDef = new DiskDefinition();

            bool isValid = true;

            // Name
            if (GWDiskDefPara["name"](CurrentDiskDef))
                isValid = false;

            // Cylinders
            if (GWDiskDefPara["cyls"](CurrentDiskDef))
                isValid = false;

            // Heads
            if (GWDiskDefPara["heads"](CurrentDiskDef))
                isValid = false;

            // Step
            if (GWDiskDefPara["step"](CurrentDiskDef))
                isValid = false;

            if (isValid)
            {
                CurrentDiskDef.Tracks = ddTracks.Values.ToArray();
                this.gwDD.SetDefinition(this.CurrentDiskDef);
                return true;
            }

            return false;
        }

        public bool AddTrackDef()
        {
            if (string.IsNullOrEmpty(CurrentDiskDef.Name)) return false;

            GwDiskDefs.TrackDefinition track = new GwDiskDefs.TrackDefinition();
            List<string> trackparms = new List<string>();

            bool isValid = true;

            // tracks for this definition
            if (GWDiskDefTrackPara["tracks"](track))
                isValid = false;

            // main format for this track definition
            if (GWDiskDefTrackPara["trackformat"](track))
                isValid = false;

            // additional parms
            foreach (string parm in GwDiskDefs.trackProps)
            {
                if(GWDiskDefTrackPara.ContainsKey(parm))
                {
                    if (GWDiskDefTrackPara[parm](track))
                        isValid = false;
                }
            }

            if (isValid)
            {
                ddTracks[track.ToString()] = track;
                if( gwDDTrackListLB.FindString(track.ToString()) == ListBox.NoMatches)
                    gwDDTrackListLB.Items.Add(track.ToString());

                CurrentDiskDef.Tracks = ddTracks.Values.ToArray();
                return true;
            }

            return false;
        }

        public void RemoveTrackDef(string trackref)
        {
            if (ddTracks.ContainsKey(trackref))
            {
                ddTracks.Remove(trackref);
                CurrentDiskDef.Tracks = ddTracks.Values.ToArray();
            }
            if (gwDDTrackListLB.FindString(trackref) != ListBox.NoMatches)
                gwDDTrackListLB.Items.RemoveAt(gwDDTrackListLB.FindString(trackref));
        }

        private void PopulateDDDisplay(string defName)
        {
            GwDiskDefs.DiskDefinition diskDefinition = this.gwDD.GetDiskDefinition(defName);
            PopulateDDDisplay(diskDefinition);
        }

        private void PopulateDDDisplay(GwDiskDefs.DiskDefinition diskDefinition = null)
        {
            if( diskDefinition is null )
                diskDefinition = new GwDiskDefs.DiskDefinition();

            diskDefNameTB.Text = diskDefinition.Name;
            gwDDCylsTB.Text = diskDefinition.Cylinders;
            gwDDHeadsTB.Text = diskDefinition.Heads;
            gwDDStepTB.Text = diskDefinition.step;

            string selDD = gwDiskConfigCB.Text; // persistent selection, try to select again after refresh
            string selTrack = gwDDTrackListLB.Text; // persistent selection, try to select again after refresh
            gwDDTrackListLB.Items.Clear();
            if (diskDefinition.Tracks != null && diskDefinition.Tracks.Count() > 0)
            {
                gwDDTrackListLB.Items.AddRange(diskDefinition.Tracks);
            }

            CurrentDiskDef = diskDefinition;
            PopulateTDDisplay();

            ddTracks.Clear();
            foreach (GwDiskDefs.TrackDefinition td in CurrentDiskDef.Tracks)
            {
                ddTracks.Add(td.ToString(), td);
            }

            if (!string.IsNullOrEmpty(selTrack) && gwDDTrackListLB.FindString(selTrack) != ListBox.NoMatches)
                gwDDTrackListLB.SelectedIndex = gwDDTrackListLB.FindString(selTrack);

            if (!string.IsNullOrEmpty(selDD) && gwDiskConfigCB.FindString(selDD) != ListBox.NoMatches)
            {
                gwDiskConfigCB.SelectedIndex = gwDiskConfigCB.FindString(selDD);
            } else
            {
                gwDiskConfigCB.SelectedIndex = 0;
            }

        }

        private void PopulateTDDisplay(GwDiskDefs.TrackDefinition trackDef = null)
        {
            if (trackDef is null)
                trackDef = new GwDiskDefs.TrackDefinition();
            
            
            gwDDtracksTB.Text = trackDef.Tracks;
            gwDDformatTB.Text = trackDef.Format;

            foreach (string trackProp in GWTrackDefDisplay.Keys)
            {
                GWTrackDefDisplay[trackProp](trackDef);
            }

        }

        private string[] GetDiskFormats()
        {
            string[] response = null;

            // see if we can use the config file for formats
            if(this.gwUseDiskDefFileCB.Visible && this.gwUseDiskDefFileCB.Checked && !string.IsNullOrEmpty(this.gwDiskDefsFileTB.Text)) //this.ddCfgFileAvailable
            {
                response = this.gwDD.GetDiskDefinitionsKeys();
            }

            return response;
        }
    }
}
