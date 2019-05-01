using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementManager : MonoBehaviour, ICamControl
{
	public Transform cam;
	public Transform playerObject;

	private Vector3 camOffset;
	public Transform movePos;

	private bool mngrHasControl = true;
	private Vector3 followPos;

	private Quaternion camRotation;

	private Quaternion targetRotation;

	private bool isFollowing = true;
	
	[Range(0,1f)]
	public float smoothing = 0.5f;

	private void Awake()
	{
		camOffset = cam.position - playerObject.position;
		camRotation = cam.rotation;
		followPos = playerObject.transform.position + camOffset;
	}

	private void Update()
    {
		if(mngrHasControl)
			followPos = playerObject.transform.position + camOffset;

		if(isFollowing)
			SmoothCamFollow();
    }

	private void SmoothCamFollow()
	{
		cam.position = Vector3.Slerp(cam.position, followPos, smoothing);
	}

	public IEnumerator MoveInLoop(Transform lookatTarget)
	{
		isFollowing = false;
		float curTime = 0f;
		float totalTime = 0.8f;

		Vector3 initialPos = cam.position;
		Quaternion startRot = cam.rotation;
		while(true)
		{
			yield return null;
			curTime += Time.deltaTime;

			//cam.LookAt(lookatTarget);
			Vector3 targDir = lookatTarget.position - movePos.position;
			Quaternion targRotation = Quaternion.LookRotation(targDir);

			cam.rotation = Quaternion.Lerp(startRot, targRotation, curTime / totalTime);
			cam.position = Vector3.Slerp(initialPos, movePos.position, curTime / totalTime);

			if(curTime > totalTime)
				break;
		}
	}

	public IEnumerator MoveOutLoop()
	{
		float curTime = 0f;
		float totalTime = 0.8f;
		Vector3 startPos = cam.position;
		Quaternion startRot = cam.rotation;

		Quaternion movebackRot = (mngrHasControl) ? camRotation : targetRotation;

		while(true)
		{
			yield return null;
			curTime += Time.deltaTime;

			cam.rotation = Quaternion.Slerp(startRot, movebackRot, curTime / totalTime);
			cam.position = Vector3.Slerp(startPos, followPos, curTime / totalTime);

			if(curTime > totalTime)
				break;
		}
		isFollowing = true;
	}

	public void ReturnCamControl()
	{
		mngrHasControl = true;
		followPos = playerObject.transform.position + camOffset;
		StartCoroutine(MoveOutLoop());
	}

	public void TakeOverCam(Vector3 moveTarg, Vector3 lookPos)
	{
		mngrHasControl = false;
		followPos = moveTarg;
		StopAllCoroutines();
		StartCoroutine(MoveCamToFollowPos(moveTarg, lookPos, 3f));
	}

	private IEnumerator MoveCamToFollowPos(Vector3 moveTarg, Vector3 lookPos, float panTime)
	{
		float curTime = 0f;
		float totalTime = panTime;
		Vector3 startPos = cam.position;
		Quaternion startRot = cam.rotation;

		Vector3 targDir = lookPos - moveTarg;
		targetRotation = Quaternion.LookRotation(targDir);

		while(true)
		{
			yield return null;
			curTime += Time.deltaTime;

			cam.rotation = Quaternion.Slerp(startRot, targetRotation, curTime / totalTime);
			cam.position = Vector3.Slerp(startPos, followPos, curTime / totalTime);

			if(curTime > totalTime)
				break;
		}
	}
}
