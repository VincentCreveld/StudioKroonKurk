using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
	public Transform interactPos;
	private float interactDistance;

	private Transform curTarget;
	private bool isBeingTargeted = false;

	public float dis;

	private void Start()
	{
		interactDistance = Vector3.Distance(transform.position, interactPos.position) + 0.25f;
	}

	private void Update()
	{
		if(curTarget != null)
			dis = Vector3.Distance(curTarget.position, interactPos.position);
		if(isBeingTargeted && Vector3.Distance(curTarget.position, interactPos.position) <= 1.75f)
		{
			Execute();
			DropTarget();
		}
	}

	public Vector3 GetInteractPos()
	{
		return interactPos.position;
	}

	public virtual void Interact(Transform t)
	{
		curTarget = t;
		isBeingTargeted = true;
	}

	public abstract void Execute();

	public float GetInteractDistance()
	{
		return interactDistance;
	}

	public void DropTarget()
	{
		curTarget = null;
		isBeingTargeted = false;
	}
}
