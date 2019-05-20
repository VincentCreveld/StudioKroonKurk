using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHoverOnOffset : MonoBehaviour
{
	public Transform followTarget;
	private Vector3 offset;

	private void Awake()
	{
		offset = transform.position - followTarget.position;
	}

	private void Update()
	{
		transform.position = followTarget.position + offset;
	}
}
