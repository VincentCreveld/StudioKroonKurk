using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogNPC : Interactable
{
	public int dialogToStart;

	public override void Execute()
	{
		GameManager.instance.CloseGameState();
		GameManager.instance.SetNewDialogOption(dialogToStart);
	}
}
