using System.Xml.Serialization;
using RPG.Assets.Scripts.MonoBehaviour;

namespace RPG.Assets.Scripts.Data
{
    public class StatReward : Reward
    {
        #region Properties
        [XmlAttribute("experience")] public int? Experience { get; set; }
        #endregion

        #region Methods
        public override void Claim(PlayableCharacter player)
        {
            // Add stat boost(s) to player stats
        }
        #endregion
    }
}