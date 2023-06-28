using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace gWeasleGUI
{
    [XmlRoot("String")]
    public class GwStringValue : IgwArgValue
    {
        [XmlIgnore]
        public string ClassName { get { return "GwSTRINGValue"; } }

        [XmlAttribute]
        public string DefValue { get; set; } = string.Empty;

        [XmlAttribute]
        public string Value { get; set; } = string.Empty;

        public GwStringValue() { }

        public GwStringValue(string value = "")
        {
            this.Value = value;
        }

        public override string ToString()
        {
            if(!Value.Equals(DefValue, StringComparison.OrdinalIgnoreCase)) return this.Value;

            return string.Empty;
        }

        public object NewInstance(object def = null)
        {
            string defValue = def?.ToString() ?? string.Empty;
            return new GwStringValue() {  DefValue = defValue };
        }

        public object NewInstance(Dictionary<string, string> values)
        {
            GwStringValue gwString = new GwStringValue();
            if (values is null) { return gwString; }

            if (values.ContainsKey("DefValue"))
                gwString.DefValue = utilities.SafeChangeType<string>(values["DefValue"], gwString.DefValue);

            if (values.ContainsKey("Value"))
                gwString.Value = utilities.SafeChangeType<string>(values["Value"], gwString.Value);

            return gwString;
        }

        public Dictionary<string, string> GetValues()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            keyValuePairs.Add("Value", !this.Value.Equals(this.DefValue, StringComparison.OrdinalIgnoreCase) ? this.Value.ToString() : string.Empty);
            return keyValuePairs;
        }
    }
}
