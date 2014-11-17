using System.Xml.Serialization;
using RPG.Assets.Scripts.MonoBehaviour;

namespace RPG.Assets.Scripts.Data
{
    public class ItemReward : Reward
    {
        #region Properties
        [XmlAttribute("id")] public int Id { get; set; }
        [XmlAttribute("quantity")] public int? Quantity { get; set; }
        #endregion

        #region Methods
        public override void Claim(PlayableCharacter player)
        {
            // Add item(s) to player inventory
        }
        #endregion
    }
}