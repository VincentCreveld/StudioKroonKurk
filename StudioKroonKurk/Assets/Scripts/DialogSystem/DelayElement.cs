using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DelayElement : DialogEntity
{
	public int id;
	public int nextId;
	public int duration;

	public override int ExecuteNodeAndGetNextId()
	{
		return nextId;
	}

	public IEnumerator ExecuteDelay()
	{
		yield return new WaitForSeconds(duration);
	}
}
