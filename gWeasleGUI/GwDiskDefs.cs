using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace gWeasleGUI
{
    public class GwDiskDefs
    {
        public static string[] trackProps = new[] { "secs", "bps", "iam", "cskew", "hskew", "interleave", "id", "h", "gap1", "gap2", "gap3", "gap4a", "gapbyte", "rate", "rpm", "img_bps", "clock", "format" };

        private ILogger logger = null;
        private Action ActionStart, ActionDone;
        private Dictionary<string, GwDiskDefsValue> DiskDefinitions;
        private Dictionary<string, string> ddGlobals = new Dictionary<string, string>();
        private Dictionary<string, string> ddImports = new Dictionary<string, string>();
        private bool ddChanged = false;
        private string folderRoot = string.Empty;
        private string def_fileName = string.Empty;
        private string root_fileName = string.Empty;

        public GwDiskDefs(ILogger logger, Action WorkStart, Action WorkComplete, string fileName = null) 
        { 
            this.logger = logger;
            this.ActionStart = WorkStart;
            this.ActionDone = WorkComplete;
            DiskDefinitions = new Dictionary<string, GwDiskDefsValue>();
            if (!string.IsNullOrEmpty(fileName)) { 
                LoadRootDiskDefs(fileName);
                // start the def value as the first import
                if (ddImports.Count > 0)
                {
                    this.def_fileName = ddImports.First().Value;
                }
            }
        }

        public void SetDefinition(GwDiskDefsValue diskDef)
        {
            if (diskDef != null)
            {
                DiskDefinitions[diskDef.ToString()] = diskDef;
                ddChanged = true;
            }
        }

        public GwDiskDefsValue GetDiskDefinition(string name)
        {
            if(DiskDefinitions.ContainsKey(name)) 
                return DiskDefinitions[name];

            return null;
        }

        public void RemoveDefinition(string name)
        {
            if (DiskDefinitions.ContainsKey(name))
            {
                DiskDefinitions.Remove(name);
                ddChanged = true;
            }
        }

        public string[] GetDiskDefinitionsKeys()
        {
            return DiskDefinitions.Keys.ToArray();
        }

        public Dictionary<string, string> GetImports()
        {
            return ddImports;
        }

        public void SetDiskDefsFile(string fileName)
        {
            this.folderRoot = Path.GetDirectoryName(fileName);
            this.def_fileName = Path.GetFileName(fileName);
            this.root_fileName = Path.GetFileName(fileName);
        }

        public bool LoadRootDiskDefs(string fileName = null)
        {
            string fileToLoad = fileName;
            fileToLoad = Path.GetFileName(fileToLoad) ?? this.def_fileName;

            if(!string.IsNullOrEmpty(Path.GetDirectoryName(fileName)))
            {
                this.folderRoot = Path.GetDirectoryName(fileName);
                this.root_fileName = fileToLoad;
            }
            this.def_fileName = fileToLoad;

            return Internal_LoadDiskDefs(fileToLoad, true);
        }

        public bool LoadDiskDefs(string fileName = null)
        {
            string fileToLoad = fileName ?? this.def_fileName;
            fileToLoad = Path.GetFileName(fileToLoad) ?? this.def_fileName;
            SetPrefixFromFile(fileToLoad);

            return Internal_LoadDiskDefs(fileToLoad, false);
        }

        private bool Internal_LoadDiskDefs(string fileName, bool root)
        {
            ActionStart();
            string lastread = string.Empty;
            string fileToLoad = fileName;
            int lastreadlinenumber = 0;

            if (fileName is null)
                fileToLoad = this.def_fileName;

            try {
                using (StreamReader reader = new StreamReader(Path.Combine(this.folderRoot, fileToLoad)))
                {
                    string raw, line, key, current = string.Empty;
                    string[] parms;
                    GwDiskDefsValue diskDef = null;
                    TrackDefinition trackDef = null;
                    List<TrackDefinition> tracks = new List<TrackDefinition>();
                    DiskDefinitions.Clear();
                    if (root) {
                        ddGlobals.Clear();
                        ddImports.Clear(); }

                    while (reader.Peek() > -1)
                    { 
                        // get next line
                        raw = reader.ReadLine();
                        if (string.IsNullOrEmpty(raw.Trim()))
                            continue;

                        // parse any globals
                        parseGlobals(raw);

                        // strip comments
                        line = raw.Split('#').First();
                        if (string.IsNullOrEmpty(line.Trim()))
                            continue;

                        key = line.Trim().Split(' ').First().Trim().ToLower();
                        parms = line.Trim().Split(' ').Skip(1).ToArray();
                        lastreadlinenumber++;

                        if (key == "import")
                        {
                            // only allow imports at root for now
                            if (root) { 
                                ddImports.Add(parms.First(), parms.Last().Trim(new[] {' ', '"' })); 
                            }
                            continue;
                        }

                        if (key == "disk")
                        {
                            current = "disk";
                            lastread = "diskdef name";
                            diskDef = new GwDiskDefsValue();
                            diskDef.Name = parms.First();
                            tracks.Clear();
                            continue;
                        }

                        if (key == "tracks")
                        {
                            current = "tracks";
                            lastread = "tracks start";
                            trackDef = new TrackDefinition();
                            trackDef.Tracks = parms.First();
                            trackDef.Format = parms.Last();
                            continue;
                        }

                        if (key == "end")
                        {
                            lastread = $"{key}, {current}";
                            if (current == "disk")
                            {
                                diskDef.Tracks = tracks.ToArray();
                                DiskDefinitions[diskDef.ToString()] = diskDef;
                                current = string.Empty;
                            }

                            if (current == "tracks")
                            {
                                tracks.Add(trackDef);
                                current = "disk";
                            }
                            continue;
                        }

                        if (current == "disk")
                            ParseDDProps(line, diskDef);

                        if (current == "tracks")
                            ParseTDProps(line, trackDef);
                    }
                }
            } catch (Exception e)
            {
                logger.Error($"Error loading disk config file line {lastreadlinenumber}", e);
                return false;
            }
            ddChanged = false;

            ActionDone();
            return true;
        }

        private bool SetPrefixFromFile(string file)
        {
            if (ddImports.Count > 0)
            {
                var prefixItem = ddImports.Where(item => item.Value.Trim() == file.Trim());
                if (prefixItem is null || !(prefixItem.Count() > 0))
                    return false;

                string prefix = prefixItem.First().Key;
                if (ddGlobals.ContainsKey("prefix"))
                {
                    ddGlobals["prefix"] = prefix;
                }
                else
                {
                    ddGlobals.Add("prefix", prefix);
                }
                return true;
            }
            return false;
        }

        private string GetPrefix()
        {
            if(ddGlobals.ContainsKey("prefix"))
            {
                return ddGlobals["prefix"];
            }
            return string.Empty;
        }

        private void parseGlobals(string candidate)
        {
            // for now only use this as a hack parse for prefix when directly opening an import
            if(candidate.ToLower().IndexOf("prefix:") == -1 &&
                !ddGlobals.ContainsKey("prefix")) { return; }

            // filter extra characters
            string line = candidate.Trim().Trim('#');

            string[] parm = line.Trim().Split(':');
            if (parm.Length < 2) return;

            //ddGlobals.Add(parm[0].Trim().ToLower(), parm[1].Trim());
        }

        public void ParseTDProps(string property, TrackDefinition trackDef)
        {
            string[] parts = property.Split('=');
            if (parts.Length == 2)
            {
                string key = parts[0].Trim().ToLower();
                if(trackProps.Contains(key))
                {
                    trackDef.parameters[key] = parts[1].Trim();
                }
            }
        }

        public void ParseDDProps(string property, GwDiskDefsValue dd)
        {
            string[] parts = property.Split('=');
            if (parts.Length == 2)
            {
                string key = parts[0].Trim().ToLower();

                if (key == "cyls")
                    dd.Cylinders = parts[1].Trim();
                
                if(key == "heads")
                    dd.Heads = parts[1].Trim();
                
                if(key == "step")
                    dd.step = parts[1].Trim();
            }
        }

        public void SaveDiskDefs(string fileName = null)
        {
            ActionStart();

            if (!ddChanged) { ActionDone(); return; }

            string fileToSave = fileName;
            if (fileName is null)
                fileToSave = this.def_fileName;

            try
            {
                using (StreamWriter writer = new StreamWriter(Path.Combine(this.folderRoot, fileToSave)))
                {
                    if( !string.IsNullOrEmpty(this.GetPrefix()))
                    {
                        writer.WriteLine($"# prefix: {this.GetPrefix()}");
                        writer.WriteLine();
                    }
                    foreach (GwDiskDefsValue diskDef in DiskDefinitions.Values)
                    {
                        writer.WriteLine($"disk {diskDef.Name}");
                        writer.WriteLine($"    cyls = {diskDef.Cylinders}");
                        writer.WriteLine($"    heads = {diskDef.Heads}");
                        foreach (TrackDefinition track in diskDef.Tracks)
                        {
                            writer.WriteLine($"    tracks {track}");
                            foreach (string key in track.parameters.Keys)
                            {
                                if (!string.IsNullOrEmpty(track.parameters[key]))
                                    writer.WriteLine($"        {key} = {track.parameters[key]}");
                            }
                            writer.WriteLine("    end");
                        }
                        writer.WriteLine("end");
                        writer.WriteLine();
                    }
                }
            }
            catch (Exception e)
            {
                logger.Error("Error writing disk config file.", e);
                return;
            }
            ddChanged = false;

            ActionDone();
        }

        public void Clear()
        {
            DiskDefinitions.Clear();
        }
    }
}
