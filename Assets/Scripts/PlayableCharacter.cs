using UnityEngine;
using System.Collections;

public class PlayableCharacter : Character {
	#region Properties
	public int PlayerIndex;
	#endregion
	
	#region Constructors
	#endregion
	
	#region Methods
	public override void Start () {
		base.Start();
	}
	public override void Update () {
		if(enabled)
		{
			GetInput();
		}
		base.Update();
	}
	private void GetInput()
	{
		switch(PlayerIndex)
		{
			case 0:
				Move(transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical") * -1, 0)));
				break;
		}
	}
	#endregion
}
