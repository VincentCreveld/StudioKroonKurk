﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementManager : MonoBehaviour
{
	public Transform playerObject;

	private Vector3 camOffset;
	public Transform movePos;

	private Quaternion camRotation;

	private bool isFollowing = true;

	[SerializeField]
	[Range(0,1f)]
	private float smoothing = 0.5f;

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
		while(true)
		{
			yield return null;
			curTime += Time.deltaTime;

			transform.LookAt(lookatTarget);
			transform.position = Vector3.Slerp(playerObject.transform.position + camOffset, movePos.position, curTime / totalTime);

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
