using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestState { closed, canAccept, ongoing, completed }

public class QuestGate : Gate
{
	public int onGoingResult, canAcceptResult;

	public QuestGate(int id, int completed, int ongoing, int open, int closed, int item)
	{
		this.id = id;
		requiredItemId = item;
		positiveResult = completed;
		negativeResult = closed;
		onGoingResult = ongoing;
		canAcceptResult = open;
	}

	public override int ExecuteNodeAndGetNextId()
	{
		if(GameManager.instance.IsIdInQuests(requiredItemId))
		{
			switch(GameManager.instance.GetQuestStateById(requiredItemId))
			{
				case QuestState.canAccept:
					return canAcceptResult;
				case QuestState.closed:
					return negativeResult;
				case QuestState.ongoing:
					return onGoingResult;
				case QuestState.completed:
					return positiveResult;
			}
		}
		return negativeResult;
	}
}
