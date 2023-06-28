using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace gWeasleGUI
{
    [XmlRoot("gwCommandProfile")]
    public class gwCommand : IXmlSerializable
    {
        public string name;
        public string action;
        public bool time = true;
        public bool useDiskDefs = false;
        public List<gwArgument> args = new List<gwArgument>();

        public void PopulateInstance(Dictionary<string, string> values)
        {
            if (values is null) { return; }

            if (values.ContainsKey("name"))
                this.name = utilities.SafeChangeType<string>(values["name"], this.name);

            if (values.ContainsKey("action"))
                this.action = utilities.SafeChangeType<string>(values["action"], this.action);

            if (values.ContainsKey("time"))
                this.time = utilities.SafeChangeType<bool>(values["time"], this.time);

            if (values.ContainsKey("useDiskDefs"))
                this.useDiskDefs = utilities.SafeChangeType<bool>(values["useDiskDefs"], this.useDiskDefs);
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.MoveToContent();
            name = reader.GetAttribute("name");
            action = reader.GetAttribute("action");
            time = utilities.SafeChangeType<bool>(reader.GetAttribute("time"), false);
            useDiskDefs = utilities.SafeChangeType<bool>(reader.GetAttribute("useDiskDefs"), false);

            if (reader.ReadToDescendant("gwArgument"))
            {
                while (
                    reader.MoveToContent() == XmlNodeType.Element &&
                    reader.LocalName == "gwArgument")
                {
                    gwArgument arg = new gwArgument();
                    arg.ReadXml(reader.ReadSubtree());
                    args.Add(arg);
                    
                    reader.Skip(); // exit gwArgument element
                }
            }
            reader.ReadEndElement();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteAttributeString("name", this.name);
            writer.WriteAttributeString("action", this.action);
            writer.WriteAttributeString("time", this.time.ToString());
            writer.WriteAttributeString("useDiskDefs", this.useDiskDefs.ToString());

            XmlSerializer serializer = new XmlSerializer(typeof(gwArgument));
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();

            foreach (gwArgument arg in args)
            {
                serializer.Serialize(writer, arg, ns);
            }
        }
    }
}
