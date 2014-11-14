using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

public abstract class Requirement
{
	[XmlIgnore]
	public bool Satisfied;
	
	public Requirement()
	{
		Satisfied = false;
	}
	
	public virtual void Test(PlayableCharacter player)
	{

	}
}