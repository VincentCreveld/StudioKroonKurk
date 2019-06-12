using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : Interactable
{
    public int pickupDialogToStart = 404;
	public int functionToAdd = 0;
	public int functionToAddPickup = 0;
    public int itemToAdd;
	public string itemName;
	public string pickupText, textForProgress;
	public bool pushTextToProgress = false;
	public bool checkForActiveQuest = false;
	public int questToCheck = 0;
	public bool checkForProgress = false;
	public int questProgressToMatch;
	public bool executeFuntion = false;
	public int functionToExecute = 0;
	public bool incrementQuestMarker = false;

	public bool checkForOtherItem = false;
	public int itemToCheckId = 0;

	// hacky bool.inc
	public bool isWater;

	protected override void Start()
	{
		base.Start();
		GameManager.instance.dSFuncDict.Add(functionToAdd, () => Destroy(gameObject));
        CreatePickupDialog();

		GameManager.instance.itemList.Add(itemToAdd, new Item(itemToAdd, itemName));
    }

	public override void Execute()
	{
		if(checkForOtherItem && GameManager.instance.IsItemUnlocked(itemToCheckId) != ItemState.has)
		{
			GameManager.instance.SetNewDialogOption(678678678);
			return;
		}

		if(checkForActiveQuest)
		{
			if(checkForProgress)
			{
				if(GameManager.instance.questList[questToCheck].GetCurrentQuestProgress() == questProgressToMatch)
				{
					Pickup();
					if(executeFuntion && GameManager.instance.dSFuncDict.ContainsKey(functionToExecute))
						GameManager.instance.dSFuncDict[functionToExecute].Invoke();
				}
				else
				{
					GameManager.instance.StartNoInteractionYetDialog(this);
				}
				return;
			}
			else
			{
				if(GameManager.instance.questList[questToCheck].GetQuestState() == QuestState.ongoing)
				{
					Pickup();
					if(executeFuntion && GameManager.instance.dSFuncDict.ContainsKey(functionToExecute))
						GameManager.instance.dSFuncDict[functionToExecute].Invoke();
				}
				else
				{
					GameManager.instance.StartNoInteractionYetDialog(this);
				}
				return;
			}
		}
		Pickup();
		if(executeFuntion && GameManager.instance.dSFuncDict.ContainsKey(functionToExecute))
			GameManager.instance.dSFuncDict[functionToExecute].Invoke();
	}

	public void Pickup()
	{
		if(pushTextToProgress)
			GameManager.instance.SetNewQuestProgress(textForProgress);
		GameManager.instance.StartPickupItemDialog(this, isWater);
		GameManager.instance.PickupItem(itemToAdd);

		if(incrementQuestMarker)
			GameManager.instance.IncrementMarkerPos(questToCheck);

		Destroy(gameObject);
	}

    public void CreatePickupDialog()
    {
        GameManager.instance.allOptions.Add(new DialogText(pickupDialogToStart, functionToAddPickup, pickupText));
        GameManager.instance.allOptions.Add(new Function(functionToAddPickup, 404, functionToAdd));
		GameManager.instance.allOptions.Add(new DialogText(678678678, 404, "Je hebt hier een ander voorwerp voor nodig."));
    }
}
