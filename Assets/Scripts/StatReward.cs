using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

public class StatReward : Reward
{
	[XmlAttribute("experience")]
	public int? Experience;

	public override void Claim(PlayableCharacter player)
	{
		// Add stat boost(s) to player stats
	}
}