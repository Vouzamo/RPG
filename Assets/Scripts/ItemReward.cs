using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

public class ItemReward : Reward
{
	[XmlAttribute("id")]
	public int Id;
	[XmlAttribute("quantity")]
	public int? Quantity;

	public override void Claim(PlayableCharacter player)
	{
		// Add item(s) to player inventory
	}
}