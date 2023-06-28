using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace gWeasleGUI
{
    [XmlRoot("PLL")]
    public class GwPLLValue : IgwArgValue
    {
        [XmlIgnore]
        public string ClassName { get { return "GwPLLValue"; } }
        private readonly int _periodDef = 5;
        private readonly int _phaseDef = 60;

        [XmlAttribute]
        public int Period { get; set; }

        [XmlAttribute]
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

        public object NewInstance(Dictionary<string, string> values)
        {
            GwPLLValue gwPLL = new GwPLLValue();
            if (values is null) { return gwPLL; }

            if (values.ContainsKey("Period"))
                gwPLL.Period = utilities.SafeChangeType<int>(values["Period"], gwPLL.Period);

            if (values.ContainsKey("Phase"))
                gwPLL.Phase = utilities.SafeChangeType<int>(values["Phase"], gwPLL.Phase);

            return gwPLL;
        }

        public Dictionary<string, string> GetValues()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            keyValuePairs.Add("Period", this.Period!=this._periodDef ? this.Period.ToString() : string.Empty);
            keyValuePairs.Add("Phase", this.Phase!=this._phaseDef ? this.Phase.ToString() : string.Empty);
            return keyValuePairs;
        }
    }
}
