using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace gWeasleGUI
{
    [XmlRoot("gwArgument")]
    public class gwArgument : IXmlSerializable
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

        public void PopulateInstance(Dictionary<string, string> values)
        {
            if (values is null) { return; }

            if (values.ContainsKey("Key"))
                this.Key = utilities.SafeChangeType<string>(values["Key"], this.Key);

            if (values.ContainsKey("Positional"))
                this.Positional = utilities.SafeChangeType<bool>(values["Positional"], this.Positional);
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            Key = reader.GetAttribute("Key");
            Positional = utilities.SafeChangeType<bool>(reader.GetAttribute("Positional"), false);

            Boolean isEmptyElement = reader.IsEmptyElement;
            reader.ReadStartElement();
            if (!isEmptyElement)
            {
                IgwArgValue pObj = utilities.ObjectFactory(reader.LocalName);
                XmlSerializer serializer = new XmlSerializer(pObj.GetType());
                var p = serializer.Deserialize(reader.ReadSubtree());
                this.Value = (IgwArgValue)p;
                reader.Skip(); // exit value element
            }
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteAttributeString("Key", this.Key);
            writer.WriteAttributeString("Positional", this.Positional.ToString());

            XmlSerializer serializer = new XmlSerializer(this.Value.GetType());
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            serializer.Serialize(writer, this.Value, ns);
        }
    }
}
