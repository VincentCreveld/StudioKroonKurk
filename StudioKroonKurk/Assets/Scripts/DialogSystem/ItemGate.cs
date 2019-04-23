using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGate : Gate
{
	public ItemGate(int id, int pos, int neg, int item)
	{
		this.id = id;
		requiredItemId = item;
		positiveResult = pos;
		negativeResult = neg;
	}

	public override int ExecuteNodeAndGetNextId()
	{
		switch(GameManager.instance.IsItemUnlocked(requiredItemId))
		{
			case ItemState.has:
				return positiveResult;
			default:
				return negativeResult;
		}	
	}
}
