using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
	public Transform interactPos, focusPos;
	public float interactDistance;

	protected IInteracter curTarget;
	private bool isBeingTargeted = false;

	private float dis;

	private void Start()
	{
		if(focusPos == null)
			focusPos = transform;

		interactDistance = Vector3.Distance(transform.position, interactPos.position) + 0.25f;
	}

	private void Update()
	{
		if(curTarget != null)
			dis = Vector3.Distance(new Vector3(curTarget.GetPos().x, interactPos.position.y, curTarget.GetPos().z), interactPos.position);

		if(isBeingTargeted && dis <= 1f)
		{
			Execute();
			DropTarget();
		}
	}

	public Vector3 GetInteractPos()
	{
		return interactPos.position;
	}

	public Transform GetFocusTransform()
	{
		return focusPos;
	}

	public virtual void Interact(IInteracter t)
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
