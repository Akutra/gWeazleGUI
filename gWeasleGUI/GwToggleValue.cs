using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace gWeasleGUI
{
    [XmlRoot("Toggle")]
    public class GwToggleValue : IgwArgValue
    {
        [XmlIgnore]
        public string ClassName { get { return "GwToggleValue"; } }

        [XmlAttribute]
        public string DefValue { get; set; } = string.Empty;

        [XmlAttribute]
        public string AltValue { get; set; } = string.Empty;

        [XmlAttribute]
        public string Value { get; set; } = string.Empty;

        public void SetToggle(bool toggle)
        {
            if( toggle )
            {
                this.Value = this.AltValue;
            } else
            {
                this.Value = this.DefValue;
            }
        }

        public bool GetToggle()
        {
            return this.Value == this.AltValue;
        }

        public GwToggleValue() { }
        public GwToggleValue(string value)
        {
            Value = value;
        }

        public override string ToString()
        {
            if (Value != null) return Value.ToString();

            return string.Empty;
        }

        public object NewInstance(object def = null)
        {
            string defValue = def?.ToString() ?? string.Empty;
            return new GwToggleValue(
                utilities.SafeChangeType<string>(defValue, string.Empty)
                );
        }

        public object NewInstance(Dictionary<string, string> values)
        {
            GwToggleValue gwToggle = new GwToggleValue();

            if (values.ContainsKey("DefValue"))
                gwToggle.DefValue = utilities.SafeChangeType<string>(values["DefValue"], gwToggle.DefValue);

            if (values.ContainsKey("AltValue"))
                gwToggle.AltValue = utilities.SafeChangeType<string>(values["AltValue"], gwToggle.AltValue);

            if (values.ContainsKey("Value"))
                gwToggle.Value = utilities.SafeChangeType<string>(values["Value"], gwToggle.Value);

            return gwToggle;
        }

        public Dictionary<string, string> GetValues()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            keyValuePairs.Add("Value", this.Value.ToString());

            return keyValuePairs;
        }
    }
}
