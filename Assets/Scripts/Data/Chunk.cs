using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using RPG.Assets.Scripts.Core;

namespace RPG.Assets.Scripts.Data
{
    public class Chunk
    {
        #region Properties
		public SerializableList<Chunk> Chunks { get; set; }

		[XmlAttribute("x1")] public int? X1 { get; set; }
		[XmlAttribute("y1")] public int? Y1 { get; set; }
		[XmlAttribute("x2")] public int? X2 { get; set; }
		[XmlAttribute("y2")] public int? Y2 { get; set; }

		public SerializableList<Prefab> Data { get; set; }

		[XmlIgnore] public List<GameObject> Loaded { get; set; }

        #endregion

        #region Methods
        public Chunk()
        {
			Chunks = new SerializableList<Chunk>();
			Data = new SerializableList<Prefab>();
			Loaded = new List<GameObject>();
        }

		public int MinX()
		{
			int x = 0;
			
			if(X1 != null && X2 != null)
			{
				x = Math.Min((int)X1, (int)X2);
			}

			if(Chunks.Any())
			{
				x = Chunks.OrderBy(c => c.MinX()).First().MinX();
			}

			return x;
		}

		public int MaxX()
		{
			int x = 0;
			
			if(X1 != null && X2 != null)
			{
				x = Math.Max((int)X1, (int)X2);
			}
			
			if(Chunks.Any())
			{
				x = Chunks.OrderByDescending(c => c.MaxX()).First().MaxX();
			}
			
			return x;
		}

		public int MinY()
		{
			int y = 0;
			
			if(Y1 != null && Y2 != null)
			{
				y = Math.Min((int)Y1, (int)Y2);
			}
			
			if(Chunks.Any())
			{
				y = Chunks.OrderBy(c => c.MinY()).First().MinY();
			}
			
			return y;
		}

		public int MaxY()
		{
			int y = 0;
			
			if(Y1 != null && Y2 != null)
			{
				y = Math.Max((int)Y1, (int)Y2);
			}
			
			if(Chunks.Any())
			{
				y = Chunks.OrderByDescending(c => c.MaxY()).First().MaxY();
			}
			
			return y;
		}

		public int Width()
		{
			return MaxX() - MinX();
		}

		public int Height()
		{
			return MaxY() - MinY();
		}

		public Chunk FindChunk(float x, float y)
		{
			Chunk chunk = null;

			if(Chunks.Any())
			{
				chunk = Chunks.FirstOrDefault(c => c.MinX() <= x && c.MaxX() >= x && c.MinY() <= y && c.MaxY() >= y);
			}

			if(chunk == null && MinX() <= x && MaxX() >= x && MinY() <= y && MaxY() >= y)
			{
				chunk = this;
			}

			return chunk;
		}

		public void Load(God god)
		{
			foreach(Prefab p in Data)
			{
				GameObject loadedGameObject = p.Load(god);

				loadedGameObject.transform.parent = god.transform;

				Loaded.Add(loadedGameObject);
			}
		}

		public void UnLoad()
		{
			foreach(GameObject gameObject in Loaded)
			{
				GameObject.Destroy(gameObject);
			}

			Loaded.Clear();
		}
        #endregion
    }
}