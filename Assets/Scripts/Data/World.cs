using System;
using System.Xml.Serialization;
using RPG.Assets.Scripts.Core;

namespace RPG.Assets.Scripts.Data
{
    public class World : IXmlRepository
    {
        #region Properties
        [XmlAttribute("id")] public Guid Id { get; set; }
		[XmlAttribute("name")] public string Name { get; set; }
		public Chunk Chunk { get; set; }
        #endregion

        #region Methods
        public World()
        {
            Id = Guid.NewGuid();
			Chunk = new Chunk();
        }

		public Chunk FindChunk(float x, float y)
		{
			if(Chunk != null)
			{
				return Chunk.FindChunk(x, y);
			}

			return null;
		}
        #endregion
    }
}