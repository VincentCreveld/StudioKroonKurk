using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectElement : DialogEntity
{
	public int nextId;
	public InspectElement(int i = 405, int nId = 404)
	{
		id = i;
		nextId = nId;
	}

	// Default to exit. Never called anyways.
	public override int ExecuteNodeAndGetNextId()
	{
		return nextId;
	}
}
