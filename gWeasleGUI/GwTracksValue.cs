using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace gWeasleGUI
{
    [XmlRoot("Tracks")]
    public class GwTracksValue : IgwArgValue
    {
        [XmlIgnore]
        public string ClassName { get { return "GwTRACKSValue"; } }

        [XmlAttribute]
        public string c { get; set; } = string.Empty;

        [XmlAttribute]
        public string h { get; set; } = string.Empty;

        [XmlAttribute]
        public string step { get; set; } = string.Empty;

        [XmlAttribute]
        public bool hswap { get; set; } = false;

        [XmlAttribute]  
        public string offsets { get; set; } = string.Empty;

        public GwTracksValue() { }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(c)) { sb.Append($"c={c}:"); }
            if (!string.IsNullOrEmpty(h)) { sb.Append($"h={h}:"); }
            if (!string.IsNullOrEmpty(offsets)) { sb.Append($"{offsets}:"); }
            if ( hswap ) { sb.Append( "hswap" ); }          

            return sb.ToString().Trim(':');
        }

        public object NewInstance(object def = null)
        {
            return new GwTracksValue();
        }

        public object NewInstance(Dictionary<string, string> values)
        {
            GwTracksValue gwTracks = new GwTracksValue();
            if (values is null) { return gwTracks; }

            if (values.ContainsKey("c"))
                gwTracks.c = utilities.SafeChangeType<string>(values["c"], gwTracks.c);

            if (values.ContainsKey("h"))
                gwTracks.h = utilities.SafeChangeType<string>(values["h"], gwTracks.h);

            if (values.ContainsKey("step"))
                gwTracks.step = utilities.SafeChangeType<string>(values["step"], gwTracks.step);

            if (values.ContainsKey("hswap"))
                gwTracks.hswap = utilities.SafeChangeType<bool>(values["hswap"], gwTracks.hswap);

            if (values.ContainsKey("offsets"))
                gwTracks.offsets = utilities.SafeChangeType<string>(values["offsets"], gwTracks.offsets);

            return gwTracks;
        }

        public Dictionary<string, string> GetValues()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            keyValuePairs.Add("c", this.c.ToString());
            keyValuePairs.Add("h", this.h.ToString());
            keyValuePairs.Add("step", this.step.ToString());
            keyValuePairs.Add("hswap", this.hswap.ToString());
            keyValuePairs.Add("offsets", this.offsets.ToString());
            return keyValuePairs;
        }
    }
}
