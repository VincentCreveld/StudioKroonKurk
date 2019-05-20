using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : Interactable
{
	public int dialogToStart;

	public override void Execute()
	{
		curTarget.LookAtTarget(transform.position);
		GameManager.instance.CloseGameState(this);
		GameManager.instance.SetNewDialogOption(dialogToStart);
	}
}
