using UnityEngine;
using System.Xml.Serialization;

namespace RPG.Assets.Scripts.Data
{
    public abstract class Prefab
    {
		[XmlAttribute("x")] public int X { get; set; }
		[XmlAttribute("y")] public int Y { get; set; }

		public abstract GameObject Load(God god);
    }
}