using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gWeasleGUI
{
    public class gwArgument
    {
        public string Key = string.Empty;
        public IgwArgValue Value = null;
        public bool Positional = false;

        public gwArgument() { }

        public gwArgument(string key, string value, bool positional = false)
        {
            Key = key;
            Value = new GwStringValue(value);
            Positional = positional;
        }

        public gwArgument(string key, IgwArgValue value, bool positional = false)
        {
            Key = key;
            Value = value;
            Positional = positional;
        }

        public override string ToString()
        {
            string prefix = $"--{this.Key.Trim('-')}";
            string content = this.Value.ToString().Trim();

            if (Positional || this.Key == "additional-arguments")
                prefix = string.Empty;

            if (this.Value.ToString().Trim().ToLower() == "true")
                return prefix;

            if (content.IndexOf(' ') != -1)
                content = $"\"{content}\"";

            return $"{prefix} {content}".Trim();
        }
    }
}
