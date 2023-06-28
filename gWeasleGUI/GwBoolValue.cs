using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace gWeasleGUI
{
    [XmlRoot("Bool")]
    public class GwBoolValue : IgwArgValue
    {
        [XmlIgnore]
        public string ClassName { get { return "GwBOOLValue"; } }

        [XmlAttribute]
        public bool Value { get; set; } = false;

        public GwBoolValue() { }
        public GwBoolValue(bool value = false)
        {
            Value = value;
        }

        public override string ToString()
        {
            if(Value) return Value.ToString();

            return string.Empty;
        }

        public object NewInstance(object def = null)
        {
            return new GwBoolValue(
                utilities.SafeChangeType<bool>(def,false)
                );
        }

        public object NewInstance(Dictionary<string, string> values)
        {
            if(values != null && values.ContainsKey("Value"))
                return this.NewInstance(values["Value"]);

            return new GwBoolValue();
        }

        public Dictionary<string, string> GetValues()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            keyValuePairs.Add("Value", this.Value.ToString());
            return keyValuePairs;
        }
    }
}
