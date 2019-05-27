using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressUIElement : MonoBehaviour
{
	public GameObject newObject, progressObj, doneObject;
	public Text textElement;
	public Image backgroundElement;
	public Color newColor, seenColor, doneColor;
	private bool isDone = false;

	public void Init(string text)
	{
		newObject.SetActive(true);
		progressObj.SetActive(false);
		doneObject.SetActive(false);
		textElement.text = text;
		backgroundElement.color = newColor;
	}

	public void SetSeen()
	{
		if(isDone)
			return;
		newObject.SetActive(false);
		progressObj.SetActive(true);
		backgroundElement.color = seenColor;
	}

	public void SetDone()
	{
		isDone = true;
		progressObj.SetActive(false);
		doneObject.SetActive(true);
		backgroundElement.color = doneColor;
	}
}
