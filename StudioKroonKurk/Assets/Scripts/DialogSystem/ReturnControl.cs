using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnControl : DialogEntity
{
	public ReturnControl(int i)
	{
		id = i;
	}

	public override void Run()
	{
		GameManager.instance.EndLeafFunction();
	}

	public override int ExecuteNodeAndGetNextId()
	{
		return id;
	}
}
