using UnityEngine;
using System;
using System.Xml.Serialization;

namespace RPG.Assets.Scripts.Data
{
    public class Tile : Prefab
    {
        #region Properties
        [XmlAttribute("id")] public Guid Id { get; set; }
        [XmlAttribute("sprite")] public string SpriteName { get; set; }
		[XmlAttribute("r")] public float? ColorR { get; set; }
		[XmlAttribute("g")] public float? ColorG { get; set; }
		[XmlAttribute("b")] public float? ColorB { get; set; }
		[XmlAttribute("a")] public float? ColorA { get; set; }
        #endregion

		#region Methods
		public override GameObject Load(God god)
		{
			GameObject gameObject = (GameObject)GameObject.Instantiate(god.TilePrefab);

			gameObject.transform.position = new Vector3(X, Y);
			if(ColorR != null && ColorG != null && ColorB != null && ColorA != null)
			{
				gameObject.GetComponent<SpriteRenderer>().color = new Color((float)ColorR, (float)ColorG, (float)ColorB, (float)ColorA);
			}

			return gameObject;
		}
		#endregion
    }
}