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

	private string targetText;
	private string defaultText = "Taken";

	public GameObject vObj, xObj, expandButtonObj, eVDownObj, eVUpObj;



	[Header("General references")]
	public RectTransform contentField, bottomPos;

	public GameObject notificationObj;
	public float smallScale, mediumScale, bigScale;
	public RectTransform animTarget;
	public Button uiButton, expandButton;
	public Text uiButtonText, expandButtonText;
	public Animator uiButtonAnim;

	public bool isUIBig = false;

	public void Start()
	{
		SetContentField();
		animTarget.sizeDelta = new Vector3(animTarget.sizeDelta.x, smallScale, 1);
		animTarget.gameObject.SetActive(false);

		expandButton.gameObject.SetActive(false);

		//SetupOpenUIButton();

		eVDownObj.SetActive(false);
		eVUpObj.SetActive(false);
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.LeftShift))
			CreateNewElement("Test");
		if(Input.GetKeyDown(KeyCode.LeftControl))
			ResetContentFieldPos();
	}

	public void OpenUI()
	{
		notificationObj.SetActive(false);
		uiButton.onClick.RemoveAllListeners();
		uiButton.onClick.AddListener(CloseUI);
		//uiButtonText.text = "Sluiten";

		StopAllCoroutines();
		if(allElements.Count > 1)
			StartCoroutine(ScaleUI(animTarget.sizeDelta.y, mediumScale, false));
		else
			StartCoroutine(ScaleUI(animTarget.sizeDelta.y, 290, false));

		expandButton.onClick.RemoveAllListeners();
		expandButton.onClick.AddListener(ExpandUI);
		expandButtonText.text = "Meer laden";

		if(allElements.Count > 1)
		{
			expandButtonObj.SetActive(true);
			eVDownObj.SetActive(true);
			eVUpObj.SetActive(false);
		}
		else
		{
			expandButtonObj.SetActive(false);
			vObj.SetActive(false);
			xObj.SetActive(false);
		}


	}

	public void ExpandUI()
	{
		expandButton.onClick.RemoveAllListeners();
		expandButton.onClick.AddListener(UnexpandUI);
		expandButtonText.text = "Invouwen";

		eVDownObj.SetActive(false);
		eVUpObj.SetActive(true);

		expandButtonObj.gameObject.SetActive(false);
		StopAllCoroutines();
		StartCoroutine(ScaleUI(animTarget.sizeDelta.y, bigScale, false));

		isUIBig = true;
	}

	public void UnexpandUI()
	{
		expandButton.onClick.RemoveAllListeners();
		expandButton.onClick.AddListener(ExpandUI);
		expandButtonText.text = "Meer laden";

		eVDownObj.SetActive(true);
		eVUpObj.SetActive(false);

		expandButtonObj.gameObject.SetActive(false);
		StopAllCoroutines();
		StartCoroutine(ScaleUI(animTarget.sizeDelta.y, mediumScale, false));

		isUIBig = false;
	}

	public void CloseUI()
	{
		if(allElements.Count > 1)
			SetupOpenUIButton();

		StopAllCoroutines();
		StartCoroutine(ScaleUI(animTarget.sizeDelta.y, smallScale, true));

		expandButtonObj.SetActive(false);

		if(allElements.Count > 1)
		{
			vObj.SetActive(true);
			xObj.SetActive(false);
		}
		else
		{
			vObj.SetActive(false);
			xObj.SetActive(false);
		}
	}

	private void SetupOpenUIButton()
	{
		uiButton.onClick.RemoveAllListeners();
		uiButton.onClick.AddListener(OpenUI);
		uiButton.onClick.AddListener(ResetContentFieldPos);
	}

	private void SetContentField()
	{
		contentField.sizeDelta = new Vector2(contentField.sizeDelta.x, allElements.Count * (uiElementOffset + objectMargin));
		ResetContentFieldPos();
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

		go.Init(text.ToUpper());

		allElements.Add(go);

		go.GetComponentInChildren<Text>().text = text;

		SetContentField();

		// Place obj to bottom obj pos + offset
		go.transform.localPosition = allElements[0].transform.localPosition + new Vector3(0, -30 -(uiElementOffset + objectMargin) * -(allElements.Count - 1), 0);

		notificationObj.SetActive(true);
		uiButtonAnim.SetTrigger("OpenNotif");
		targetText = text;
		uiButtonText.text = targetText;

		CloseUI();

		if(allElements.Count > 1)
			SetupOpenUIButton();
	}

	public void ResetContentFieldPos()
	{
		contentField.transform.localPosition = new Vector3(0, (uiElementOffset + objectMargin) * -(allElements.Count - 1), 0);
	}

	private IEnumerator ScaleUI(float startVal, float targVal, bool scaleDown = true, float animTime = 0.8f)
	{
		float curTime = 0;

		float totalTime = animTime;

		float fromVal, toVal;

		fromVal = startVal;
		toVal = targVal;
	
		Vector3 bigVal = new Vector3(animTarget.sizeDelta.x, toVal, 1);
		Vector3 smallVal = new Vector3(animTarget.sizeDelta.x, fromVal, 1);

		curTime = Mathf.Lerp(0, totalTime, Mathf.InverseLerp(fromVal, toVal, animTarget.sizeDelta.y));

		if(!scaleDown)
			animTarget.gameObject.SetActive(true);

		while(true)
		{
			yield return null;
			curTime += Time.deltaTime;

			animTarget.sizeDelta = Vector3.Lerp(smallVal, bigVal, curTime / totalTime);

			if(curTime > totalTime)
			{
				animTarget.sizeDelta = bigVal;
				break;
			}
		}

		if(scaleDown)
		{
			animTarget.gameObject.SetActive(false);
			foreach(ProgressUIElement go in allElements)
			{
				go.SetSeen();
			}
		}
		else
		{
			if(allElements.Count > 1)
				expandButtonObj.SetActive(true);
			else
				expandButtonObj.SetActive(false);
		}
	}
}
