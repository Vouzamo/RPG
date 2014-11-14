using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Reflection;

public class ItemChoiceReward : Reward
{
	[XmlAttribute("choose")]
	public int? Choose;
	public SerializableList<ItemReward> ItemRewards;

	public ItemChoiceReward()
	{
		ItemRewards = new SerializableList<ItemReward>();
	}

	public override void Claim(PlayableCharacter player)
	{

	}
}