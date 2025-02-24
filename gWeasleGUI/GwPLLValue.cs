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
        private readonly string _lowpassDef = "";

        [XmlAttribute]
        public int Period { get; set; }

        [XmlAttribute]
        public int Phase { get; set; }

        [XmlAttribute]
        public string LowPass { get; set; }

        public GwPLLValue()
        {
            this.Period = _periodDef;
            this.Phase = _phaseDef;
            this.LowPass = _lowpassDef;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (Period!=_periodDef) { sb.Append($"period={Period}:"); }
            if (Phase!=_phaseDef) { sb.Append($"phase={Phase}:"); }
            if(!string.IsNullOrEmpty(LowPass)) { sb.Append($"lowpass={LowPass}"); }

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

            if (values.ContainsKey("LowPass"))
                gwPLL.LowPass = utilities.SafeChangeType<string>(values["LowPass"], gwPLL.LowPass);

            return gwPLL;
        }

        public Dictionary<string, string> GetValues()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            keyValuePairs.Add("Period", this.Period!=this._periodDef ? this.Period.ToString() : string.Empty);
            keyValuePairs.Add("Phase", this.Phase!=this._phaseDef ? this.Phase.ToString() : string.Empty);
            keyValuePairs.Add("LowPass", this.LowPass is null ? string.Empty : this.LowPass.ToString());
            return keyValuePairs;
        }
    }
}
