﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : Interactable
{
    public int pickupDialogToStart = 404;
	public int functionToAdd = 0;
	public int functionToAddPickup = 0;
    public int itemToAdd;
	public string pickupText;
	public bool checkForActiveQuest = false;
	public int questToCheck = 0;
	public bool checkForProgress = false;
	public int questProgressToMatch;
	public bool executeFuntion = false;
	public int functionToExecute = 0;

	protected override void Start()
	{
		base.Start();
		GameManager.instance.dSFuncDict.Add(functionToAdd, () => Destroy(gameObject));
        CreatePickupDialog();
    }

	public override void Execute()
	{
		if(checkForActiveQuest)
		{
			if(checkForProgress)
			{
				if(GameManager.instance.questList[questToCheck].GetCurrentQuestProgress() == questProgressToMatch)
				{
					if(executeFuntion && GameManager.instance.dSFuncDict.ContainsKey(functionToExecute))
						GameManager.instance.dSFuncDict[functionToExecute].Invoke();
					Pickup();
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
					if(executeFuntion && GameManager.instance.dSFuncDict.ContainsKey(functionToExecute))
						GameManager.instance.dSFuncDict[functionToExecute].Invoke();
					Pickup();
				}
				else
				{
					GameManager.instance.StartNoInteractionYetDialog(this);
				}
				return;
			}
		}
		if(executeFuntion && GameManager.instance.dSFuncDict.ContainsKey(functionToExecute))
			GameManager.instance.dSFuncDict[functionToExecute].Invoke();
		Pickup();
	}

	public void Pickup()
	{
		GameManager.instance.StartPickupItemDialog(this, pickupDialogToStart);
		GameManager.instance.PickupItem(itemToAdd);
	}

    public void CreatePickupDialog()
    {
        GameManager.instance.allOptions.Add(new DialogText(pickupDialogToStart, functionToAddPickup, pickupText));
        GameManager.instance.allOptions.Add(new Function(functionToAddPickup, 404, functionToAdd));
    }
}
