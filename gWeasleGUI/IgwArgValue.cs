using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace gWeasleGUI
{
    public interface IgwArgValue
    {
        string ClassName { get; }

        string ToString();

        object NewInstance(object def = null);

        object NewInstance(Dictionary<string,string> values);

        Dictionary<string,string> GetValues();
    }
}
