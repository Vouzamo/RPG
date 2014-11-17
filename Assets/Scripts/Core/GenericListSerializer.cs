using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace RPG.Assets.Scripts.Data
{
    public class GenericListSerializer<T>
    {
        #region Properties
        private XmlSerializerNamespaces Xns { get; set; }
        private List<T> InterfaceList { get; set; }
        private Dictionary<string, XmlSerializer> _serializers;
        #endregion

        #region Constructors
        public GenericListSerializer(List<T> interfaceList)
        {
            Xns = new XmlSerializerNamespaces();
            Xns.Add(string.Empty, string.Empty);

            InterfaceList = interfaceList;
            InitializeSerializers();
        }
        #endregion

        #region Methods
        private void InitializeSerializers()
        {
            _serializers = new Dictionary<string, XmlSerializer>();
            foreach (T t in InterfaceList)
            {
                GetSerializerByTypeName(t.GetType().FullName);
            }
        }

        public void Serialize(XmlWriter outputStream)
        {
            foreach (T t in InterfaceList)
            {
                GetSerializerByTypeName(t.GetType().FullName).Serialize(outputStream, t, Xns);
            }
        }

        private XmlSerializer GetSerializerByTypeName(string typeName)
        {
            XmlSerializer returnSerializer = null;

            if (_serializers.ContainsKey(typeName))
            {
                returnSerializer = _serializers[typeName];
            }

            if (returnSerializer == null)
            {
                returnSerializer = new XmlSerializer(Type.GetType(typeName));
                _serializers.Add(typeName, returnSerializer);
            }

            return returnSerializer;
        }
        #endregion
    }
}
