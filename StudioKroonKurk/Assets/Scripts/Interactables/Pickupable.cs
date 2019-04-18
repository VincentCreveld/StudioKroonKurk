using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : Interactable
{
	public int itemToAdd;
	public bool checkForActiveQuest = false;
	public int questToCheck = 0;
	public bool alsoExecuteFuntion = false;
	public int functionToExecute = 0;

	public override void Execute()
	{
		if(checkForActiveQuest)
		{
			if(GameManager.instance.questList[questToCheck].GetQuestState() == QuestState.ongoing)
			{
				GameManager.instance.StartPickupItemDialog();
				GameManager.instance.UnlockItemById(itemToAdd);
				if(alsoExecuteFuntion && GameManager.instance.dSFuncDict.ContainsKey(functionToExecute))
					GameManager.instance.dSFuncDict[functionToExecute].Invoke();

				Destroy(gameObject);
			}
			else
			{
				GameManager.instance.StartNoInteractionYetDialog();
			}
			return;
		}

		GameManager.instance.UnlockItemById(itemToAdd);
		Destroy(gameObject);
	}
}
