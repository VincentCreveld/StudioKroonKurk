using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementManager : MonoBehaviour
{
	public Transform playerObject;

	private Vector3 camOffset;

	[SerializeField]
	[Range(0,1f)]
	private float smoothing = 0.5f;

	private void Awake()
	{
		camOffset = transform.position - playerObject.position;
	}

	private void Update()
    {
		SmoothCamFollow();
    }

	private void SmoothCamFollow()
	{
		Vector3 newPos = playerObject.transform.position + camOffset;
		transform.position = Vector3.Slerp(transform.position, newPos, smoothing);
	}
}
