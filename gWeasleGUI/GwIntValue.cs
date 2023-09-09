using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace gWeasleGUI
{
    [XmlRoot("Int")]
    public class GwIntValue : IgwArgValue
    {
        [XmlIgnore]
        public string ClassName { get { return "GwINTValue"; } }

        [XmlAttribute]
        public int DefValue { get; set; } = 0;

        [XmlAttribute]
        public int Value { get; set; } = 0;

        [XmlAttribute]
        public bool defined { get; set; } = false;

        public GwIntValue() { }
        public GwIntValue(int value = 0) 
        {
            Value = value;
        }

        public override string ToString()
        {
            if(this.defined && Value != DefValue)
                return Value.ToString().Trim();

            return string.Empty;
        }

        public object NewInstance(object def = null)
        {
            int defValue = def is int ? (int)def : 0;
            return new GwIntValue() { DefValue = defValue };
        }

        public object NewInstance(Dictionary<string, string> values)
        {
            GwIntValue gwInt = new GwIntValue();
            if(values is null) { return gwInt; }

            if (values.ContainsKey("DefValue"))
                gwInt.DefValue = utilities.SafeChangeType<int>(values["DefValue"], gwInt.DefValue);

            if (values.ContainsKey("defined"))
                gwInt.defined = utilities.SafeChangeType<bool>(values["defined"], gwInt.defined);

            if (values.ContainsKey("Value"))
                gwInt.Value = utilities.SafeChangeType<int>(values["Value"], gwInt.Value);

            return gwInt;
        }

        public Dictionary<string, string> GetValues()
        {
            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
            keyValuePairs.Add("Value", this.Value!=this.DefValue ? this.Value.ToString() : string.Empty);
            keyValuePairs.Add("defined", this.defined.ToString());
            return keyValuePairs;
        }
    }
}
