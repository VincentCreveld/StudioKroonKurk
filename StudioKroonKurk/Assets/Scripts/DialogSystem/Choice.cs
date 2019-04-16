using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choice : DialogEntity, IDialogText
{
	public string text, text0, text1;
	public int nextId0, nextId1;

	public Choice(int i, int nId0, int nId1, string t, string t0, string t1)
	{
		id = i;
		nextId0 = nId0;
		nextId1 = nId1;
		text = t;
		text0 = t0;
		text1 = t1;
		uiType = UITypes.twoButton;
	}

	public int GetNextId(int i)
	{
		return (i == 0) ? nextId0 : nextId1;
	}

	// Fallback function, should be dead
	public override int GetNextId()
	{
		return nextId0;
	}

	public string GetText()
	{
		return text;
	}

	public string GetText(int i)
	{
		return (i == 0) ? text0 : text1;
	}
}
