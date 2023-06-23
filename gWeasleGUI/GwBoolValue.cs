using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gWeasleGUI
{
    public class GwBoolValue : IgwArgValue
    {
        public string ClassName { get { return "GwBOOLValue"; } }
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
            return new GwBoolValue();
        }
    }
}
