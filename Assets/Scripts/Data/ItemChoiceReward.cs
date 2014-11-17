using System.Xml.Serialization;
using RPG.Assets.Scripts.Core;
using RPG.Assets.Scripts.MonoBehaviour;

namespace RPG.Assets.Scripts.Data
{
    public class ItemChoiceReward : Reward
    {
        #region Properties
        [XmlAttribute("choose")] public int? Choose { get; set; }
        public SerializableList<ItemReward> ItemRewards { get; set; }
        #endregion

        #region Methods
        public ItemChoiceReward()
        {
            ItemRewards = new SerializableList<ItemReward>();
        }

        public override void Claim(PlayableCharacter player)
        {

        }
        #endregion
    }
}