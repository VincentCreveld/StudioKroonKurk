using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestProgressUIManager : MonoBehaviour
{
	[Header("Prefab fields")]
	public ProgressUIElement uiElementPrefab;
	private ProgressUIElement newestElement, prevElement;
	private List<ProgressUIElement> allElements = new List<ProgressUIElement>();
	public float uiElementOffset;
	public float objectMargin;
	Event e;
	bool keydown;


	[Header("General references")]
	public RectTransform contentField;

	public GameObject notificationObj;
	public float bigScale, smallScale;
	public Transform animTarget;
	public Button uiButton;
	public Text uiButtonText;
	public Animator uiButtonAnim;

	public void Start()
	{
		SetContentField();
		animTarget.localScale = new Vector3(smallScale, smallScale, smallScale);
		animTarget.gameObject.SetActive(false);

		uiButton.onClick.RemoveAllListeners();
		uiButton.onClick.AddListener(OpenUI);
		uiButton.onClick.AddListener(ResetContentFieldPos);
	}

	public void OpenUI()
	{
		notificationObj.SetActive(false);
		uiButton.onClick.RemoveAllListeners();
		uiButton.onClick.AddListener(CloseUI);

		uiButtonAnim.SetTrigger("ShrinkBack");
		uiButtonText.text = "Sluiten";
		Debug.Log("opening");
		StopAllCoroutines();
		StartCoroutine(ScaleUI(false));
	}

	public void CloseUI()
	{
		uiButton.onClick.RemoveAllListeners();
		uiButton.onClick.AddListener(OpenUI);
		uiButton.onClick.AddListener(ResetContentFieldPos);
		uiButtonText.text = "Taken";

		StopAllCoroutines();
		StartCoroutine(ScaleUI(true));
	}

	private void SetContentField()
	{
		ResetContentFieldPos();
		contentField.sizeDelta = new Vector2(contentField.sizeDelta.x, allElements.Count * (uiElementOffset + objectMargin));
	}

	public void CreateNewElement(string text)
	{
		ResetContentFieldPos();

		foreach(ProgressUIElement g in allElements)
		{
			g.SetDone();
		}

		// Instance new obj
		ProgressUIElement go = Instantiate(uiElementPrefab.gameObject, contentField.transform).GetComponent<ProgressUIElement>();

		go.Init(text);

		allElements.Add(go);

		go.GetComponentInChildren<Text>().text = text;

		SetContentField();
		// Place obj to bottom obj pos + offset
		go.transform.localPosition = allElements[allElements.Count - 1].transform.localPosition - new Vector3(0, (uiElementOffset + objectMargin) * (allElements.Count - 1), 0);

		notificationObj.SetActive(true);
		uiButtonAnim.SetTrigger("OpenNotif");
	}

	public void ResetContentFieldPos()
	{
		contentField.transform.localPosition = new Vector3(contentField.transform.localPosition.x, objectMargin + (allElements.Count * (uiElementOffset + objectMargin)), 0);
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
		{
			animTarget.gameObject.SetActive(false);
			foreach(ProgressUIElement go in allElements)
			{
				go.SetSeen();
			}
		}
	}
}
