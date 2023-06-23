using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gWeasleGUI
{
    public class GwStringValue : IgwArgValue
    {
        public string ClassName { get { return "GwSTRINGValue"; } }
        public string DefValue { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;

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
    }
}
