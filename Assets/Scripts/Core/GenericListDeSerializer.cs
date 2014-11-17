using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace RPG.Assets.Scripts.Core
{
    public class GenericListDeSerializer<T>
    {
        #region Properties
        private Dictionary<string, XmlSerializer> Serializers { get; set; }
        #endregion

        #region Constructors
        public GenericListDeSerializer()
        {
            Serializers = new Dictionary<string, XmlSerializer>();
        }
        #endregion

        #region Methods
        public void Deserialize(XmlReader inputStream, List<T> interfaceList)
        {
            string parentNodeName = inputStream.Name;

            inputStream.Read();

            while (parentNodeName != inputStream.Name)
            {
                XmlSerializer slzr = GetSerializerByTypeName(inputStream.Name);
                interfaceList.Add((T)slzr.Deserialize(inputStream));
            }
        }

        private XmlSerializer GetSerializerByTypeName(string typeName)
        {
            XmlSerializer returnSerializer = null;

            if (Serializers.ContainsKey(typeName))
            {
                returnSerializer = Serializers[typeName];
            }

            if (returnSerializer == null)
            {
                returnSerializer = new XmlSerializer(Type.GetType(this.GetType().Namespace + "." + typeName));
                Serializers.Add(typeName, returnSerializer);
            }

            return returnSerializer;
        }
        #endregion
    }
}
