using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : Interactable
{
	public int itemToAdd;
	public bool checkForActiveQuest = false;
	public int questToCheck = 0;
	public bool checkForProgress = false;
	public int questProgressToMatch;
	public bool alsoExecuteFuntion = false;
	public int functionToExecute = 0;

	public override void Execute()
	{
		if(checkForActiveQuest)
		{
			if(checkForProgress)
			{
				if(GameManager.instance.questList[questToCheck].GetCurrentQuestProgress() == questProgressToMatch)
				{
					if(alsoExecuteFuntion && GameManager.instance.dSFuncDict.ContainsKey(functionToExecute))
						GameManager.instance.dSFuncDict[functionToExecute].Invoke();
					Pickup();
				}
				else
				{
					GameManager.instance.StartNoInteractionYetDialog(transform);
				}
				return;
			}
			else
			{
				if(GameManager.instance.questList[questToCheck].GetQuestState() == QuestState.ongoing)
				{
					if(alsoExecuteFuntion && GameManager.instance.dSFuncDict.ContainsKey(functionToExecute))
						GameManager.instance.dSFuncDict[functionToExecute].Invoke();
					Pickup();
				}
				else
				{
					GameManager.instance.StartNoInteractionYetDialog(transform);
				}
				return;
			}
		}
		Pickup();
	}

	public void Pickup()
	{
		GameManager.instance.StartPickupItemDialog(transform);
		GameManager.instance.PickupItem(itemToAdd);
		Destroy(gameObject);
	}
}
