using System.Xml.Serialization;
using RPG.Assets.Scripts.MonoBehaviour;

namespace RPG.Assets.Scripts.Data
{
    public class PlayerRequirement : Requirement
    {
        #region Properties
        [XmlAttribute("level")]
        public int? Level;
        [XmlAttribute("maxLevel")]
        public int? MaxLevel;
        [XmlAttribute("minLevel")]
        public int? MinLevel;
        #endregion

        #region Methods
        public override void Test(PlayableCharacter player)
        {
            bool satisfied = false;

            // Perform tests

            Satisfied = satisfied;
        }
        #endregion
    }
}