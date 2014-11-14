using UnityEngine;
using System;
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
		if(Input.GetKeyUp(KeyCode.Space))
		{
			XmlRepository<Quest> questRepository = new XmlRepository<Quest>();

			Quest quest = questRepository.GetById(new Guid("09c4d55e-81aa-431f-a899-bb9381808f3f"));
			Debug.Log(quest.Name + "(" + quest.Id + ")");
			ItemChoiceReward icr = new ItemChoiceReward();
			icr.ItemRewards.Add(new ItemReward(){ Id = 123 });
			icr.ItemRewards.Add(new ItemReward(){ Id = 456, Quantity = 2 });
			quest.Rewards.Add(icr);
			questRepository.Create(quest);

			Quest newQuest = new Quest() { Name = "My new Quest" };
			newQuest.Requirements.Add(new PlayerRequirement(){ Level = 10 });
			newQuest.Rewards.Add(new StatReward(){ Experience = 1000 });
			newQuest.Rewards.Add(new ItemReward(){ Id = 100, Quantity = 3 });
			questRepository.Update(newQuest);
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
