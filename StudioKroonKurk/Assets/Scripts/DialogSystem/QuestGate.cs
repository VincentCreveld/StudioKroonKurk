using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum QuestState { closed, canAccept, ongoing, completed }

public class QuestGate : Gate
{
	public int onGoingResult, canAcceptResult;

	public QuestGate(int id, int completed, int ongoing, int canAccept, int closed, int quest)
	{
		this.id = id;
		requiredItemId = quest;
		positiveResult = completed;
		negativeResult = closed;
		onGoingResult = ongoing;
		canAcceptResult = canAccept;
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
