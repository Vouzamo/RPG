using System;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

namespace RPG.Assets.Scripts.Core
{
    public class XmlRepository<T> where T : IXmlRepository
    {
        #region Properties
        private string Directory { get; set; }
        #endregion

        #region Constructors
        public XmlRepository()
        {
            Directory = string.Format("{0}\\Xml", Application.dataPath);
        }
        #endregion

        #region Methods
        public T GetById(Guid id)
        {
            string filename = string.Format("{0}-{1}.xml", typeof(T).Name.ToLower(), id);
            T record;

            XmlSerializer deserializer = new XmlSerializer(typeof(T));
            using(TextReader reader = new StreamReader(string.Format(Directory + "\\{0}", filename)))
            {
                record = (T) deserializer.Deserialize(reader);
            }

            return record;
        }

        public void Update(T record)
        {
            string filename = string.Format("{0}-{1}.xml", typeof(T).Name.ToLower(), record.Id);

            XmlSerializerNamespaces xns = new XmlSerializerNamespaces();
            xns.Add(string.Empty, string.Empty);

            XmlSerializer serializer = new XmlSerializer(typeof (T));
            using(TextWriter writer = new StreamWriter(string.Format(Directory + "\\{0}", filename)))
            {
                serializer.Serialize(writer, record, xns);
            }
        }

        public void Create(T record)
        {
            record.Id = Guid.NewGuid();

            Update(record);
        }
        #endregion
    }
}