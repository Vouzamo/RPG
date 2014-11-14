using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Reflection;
using UnityEngine;

public interface IXmlRepository
{
	Guid Id { get; set; }
	string Name { get; set; }
}

public class XmlRepository<T> where T : IXmlRepository
{
	private string directory { get; set; }

	public XmlRepository()
	{
		directory = string.Format("{0}\\Xml", Application.dataPath);
	}

	public T GetById(Guid id)
	{
		string filename = string.Format("{0}-{1}.xml", typeof(T).ToString().ToLower(), id);
		T record;
		
		XmlSerializer deserializer = new XmlSerializer(typeof(T));
		using(TextReader reader = new StreamReader(string.Format(directory + "\\{0}", filename)))              
		{
			record = (T)deserializer.Deserialize(reader);
		}
		
		return record;
	}
	
	public void Update(T record)
	{
		string filename = string.Format("{0}-{1}.xml", typeof(T).ToString().ToLower(), record.Id);

		XmlSerializerNamespaces xns = new XmlSerializerNamespaces();
		xns.Add(string.Empty, string.Empty);

		XmlSerializer serializer = new XmlSerializer(typeof(T));
		using(TextWriter writer = new StreamWriter(string.Format(directory + "\\{0}", filename)))
		{
			serializer.Serialize(writer, record, xns);
		}
	}

	public void Create(T record)
	{
		record.Id = Guid.NewGuid();

		Update(record);
	}
}