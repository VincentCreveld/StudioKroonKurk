using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovementManager : MonoBehaviour, ICamControl
{
	public Transform cam;
	public Transform playerObject;

	private Vector3 camOffset;
	public Transform movePos;
	public Transform playerHoverPos;

	private bool mngrHasControl = true;
	private Vector3 followPos, prevFollowPos;

	private Quaternion defaultRotation;

	private Quaternion targetRotation, prevTargetRotation;

	private bool isFollowing = true;
	
	[Range(0,1f)]
	public float smoothing = 0.5f;

	public PinchZoom zoom;

	public Vector3 FollowPos { get => followPos; set { prevFollowPos = followPos; followPos = value; } }

	public Quaternion TargetRotation { get => targetRotation; set { prevTargetRotation = targetRotation; targetRotation = value; } }

	private void Awake()
	{
		camOffset = cam.position - playerObject.position;
		defaultRotation = cam.rotation;
		FollowPos = playerObject.transform.position + camOffset;
	}

	private void Update()
    {
		if(mngrHasControl)
			FollowPos = playerObject.transform.position + camOffset;

		if(isFollowing)
			SmoothCamFollow();
    }

	private void SmoothCamFollow()
	{
		cam.position = Vector3.Slerp(cam.position, FollowPos, smoothing);
	}

	public void FocusCamOnTarget(Transform target, float panTime = 0.4f, bool isPlayer = false)
	{
		StopAllCoroutines();
		StartCoroutine(MoveInLoop(target, panTime, isPlayer));
	}

	public IEnumerator MoveInLoop(Transform lookatTarget, float totalTime, bool isPlayer = false)
	{
		isFollowing = false;
		zoom.ZoomOut();
		float curTime = 0f;

		Vector3 initialPos = cam.position;
		Quaternion startRot = cam.rotation;

		Vector3 lPos = (isPlayer) ? lookatTarget.position + Vector3.up : lookatTarget.position;

		Transform t = (isPlayer) ? playerHoverPos : movePos;

		while(true)
		{
			yield return null;
			curTime += Time.deltaTime;

			//cam.LookAt(lookatTarget);
			Vector3 targDir = lPos - t.position;
			Quaternion targRotation = Quaternion.LookRotation(targDir);

			cam.rotation = Quaternion.Lerp(startRot, targRotation, curTime / totalTime);
			cam.position = Vector3.Slerp(initialPos, t.position, curTime / totalTime);

			if(curTime > totalTime)
				break;
		}
	}

	public IEnumerator MoveOutLoop(float totalTime)
	{
		zoom.ZoomOut();
		float curTime = 0f;
		Vector3 startPos = cam.position;
		Quaternion startRot = cam.rotation;

		Quaternion movebackRot = (mngrHasControl) ? defaultRotation : TargetRotation;

		while(true)
		{
			yield return null;

			cam.rotation = Quaternion.Lerp(startRot, movebackRot, curTime / totalTime);
			cam.position = Vector3.Lerp(startPos, FollowPos, curTime / totalTime);

			curTime += Time.deltaTime;
			if(curTime > totalTime)
				break;
		}
		isFollowing = true;
	}

	public void ReturnCamControl()
	{
		mngrHasControl = true;
		FollowPos = playerObject.transform.position + camOffset;
		StopAllCoroutines();
		StartCoroutine(MoveOutLoop(0.8f));
	}

	public void TakeOverCam(Vector3 moveTarg, Vector3 lookPos, float speed = 3f)
	{
		mngrHasControl = false;
		FollowPos = moveTarg;
		StopAllCoroutines();
		StartCoroutine(MoveCamToFollowPos(moveTarg, lookPos, speed));
	}

	private IEnumerator MoveCamToFollowPos(Vector3 moveTarg, Vector3 lookPos, float panTime)
	{
		isFollowing = false;
		zoom.ZoomOut();
		float curTime = 0f;
		float totalTime = panTime;
		Vector3 startPos = cam.position;
		Quaternion startRot = cam.rotation;

		Vector3 targDir = lookPos - moveTarg;
		TargetRotation = Quaternion.LookRotation(targDir);

		while(true)
		{
			yield return null;

			cam.rotation = Quaternion.Lerp(startRot, TargetRotation, curTime / totalTime);
			cam.position = Vector3.Lerp(startPos, FollowPos, curTime / totalTime);

			curTime += Time.deltaTime;
			if(curTime > totalTime)
				break;
		}
	}

	public void MoveCamAmbi()
	{
		StopAllCoroutines();
		Vector3 p = prevFollowPos;
		Quaternion t = prevTargetRotation;
		FollowPos = p;
		TargetRotation = t;
		StartCoroutine(MoveCamAmbiguous(0.8f));
	}

	private IEnumerator MoveCamAmbiguous(float panTime)
	{
		zoom.ZoomOut();
		float curTime = 0f;
		float totalTime = panTime;
		Vector3 startPos = cam.position;
		Quaternion startRot = cam.rotation;

		while(true)
		{
			yield return null;

			cam.rotation = Quaternion.Lerp(startRot, TargetRotation, curTime / totalTime);
			cam.position = Vector3.Lerp(startPos, FollowPos, curTime / totalTime);

			curTime += Time.deltaTime;
			if(curTime > totalTime)
				break;
		}
	}

	public bool GetMngrHasControl()
	{
		return mngrHasControl;
	}
}
