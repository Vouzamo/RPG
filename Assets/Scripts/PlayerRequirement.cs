using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

public class PlayerRequirement : Requirement
{
	[XmlAttribute("level")]
	public int? Level;
	[XmlAttribute("maxLevel")]
	public int? MaxLevel;
	[XmlAttribute("minLevel")]
	public int? MinLevel;
	
	public override void Test(PlayableCharacter player)
	{
		bool satisfied = false;

		// Perform tests

		Satisfied = satisfied;
	}
}