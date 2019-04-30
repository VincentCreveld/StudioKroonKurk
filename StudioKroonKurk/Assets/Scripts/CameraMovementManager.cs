using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementManager : MonoBehaviour
{
	public Transform playerObject;

	private Vector3 camOffset;
	public Transform movePos;

	private Quaternion camRotation;

	private bool isFollowing = true;
	
	[Range(0,1f)]
	public float smoothing = 0.5f;

	private void Awake()
	{
		camOffset = transform.position - playerObject.position;
		camRotation = transform.rotation;
	}

	private void Update()
    {
		if(isFollowing)
			SmoothCamFollow();
    }

	private void SmoothCamFollow()
	{
		Vector3 newPos = playerObject.transform.position + camOffset;
		transform.position = Vector3.Slerp(transform.position, newPos, smoothing);
	}

	public IEnumerator MoveInLoop(Transform lookatTarget)
	{
		isFollowing = false;
		float curTime = 0f;
		float totalTime = 0.8f;
		StopAllCoroutines();

		Vector3 initialPos = transform.position;
		while(true)
		{
			yield return null;
			curTime += Time.deltaTime;

			//transform.LookAt(lookatTarget);
			Vector3 targDir = lookatTarget.position - movePos.position;
			Quaternion targRotation = Quaternion.LookRotation(targDir);

			transform.rotation = Quaternion.Lerp(camRotation, targRotation, curTime / totalTime);
			transform.position = Vector3.Slerp(initialPos, movePos.position, curTime / totalTime);

			if(curTime > totalTime)
				break;
		}
	}

	public IEnumerator MoveOutLoop()
	{

		float curTime = 0f;
		float totalTime = 0.8f;
		Vector3 startPos = transform.position;
		Quaternion startRot = transform.rotation;
		StopAllCoroutines();
		while(true)
		{
			yield return null;
			curTime += Time.deltaTime;

			transform.rotation = Quaternion.Slerp(startRot, camRotation, curTime / totalTime);
			transform.position = Vector3.Slerp(startPos, playerObject.transform.position + camOffset, curTime / totalTime);

			if(curTime > totalTime)
				break;
		}
		isFollowing = true;
	}
}
