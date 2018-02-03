using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Workrbot.Classes
{
    public class XmlUri : IXmlSerializable
    {
        public Uri Value;

        public XmlUri() { }
        public XmlUri(Uri source) { Value = source; }

        public static implicit operator Uri(XmlUri o)
        {
            return o == null ? null : o.Value;
        }

        public static implicit operator XmlUri(Uri o)
        {
            return o == null ? null : new XmlUri(o);
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            Value = new Uri(reader.ReadElementContentAsString());
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteValue(Value.ToString());
        }
    }
}