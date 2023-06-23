using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gWeasleGUI
{
    public class GwIntValue : IgwArgValue
    {
        public string ClassName { get { return "GwINTValue"; } }
        public int DefValue { get; set; } = 0;
        public int Value { get; set; } = 0;
        public bool defined { get; set; } = false;

        public GwIntValue() { }
        public GwIntValue(int value = 0) 
        {
            Value = value;
        }

        public override string ToString()
        {
            if(Value != DefValue)
                return Value.ToString().Trim();

            return string.Empty;
        }

        public object NewInstance(object def = null)
        {
            int defValue = def is int ? (int)def : 0;
            return new GwIntValue() { DefValue = defValue };
        }
    }
}
