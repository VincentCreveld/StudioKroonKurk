using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestProgressUIManager : MonoBehaviour
{
	[Header("Prefab fields")]
	public List<GameObject> currentUIElements;
	public GameObject uiElementPrefab;
	public float uiElementOffset;
	public float objectMargin;
	Event e;
	bool keydown;


	[Header("General references")]
	public RectTransform contentField;

	public string t;

	public GameObject notificationObj;
	public float bigScale, smallScale;
	public Transform animTarget;
	public GameObject openButton, closeButton;

	public void Start()
	{
		SetContentField();
		animTarget.localScale = new Vector3(smallScale, smallScale, smallScale);
		animTarget.gameObject.SetActive(false);
	}

	public void OpenUI()
	{
		notificationObj.SetActive(false);
		openButton.SetActive(false);
		closeButton.SetActive(true);

		StopAllCoroutines();
		StartCoroutine(ScaleUI(false));
	}

	public void CloseUI()
	{
		openButton.SetActive(true);
		closeButton.SetActive(false);

		StopAllCoroutines();
		StartCoroutine(ScaleUI(true));
	}

	private void SetContentField()
	{
		ResetContentFieldPos();
		contentField.sizeDelta = new Vector2(contentField.sizeDelta.x, currentUIElements.Count * (uiElementOffset + objectMargin));
	}

	public void CreateNewElement(string text)
	{
		ResetContentFieldPos();

		// Instance new obj
		GameObject go = Instantiate(uiElementPrefab, contentField.transform);

		currentUIElements.Add(go);

		// Set text of content
		if(go.GetComponentInChildren<Text>() == null)
			return;
		go.GetComponentInChildren<Text>().text = text;

		// Place obj to bottom obj pos + offset
		go.transform.localPosition = currentUIElements[currentUIElements.Count - 1].transform.localPosition - new Vector3(0, (uiElementOffset + objectMargin) * (currentUIElements.Count - 1), 0);


		if(currentUIElements.Count > 1)
		{
			Color c = currentUIElements[currentUIElements.Count - 2].GetComponent<Image>().color;
			currentUIElements[currentUIElements.Count - 2].GetComponentInChildren<Image>().color = new Color(c.r, c.g, c.b, 0.7f);
			try
			{
				currentUIElements[currentUIElements.Count - 3].GetComponentInChildren<Image>().color = new Color(c.r, c.g, c.b, 0.25f);
			}
			catch { /* Leave it */ }
		}

		// Set contentfield height
		notificationObj.SetActive(true);
		SetContentField();
	}

	public void ResetContentFieldPos()
	{
		contentField.transform.localPosition = new Vector3(objectMargin, objectMargin + (currentUIElements.Count * (uiElementOffset + objectMargin)), 0);
	}

	private IEnumerator ScaleUI(bool scaleDown = true, float animTime = 0.8f)
	{
		float curTime = 0;

		float totalTime = animTime;

		float fromVal, toVal;

		if(!scaleDown)
		{
			fromVal = smallScale;
			toVal = bigScale;
		}
		else
		{
			fromVal = bigScale;
			toVal = smallScale;
		}

		Vector3 bigVal = Vector3.one * toVal;
		Vector3 smallVal = Vector3.one * fromVal;

		curTime = Mathf.Lerp(0, totalTime, Mathf.InverseLerp(fromVal, toVal, animTarget.localScale.z));

		float startScaleX = animTarget.localScale.x;
		float startScaleY = animTarget.localScale.y;

		if(!scaleDown)
			animTarget.gameObject.SetActive(true);

		while(true)
		{
			yield return null;
			curTime += Time.deltaTime;

			animTarget.localScale = Vector3.Slerp(smallVal, bigVal, curTime / totalTime);

			if(curTime > totalTime)
				break;
		}

		if(scaleDown)
			animTarget.gameObject.SetActive(false);
	}
}
