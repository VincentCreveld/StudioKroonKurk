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
		StartCoroutine(FadeInSelection());
	}

	public void FadeInMainText()
	{
		StartCoroutine(FadeInTextElement(backdrop, mainText, 0.8f));
	}

	public void FadeInLeft()
	{
		StartCoroutine(FadeInTextElement(leftButtonBackdrop, leftButtonText, 0.8f));
	}

	public void FadeInRight()
	{
		StartCoroutine(FadeInTextElement(rightButtonBackdrop, rightButtonText, 0.8f));
	}

	public void FadeInMid()
	{
		StartCoroutine(FadeInTextElement(midButtonBackdrop, midButtonText, 0.8f));
	}

	private IEnumerator FadeInTextElement(Image img, Text t, float panTime)
	{
		float curTime = 0;

		Color startColor = img.color;

		t.color = new Color(t.color.r, t.color.g, t.color.b, 0);
		img.color = new Color(img.color.r, img.color.g, img.color.b, 0);

		img.gameObject.SetActive(true);
		t.gameObject.SetActive(true);

		while(true)
		{
			yield return null;

			curTime += Time.deltaTime;

			Color c = Color.Lerp(hiddenButtonColor, idleButtonColor, curTime / panTime);

			float a = Mathf.Lerp(0, 1, curTime / panTime);
			c.a = a;
			img.color = c;
			t.color = new Color(t.color.r, t.color.g, t.color.b, a);

			if(curTime > panTime)
				break;
		}
		t.color = new Color(t.color.r, t.color.g, t.color.b, 1f);
		img.color = idleButtonColor;
	}

	private IEnumerator FadeInSelection(float timeBetweenElements)
	{
		yield return StartCoroutine(FadeInTextElement(backdrop, mainText, 0.8f));

		yield return new WaitForSeconds(timeBetweenElements);

		if(type == UITypes.singleButton)
			yield return StartCoroutine(FadeInTextElement(midButtonBackdrop, midButtonText, 0.8f));
		else
		{
			yield return StartCoroutine(FadeInTextElement(leftButtonBackdrop, leftButtonText, 0.5f));
			yield return new WaitForSeconds(timeBetweenElements);
			yield return StartCoroutine(FadeInTextElement(rightButtonBackdrop, rightButtonText, 0.5f));
		}
	}
}
