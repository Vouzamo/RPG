using System.Xml.Serialization;
using RPG.Assets.Scripts.MonoBehaviour;

namespace RPG.Assets.Scripts.Data
{
    public abstract class Requirement
    {
        #region Properties
        [XmlIgnore]
	    public bool Satisfied { get; set; }
        #endregion

        #region Methods
        protected Requirement()
	    {
		    Satisfied = false;
	    }

	    public virtual void Test(PlayableCharacter player)
	    {

        }
        #endregion
    }  
}