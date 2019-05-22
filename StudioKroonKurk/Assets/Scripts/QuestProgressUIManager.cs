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

	public void Start()
	{
		SetContentField();
	}

	private void SetContentField()
	{
		ResetContentFieldPos();
		contentField.sizeDelta = new Vector2(contentField.sizeDelta.x, currentUIElements.Count * (uiElementOffset + objectMargin));
	}

	//private void Update()
	//{
	//	if(Input.GetMouseButtonDown(0))
	//		CreateNewElement(t);

	//	if(Input.GetMouseButtonDown(1))
	//	{
	//		foreach(GameObject g in currentUIElements)
	//		{
	//			Destroy(g);
	//		}
	//		currentUIElements.Clear();
	//	}
	//}

	//private void OnGUI()
	//{
	//	e = Event.current;
	//	if(e.type.Equals(EventType.KeyDown) && !keydown)
	//	{
	//		keydown = true;
	//		t = e.keyCode.ToString();
	//	}

	//	if(e.type.Equals(EventType.KeyUp))
	//		keydown = false;
	//}

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

		//float yPos;

		//if(currentUIElements.Count > 0)
		//	yPos = currentUIElements[currentUIElements.Count - 1].transform.position.y;
		//else
		//	yPos = contentField.transform.localPosition.y;

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
		SetContentField();
	}

	public void ResetContentFieldPos()
	{
		contentField.transform.localPosition = new Vector3(objectMargin, objectMargin + (currentUIElements.Count * (uiElementOffset + objectMargin)), 0);
	}
}
