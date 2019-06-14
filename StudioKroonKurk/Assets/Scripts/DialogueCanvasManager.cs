using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class DialogueCanvasManager : MonoBehaviour
{
	public Transform objParent;
	public DialogTextPrefab prefab, currentElement, previousElement;
	private DialogTextPrefab elementToDelete;
	public Transform higherPos, highPos, lowPos, lowerPos;

	public void ResetOptions()
	{
		if(currentElement != null)
			Destroy(currentElement.gameObject);
		if(previousElement != null)
			Destroy(previousElement.gameObject);
		if(elementToDelete != null)
			Destroy(elementToDelete.gameObject);
	}

	// Single button setup
	public void CreateNewOption(string t, bool isPlayer = false, string text = "Volgende")
	{
		DialogTextPrefab newPrefab = Instantiate(prefab, objParent);
		newPrefab.Init(t, text, isPlayer);
		newPrefab.gameObject.SetActive(false);

		elementToDelete = previousElement;
		previousElement = currentElement;
		currentElement = newPrefab;

		currentElement.gameObject.SetActive(true);
		if(previousElement == null)
		{
			currentElement.FadeInElement(0.3f, true);
			StartCoroutine(MoveCurrentElement(0.3f));
			return;
		}
		else
			StartCoroutine(MoveOptionDownQueue());
	}

	// Double button setup
	public void CreateNewOption(string t, string left, string right, bool isPlayer = false)
	{
		DialogTextPrefab newPrefab = Instantiate(prefab, Vector3.zero, Quaternion.identity, objParent);
		newPrefab.Init(t, left, right, isPlayer);
		newPrefab.gameObject.SetActive(false);
        elementToDelete = previousElement;
		previousElement = currentElement;
		currentElement = newPrefab;

		currentElement.gameObject.SetActive(true);
		if(previousElement == null)
		{
			currentElement.FadeInElement(0.3f, true);
			StartCoroutine(MoveCurrentElement(0.3f));
			return;
		}
		else
			StartCoroutine(MoveOptionDownQueue());
	}

	private IEnumerator MoveCurrentElement(float panTime = 0.3f)
	{
		float curTime = 0;

		while(true)
		{
			yield return null;
			curTime += Time.deltaTime;
			currentElement.transform.localPosition = Vector3.Lerp(lowerPos.localPosition, lowPos.localPosition, curTime / panTime);

			if(curTime > panTime)
			{
				currentElement.transform.localPosition = lowPos.localPosition;
				break;
			}
		}
	}

	public void SetButtonFunctions(UnityAction mainButton)
	{
		currentElement.mainButton.onClick.RemoveAllListeners();
		currentElement.mainButton.onClick.AddListener(() => currentElement.DisableButtonFunctionality());
		currentElement.mainButton.onClick.AddListener(mainButton);
	}

	public void SetButtonFunctions(UnityAction leftButton, UnityAction rightButton)
	{
		currentElement.leftButton.onClick.RemoveAllListeners();
		currentElement.leftButton.onClick.AddListener(() => currentElement.DisableButtonFunctionality());
		currentElement.leftButton.onClick.AddListener(() => currentElement.SetIsLeft(true));
		currentElement.leftButton.onClick.AddListener(leftButton);

		currentElement.rightButton.onClick.RemoveAllListeners();
		currentElement.rightButton.onClick.AddListener(() => currentElement.DisableButtonFunctionality());
		currentElement.rightButton.onClick.AddListener(() => currentElement.SetIsLeft(false));
		currentElement.rightButton.onClick.AddListener(rightButton);
	}

	private IEnumerator MoveOptionDownQueue(bool isLeft = false)
	{
		float curTime = 0f;
		float panTime = 0.3f;

		//if(elementToDelete != null)
		//{
		//	elementToDelete.FadeToSmall(0.3f);

		//	while(true)
		//	{
		//		yield return null;
		//		curTime += Time.deltaTime;

		//		elementToDelete.transform.localPosition = Vector3.Lerp(highPos.localPosition, higherPos.localPosition, curTime / panTime);
		//		elementToDelete.transform.localScale = Vector3.Lerp(Vector3.one * 0.5f, Vector3.zero, curTime / panTime);

		//		if(curTime > panTime)
		//		{
		//			break;
		//		}
		//	}
		//	Destroy(elementToDelete.gameObject);
		//}


		//yield return new WaitForSeconds(0.5f);

		curTime = 0f;

		if(elementToDelete != null)
			Destroy(elementToDelete.gameObject);


		if(previousElement != null)
			previousElement.FadeToSmall(0.3f);//, isLeft);

		while(true)
		{
			yield return null;
			curTime += Time.deltaTime;

			previousElement.transform.localPosition = Vector3.Lerp(lowPos.localPosition, higherPos.localPosition, curTime / panTime);
			previousElement.transform.localScale = Vector3.Lerp(Vector3.one, /*Vector3.one * 0.5f*/ Vector3.zero, curTime / panTime);

			if(curTime > panTime)
			{
				break;
			}
		}

		curTime = 0;

		if(currentElement != null)
		{
			currentElement.FadeInElement(0.25f);

			while(true)
			{
				yield return null;
				curTime += Time.deltaTime;

				currentElement.transform.localPosition = Vector3.Lerp(lowerPos.localPosition, lowPos.localPosition, curTime / panTime);

				if(curTime > panTime)
				{
					currentElement.transform.localPosition = lowPos.localPosition;
					break;
				}
			}
		}
	}
}
