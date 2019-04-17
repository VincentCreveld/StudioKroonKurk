using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogSystemFunctionStorage 
{
    public DialogSystemFunctionStorage()
	{
		if(GameManager.instance == null)
			return;

		GameManager.instance.dSFuncDict = new Dictionary<int, System.Action>();

		GameManager.instance.dSFuncDict.Add(0, DebugFunction);
		GameManager.instance.dSFuncDict.Add(1, DebugFunction2);
	}

	public void DebugFunction()
	{
		Debug.Log("Glad you listened");
	}

	public void DebugFunction2()
	{
		Debug.Log("Really, man?");
	}
}
