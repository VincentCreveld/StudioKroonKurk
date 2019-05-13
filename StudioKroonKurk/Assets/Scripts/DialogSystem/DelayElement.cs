using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayElement : DialogEntity
{
	public int nextId;
	public int duration;
	public int animId;

	public DelayElement(int id, int nextId, int animId)
	{
		this.id = id;
		this.nextId = nextId;
		this.animId = animId;
	}

	public override int ExecuteNodeAndGetNextId()
	{
		return nextId;
	}

	public int GetAnimId()
	{
		return animId;
	}
}
