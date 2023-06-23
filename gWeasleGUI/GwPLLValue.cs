using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gWeasleGUI
{
    public class GwPLLValue : IgwArgValue
    {
        public string ClassName { get { return "GwPLLValue"; } }
        private readonly int _periodDef = 5;
        private readonly int _phaseDef = 60;

        public int Period { get; set; }
        public int Phase { get; set; }

        public GwPLLValue()
        {
            this.Period = _periodDef;
            this.Phase = _phaseDef;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Period!=_periodDef) { sb.Append($"period={Period}:"); }
            if (Phase!=_phaseDef) { sb.Append($"phase={Phase}"); }

            return sb.ToString().Trim(':');
        }

        public object NewInstance(object def = null)
        {
            return new GwPLLValue();
        }
    }
}
