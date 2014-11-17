using System;
using System.Xml.Serialization;
using RPG.Assets.Scripts.Core;

namespace RPG.Assets.Scripts.Data
{
    public class Quest : IXmlRepository
    {
        #region Properties
        [XmlAttribute("id")] public Guid Id { get; set; }
        [XmlAttribute("name")] public string Name { get; set; }
        public SerializableList<Requirement> Requirements { get; set; }
        public SerializableList<Reward> Rewards { get; set; }
        #endregion

        #region Methods
        public Quest()
        {
            Id = Guid.NewGuid();
            Requirements = new SerializableList<Requirement>();
            Rewards = new SerializableList<Reward>();
        }
        #endregion
    }
}