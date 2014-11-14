using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Reflection;

public class Quest : IXmlRepository
{
	[XmlAttribute("id")]
	public Guid Id { get; set; }
	[XmlAttribute("name")]
	public string Name { get; set; }
	public SerializableList<Requirement> Requirements;
	public SerializableList<Reward> Rewards;

	public Quest()
	{
		Id = Guid.NewGuid();

		Requirements = new SerializableList<Requirement>();
		Rewards = new SerializableList<Reward>();
	}
}