using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class DialogEntity
{
	public int id;
	// For UI display purposes
	public UITypes uiType = UITypes.singleButton;

	public DialogEntity()
	{
	}

	public virtual void Run() { }

	public UITypes GetUIType()
	{
		return uiType;
	}

	// Default checking function. Also operates the gates down the line.
	public abstract int ExecuteNodeAndGetNextId();
}
