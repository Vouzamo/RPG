using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

public abstract class Reward
{
	public virtual void Claim(PlayableCharacter player)
	{

	}
}