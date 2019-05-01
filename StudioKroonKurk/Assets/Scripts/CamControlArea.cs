using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControlArea : MonoBehaviour
{
	public Transform lookPos, movePos;

	public void OnTriggerEnter(Collider other)
	{
		if(other.GetComponent<ICamControl>() != null)
			other.GetComponent<ICamControl>().TakeOverCam(movePos.position, lookPos.position);
	}

	public void OnTriggerExit(Collider other)
	{
		if(other.GetComponent<ICamControl>() != null)
			other.GetComponent<ICamControl>().ReturnCamControl();
	}
}
