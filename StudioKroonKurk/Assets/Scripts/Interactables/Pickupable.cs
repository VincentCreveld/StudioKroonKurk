﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickupable : Interactable
{
	public int functionToAdd = 0;
	public int itemToAdd;
	public bool checkForActiveQuest = false;
	public int questToCheck = 0;
	public bool checkForProgress = false;
	public int questProgressToMatch;
	public bool executeFuntion = false;
	public int functionToExecute = 0;

	private void Start()
	{
		GameManager.instance.dSFuncDict.Add(functionToAdd, () => Destroy(gameObject));
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
					GameManager.instance.StartNoInteractionYetDialog(transform);
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
					GameManager.instance.StartNoInteractionYetDialog(transform);
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
		GameManager.instance.StartPickupItemDialog(transform);
		GameManager.instance.PickupItem(itemToAdd);
	}
}
