using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gWeasleGUI.Config
{
    using System.Collections;
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    [XmlRoot("Profiles")]
    public class ProfileDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
    {
        public bool HasChanged { get; private set; } = false;

        public ProfileDictionary() : base(0, new KeyComparer<TKey>())
        {
            
        }

        // Override the setter and getter
        public new TValue this[TKey key]
        {
            get
            {
                return base[key];
            }
            set
            {
                if (!base.ContainsKey((TKey)key))
                {
                    base.Add((TKey)key, (TValue)value);
                    this.HasChanged = true;
                }
                else if (!((TValue)base[(TKey)key]).Equals((TValue)value))
                {
                    base[key] = (TValue)value;
                    this.HasChanged = true;
                }
            }
        }

        public new void Add(TKey key, TValue value)
        {
            base.Add(key, value);
            this.HasChanged = true;
        }

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            XDocument doc = XDocument.Load(reader.ReadSubtree());
            XmlSerializer serializer = new XmlSerializer(typeof(ProfileReference<TKey, TValue>));
            XmlReader itemReader;

            this.HasChanged = false;
            foreach (XElement item in doc.Descendants(XName.Get("ProfileReference")))
            {
                itemReader = item.CreateReader();

                var kvp = serializer.Deserialize(itemReader) as ProfileReference<TKey, TValue>;
                if (File.Exists(kvp.File.ToString()))
                {
                    base.Add(kvp.Name, kvp.File);
                }
                else
                {
                    this.HasChanged = true;
                }
            }
            reader.ReadEndElement();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProfileReference<TKey, TValue>));
            //XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

            foreach (TKey key in base.Keys)
            {
                TValue value = (TValue)base[(TKey)key];
                var kvp = new ProfileReference<TKey, TValue>(key, value);
                serializer.Serialize(writer, kvp);
            }
            this.HasChanged = false;
        }

        [XmlRoot("ProfileReference")]
        public class ProfileReference<k, v>
        {
            [XmlAttribute("Name")]
            public k Name;

            [XmlAttribute("File")]
            public v File;

            public ProfileReference() { }
            public ProfileReference(k name, v file)
            {
                Name = name;
                File = file;
            }
        }
    }

    public class KeyComparer<TKey> : IEqualityComparer<TKey>
    {
        public bool Equals(TKey x, TKey y)
        {
            return x.ToString().Equals(y.ToString(), StringComparison.OrdinalIgnoreCase );
        }
        public int GetHashCode(TKey obj)
        {
            return obj.ToString().ToUpper().GetHashCode();
        }
    }
}
