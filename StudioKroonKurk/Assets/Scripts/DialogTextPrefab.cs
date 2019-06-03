using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTextPrefab : MonoBehaviour
{
	public Image backdrop, leftButtonBackdrop, rightButtonBackdrop, midButtonBackdrop;
	public GameObject leftButton, rightButton, midButton;
	public Text mainText, leftButtonText, rightButtonText, midButtonText;
	private UITypes type;

	public Color idleButtonColor, selectedButtonColor, hiddenButtonColor;

	public void Start()
	{
		leftButtonBackdrop.color = idleButtonColor;
		rightButtonBackdrop.color = idleButtonColor;
		midButtonBackdrop.color = idleButtonColor;
	}

	// Used for single button setups
	public void Init(string t, string mid = "Volgende")
	{
		type = UITypes.singleButton;

		mainText.text = t;

		midButton.SetActive(true);
		leftButton.SetActive(false);
		rightButton.SetActive(false);
	}

	// Used for double button setups
	public void Init(string t, string left, string right)
	{
		type = UITypes.twoButton;

		leftButtonText.text = left;
		rightButtonText.text = right;

		midButton.SetActive(false);
		leftButton.SetActive(true);
		rightButton.SetActive(true);
	}

	public void SetPrevious(bool isLeft)
	{
		transform.localScale = new Vector3(0.7f, 0.7f, 0.7f);
		if(type == UITypes.singleButton)
		{
			midButtonBackdrop.color = selectedButtonColor;
		}
		else
		{
			SetButtons(isLeft);
			leftButton.SetActive(isLeft);
			rightButton.SetActive(!isLeft);
		}
	}

	public void SetButtons(bool isLeft)
	{
		if(isLeft)
		{
			leftButtonBackdrop.color = selectedButtonColor;
			rightButtonBackdrop.color = hiddenButtonColor;
		}
		else
		{
			rightButtonBackdrop.color = selectedButtonColor;
			leftButtonBackdrop.color = hiddenButtonColor;
		}
	}

	public void LoadButtons()
	{
		if(type == UITypes.singleButton)
		{
			midButtonBackdrop.color = selectedButtonColor;
		}
		else
		{

		}
	}

	public void FadeInElement()
	{
		StartCoroutine(FadeInSelection(0.5f));
	}

	public void FadeInMainText()
	{
		StartCoroutine(FadeTextElement(backdrop, mainText, 0.8f, 0, 1));
	}

	public void FadeInLeft()
	{
		StartCoroutine(FadeTextElement(leftButtonBackdrop, leftButtonText, 0.8f, 0, 1));
	}

	public void FadeInRight()
	{
		StartCoroutine(FadeTextElement(rightButtonBackdrop, rightButtonText, 0.8f, 0, 1));
	}

	public void FadeInMid()
	{
		StartCoroutine(FadeTextElement(midButtonBackdrop, midButtonText, 0.8f, 0, 1));
	}

	private IEnumerator FadeTextElement(Image img, Text t, float panTime, float fromAlpha, float toAlpha)
	{
		float curTime = 0;

		Color startColor = img.color;

		t.color = new Color(t.color.r, t.color.g, t.color.b, fromAlpha);
		img.color = new Color(img.color.r, img.color.g, img.color.b, fromAlpha);

		img.gameObject.SetActive(true);
		t.gameObject.SetActive(true);

		while(true)
		{
			yield return null;

			curTime += Time.deltaTime;

			Color c = Color.Lerp(hiddenButtonColor, idleButtonColor, curTime / panTime);

			float a = Mathf.Lerp(fromAlpha, toAlpha, curTime / panTime);
			c.a = a;
			img.color = c;
			t.color = new Color(t.color.r, t.color.g, t.color.b, a);

			if(curTime > panTime)
				break;
		}
		t.color = new Color(t.color.r, t.color.g, t.color.b, toAlpha);
		img.color = idleButtonColor;
	}

	private IEnumerator FadeInSelection(float timeBetweenElements)
	{
		yield return StartCoroutine(FadeTextElement(backdrop, mainText, 0.8f, 0, 1));

		yield return new WaitForSeconds(timeBetweenElements);

		if(type == UITypes.singleButton)
			yield return StartCoroutine(FadeTextElement(midButtonBackdrop, midButtonText, 0.8f, 0, 1));
		else
		{
			yield return StartCoroutine(FadeTextElement(leftButtonBackdrop, leftButtonText, 0.5f, 0, 1));
			yield return new WaitForSeconds(timeBetweenElements);
			yield return StartCoroutine(FadeTextElement(rightButtonBackdrop, rightButtonText, 0.5f, 0, 1));
		}
	}

	private IEnumerator FadeSelectionToSmall(bool isLeft)
	{
		yield return null;
	}
}
