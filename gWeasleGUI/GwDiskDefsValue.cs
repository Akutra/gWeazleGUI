using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gWeasleGUI
{
    public class GwDiskDefsValue
    {
        public string ClassName { get { return "GwDISKDEFSValue"; } }

        public string Name;
        public string Cylinders;
        public string Heads;
        public string step;
        public TrackDefinition[] Tracks = new TrackDefinition[0];

        public object NewInstance()
        {
            return new GwDiskDefsValue();
        }

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
}
