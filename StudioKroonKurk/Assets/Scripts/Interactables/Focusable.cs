using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focusable : Interactable
{
	public Transform movePos;

	public override void Execute()
	{
		//curTarget.LookAtTarget(transform.position);
		GameManager.instance.camManager.TakeOverCam(movePos.position, focusPos.position, 1f);
		GameManager.instance.CloseGameWithoutAnim(this);
		GameManager.instance.SetNewDialogOption(405);
	}
}
