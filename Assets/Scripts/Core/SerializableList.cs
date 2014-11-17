using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace RPG.Assets.Scripts.Core
{
    public class SerializableList<T> : List<T>, IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            return (null);
        }

        public void ReadXml(XmlReader reader)
        {
            GenericListDeSerializer<T> deserializer = new GenericListDeSerializer<T>();
            deserializer.Deserialize(reader, this);
        }

        public void WriteXml(XmlWriter writer)
        {
            GenericListSerializer<T> serializer = new GenericListSerializer<T>(this);
            serializer.Serialize(writer);
        }
    }
}