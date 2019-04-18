using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigatable : Interactable
{
	public Transform moveToPos;
	public override void Execute()
	{
		StartCoroutine(MoveOverTime(GameManager.instance.player.transform));
	}

	// animations can also go here
	private IEnumerator MoveOverTime(Transform obj)
	{
		GameManager.instance.player.enabled = false;


		float curTime = 0f;
		float totalTime = 1f;
		while(true)
		{
			yield return null;

			curTime += Time.deltaTime;

			obj.position = Vector3.Lerp(interactPos.position, moveToPos.position, curTime / totalTime);

			if(curTime > totalTime)
				break;
		}

		GameManager.instance.player.enabled = true;
		GameManager.instance.player.SetDestination(moveToPos.position);
	}
}
