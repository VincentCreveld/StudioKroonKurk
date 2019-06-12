using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipImageUI : MonoBehaviour
{
	public GameObject obj1, obj2;
	private void Start()
	{
		obj1.SetActive(true);
		obj2.SetActive(false);
	}

	public void Flip()
	{
		obj1.SetActive(!obj1.activeSelf);
		obj2.SetActive(!obj2.activeSelf);
	}
}
