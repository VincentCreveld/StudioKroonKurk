using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function : DialogEntity
{
	public int nextId;
	public int functionId;

	public Function(int i, int nId, int fId)
	{
		id = i;
		nextId = nId;
		functionId = fId;
		uiType = UITypes.singleButton;
	}

	public override int ExecuteNodeAndGetNextId()
	{
		if(GameManager.instance != null)
			GameManager.instance.ExecuteFunctionById(functionId);
		
		return nextId;
	}
}
