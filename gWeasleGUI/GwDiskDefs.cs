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
        public class DiskDefinition
        {
            public string Name;
            public string Cylinders;
            public string Heads;
            public string step;
            public TrackDefinition[] Tracks = new TrackDefinition[0];

            public override string ToString()
            {
                return Name;
            }
        }
        public class TrackDefinition
        {
            public string Tracks;
            public string Format;
            public Dictionary<string, string> parameters = new Dictionary<string, string>();

            public override string ToString()
            {
                return $"{this.Tracks} {this.Format}";
            }
        }

        public static string[] trackProps = new[] { "secs", "bps", "iam", "cskew", "hskew", "interleave", "id", "h", "gap1", "gap2", "gap3", "gap4a", "gapbyte", "rate", "rpm", "img_bps", "clock", "format" };

        ILogger logger = null;
        Action ActionStart, ActionDone;
        Dictionary<string, DiskDefinition> DiskDefinitions;
        bool ddChanged = false;

        public GwDiskDefs(ILogger logger, Action WorkStart, Action WorkComplete, string fileName = null) 
        { 
            this.logger = logger;
            this.ActionStart = WorkStart;
            this.ActionDone = WorkComplete;
            DiskDefinitions = new Dictionary<string, DiskDefinition>();
            if (!string.IsNullOrEmpty(fileName)) { LoadDiskDefs(fileName); }
        }

        public void SetDefinition(DiskDefinition diskDef)
        {
            if (diskDef != null)
            {
                DiskDefinitions[diskDef.ToString()] = diskDef;
                ddChanged = true;
            }
        }

        public DiskDefinition GetDiskDefinition(string name)
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

        public bool LoadDiskDefs(string fileName)
        {
            ActionStart();
            string lastread = string.Empty;
            int lastreadlinenumber = 0;

            try {
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line, key, current = string.Empty;
                    DiskDefinition diskDef = null;
                    TrackDefinition trackDef = null;
                    List<TrackDefinition> tracks = new List<TrackDefinition>();
                    DiskDefinitions.Clear();

                    while (reader.Peek() > -1)
                    {
                        // get next line sans comment
                        line = reader.ReadLine().Split('#').First();
                        key = line.Trim().Split(' ').First().Trim().ToLower();
                        lastreadlinenumber++;

                        if (string.IsNullOrEmpty(line.Trim()))
                            continue;

                        if (key == "disk")
                        {
                            current = "disk";
                            lastread = "diskdef name";
                            diskDef = new DiskDefinition();
                            diskDef.Name = line.Split(' ').Skip(1).First();
                            tracks.Clear();
                            continue;
                        }

                        if (key == "tracks")
                        {
                            current = "tracks";
                            lastread = "tracks start";
                            trackDef = new TrackDefinition();
                            trackDef.Tracks = line.Trim().Split(' ').Skip(1).First();
                            trackDef.Format = line.Trim().Split(' ').Last();
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

        public void ParseDDProps(string property, DiskDefinition dd)
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

        public void SaveDiskDefs(string fileName)
        {
            ActionStart();

            if (!ddChanged) { ActionDone(); return; }

            try
            {
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    foreach (DiskDefinition diskDef in DiskDefinitions.Values)
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
