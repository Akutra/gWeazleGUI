using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gWeasleGUI
{
    public class GwTracksValue : IgwArgValue
    {
        public string ClassName { get { return "GwTRACKSValue"; } }
        public string c { get; set; } = string.Empty;
        public string h { get; set; } = string.Empty;
        public string step { get; set; } = string.Empty;
        public bool hswap { get; set; } = false;
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
    }
}
