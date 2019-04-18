using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestStepGate : Gate
{
	public List<int> stepToMatch = new List<int>();

	public QuestStepGate(int id, int pos, int neg, int quest, params int[] allowedSteps)
	{
		this.id = id;
		requiredItemId = quest;
		positiveResult = pos;
		negativeResult = neg;

		foreach(int i in allowedSteps)
		{
			stepToMatch.Add(i);
		}
	}

	public override int ExecuteNodeAndGetNextId()
	{
		if(GameManager.instance.IsIdInQuests(requiredItemId))
		{
			int val = GameManager.instance.GetQuestStepById(requiredItemId);
			if(stepToMatch.Contains(val))
				return positiveResult;
		}
		return negativeResult;
	}
}
