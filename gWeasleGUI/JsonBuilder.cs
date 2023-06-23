using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gWeasleGUI
{
    public class JsonBuilder
    {
        private StringBuilder content = new StringBuilder();

        public JsonBuilder() 
        {

        }

        public void Add(string key, string value)
        {
            content.AppendLine($"'{key}': '{value}',");
        }

        public void AddRange(Dictionary<string, string> kvPair)
        {
            foreach(KeyValuePair<string, string> entry in kvPair)
            {
                Add(entry.Key, entry.Value);
            }
        }

        public override string ToString()
        {
            return $"{{ {content.ToString().Trim(new char[] { ',', '\r', '\n', ' ' })}  }}";
        }
    }
}
