using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace gWeasleGUI
{
    public static class DictionaryExtensions
    {
        public static void Merge<T, K, V>(this T me, params IDictionary<K, V>[] toMerge)
            where T : IDictionary<K, V>, new()
        {
            // For-loop is benchmarked as the fastest way to do this.
            foreach (IDictionary<K, V> src in toMerge)
            {
                foreach (KeyValuePair<K, V> p in src)
                {
                    me[p.Key] = p.Value;
                }
            }
        }

        public static void MergeXmlAttributes<T>(this T me, XmlAttributeCollection toMerge) where T : IDictionary<string, string>, new()
        {
            foreach(XmlAttribute attr in toMerge)
            {
                me[attr.Name] = attr.Value;
            }
        }
    }
}
