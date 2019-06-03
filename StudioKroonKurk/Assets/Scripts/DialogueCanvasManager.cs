using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueCanvasManager : MonoBehaviour
{
	public Transform objParent;
	public DialogTextPrefab prefab, currentElement, previousElement;
	private DialogTextPrefab objectToDelete;
	public Transform highPos, lowPos;

	public void ResetOptions()
	{
		if(currentElement != null)
			Destroy(currentElement.gameObject);
		if(previousElement != null)
			Destroy(previousElement.gameObject);

		objectToDelete = null;
	}

	// Single button setup
	public void CreateNewOption(string t, string text = "Volgende")
	{
		DialogTextPrefab newPrefab = Instantiate(prefab, objParent);
		newPrefab.Init(t, text);
		newPrefab.gameObject.SetActive(false);

		objectToDelete = previousElement;
		if(objectToDelete != null)
			Destroy(objectToDelete.gameObject);

		previousElement = currentElement;
		currentElement = newPrefab;

		currentElement.gameObject.SetActive(true);
		if(previousElement == null)
		{
			currentElement.FadeInElement(0.3f);
		}
		else
			StartCoroutine(MoveOptionDownQueue());
	}

	// Double button setup
	public void CreateNewOption(string t, string left, string right)
	{
		DialogTextPrefab newPrefab = Instantiate(prefab, objParent);
		newPrefab.Init(t, left, right);
		newPrefab.gameObject.SetActive(false);

		objectToDelete = previousElement;
		if(objectToDelete != null)
			Destroy(objectToDelete.gameObject);

		previousElement = currentElement;
		currentElement = newPrefab;

		currentElement.gameObject.SetActive(true);
		if(previousElement == null)
		{
			currentElement.FadeInElement(0.3f);
		}
		else
			StartCoroutine(MoveOptionDownQueue());
	}

	public void SetButtonFunctions(UnityAction mainButton)
	{
		currentElement.mainButton.onClick.RemoveAllListeners();
		currentElement.mainButton.onClick.AddListener(mainButton);
	}

	public void SetButtonFunctions(UnityAction leftButton, UnityAction rightButton)
	{
		currentElement.leftButton.onClick.RemoveAllListeners();
		currentElement.leftButton.onClick.AddListener(leftButton);

		currentElement.rightButton.onClick.RemoveAllListeners();
		currentElement.rightButton.onClick.AddListener(rightButton);
	}

	private IEnumerator MoveOptionDownQueue()
	{
		if(previousElement != null)
			previousElement.FadeToSmall(0.3f);

		yield return new WaitForSeconds(1.5f);

		// Move over old option
		float curTime = 0f;
		float panTime = 0.3f;

		while(true)
		{
			yield return null;
			curTime += Time.deltaTime;

			previousElement.transform.localPosition = Vector3.Lerp(lowPos.localPosition, highPos.localPosition, curTime / panTime);
			previousElement.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 0.5f, curTime / panTime);

			if(curTime > panTime)
			{
				break;
			}
		}

		// Fade in new option
		if(currentElement != null)
			currentElement.FadeInElement(0.3f);
		// End
	}
}
