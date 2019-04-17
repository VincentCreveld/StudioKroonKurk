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
		GameManager.instance.dSFuncDict.Add(2, ()=>UnlockItem(4));
		GameManager.instance.dSFuncDict.Add(3, ()=>UnlockQuest(0));
	}

	public void DebugFunction()
	{
		Debug.Log("Glad you listened");
	}

	public void DebugFunction2()
	{
		Debug.Log("Really, man?");
	}

	public void UnlockItem(int i)
	{
		GameManager.instance.UnlockItemById(i);
	}

	public void UnlockQuest(int i)
	{
		GameManager.instance.UnlockQuestById(i);
	}
}
