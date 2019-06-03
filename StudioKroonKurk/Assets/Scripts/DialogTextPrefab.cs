using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogTextPrefab : MonoBehaviour
{
	public Image backdrop, leftButtonBackdrop, rightButtonBackdrop, midButtonBackdrop;
	public GameObject leftButtonObj, rightButtonObj, midButtonObj;
	public Text mainText, leftButtonText, rightButtonText, midButtonText;
	public Button mainButton, leftButton, rightButton;
	private UITypes type;
	public Transform highPos;
	public Color idleButtonColor, selectedButtonColor, hiddenButtonColor, playerBackdrop, mainBackdrop;

	public enum DialogButtonState { none, left, right }
	private DialogButtonState buttonState = DialogButtonState.none;

	public void Start()
	{
		backdrop.color = new Color(backdrop.color.r, backdrop.color.g, backdrop.color.b, 0);
		leftButtonBackdrop.color = new Color(leftButtonBackdrop.color.r, leftButtonBackdrop.color.g, leftButtonBackdrop.color.b, 0);
		rightButtonBackdrop.color = new Color(rightButtonBackdrop.color.r, rightButtonBackdrop.color.g, rightButtonBackdrop.color.b, 0);
		midButtonBackdrop.color = new Color(midButtonBackdrop.color.r, midButtonBackdrop.color.g, midButtonBackdrop.color.b, 0);

		mainText.color = new Color(mainText.color.r, mainText.color.g, mainText.color.b, 0);
		leftButtonText.color = new Color(leftButtonText.color.r, leftButtonText.color.g, leftButtonText.color.b, 0);
		rightButtonText.color = new Color(rightButtonText.color.r, rightButtonText.color.g, rightButtonText.color.b, 0);
		midButtonText.color = new Color(midButtonText.color.r, midButtonText.color.g, midButtonText.color.b, 0);

		DisableButtonFunctionality();
	}

	// Used for single button setups
	public void Init(string t, string mid = "Volgende", bool isPlayer = false)
	{
		type = UITypes.singleButton;

		mainText.text = t;
		midButtonText.text = mid;

		if(isPlayer)
			backdrop.color = playerBackdrop;
		else
			backdrop.color = mainBackdrop;

		midButtonObj.SetActive(true);
		leftButtonObj.SetActive(false);
		rightButtonObj.SetActive(false);
	}

	// Used for double button setups
	public void Init(string t, string left, string right, bool isPlayer = false)
	{
		type = UITypes.twoButton;

		mainText.text = t;
		leftButtonText.text = left;
		rightButtonText.text = right;

		if(isPlayer)
			backdrop.color = playerBackdrop;

		midButtonObj.SetActive(false);
		leftButtonObj.SetActive(true);
		rightButtonObj.SetActive(true);
	}

	public void EnableButtonFunctionality()
	{
		mainButton.interactable = true;
		leftButton.interactable = true;
		rightButton.interactable = true;
	}

	public void DisableButtonFunctionality()
	{
		mainButton.interactable = false;
		leftButton.interactable = false;
		rightButton.interactable = false;
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
			buttonState = (isLeft) ? DialogButtonState.left : DialogButtonState.right;
			SetButtons(isLeft);
			leftButtonObj.SetActive(isLeft);
			rightButtonObj.SetActive(!isLeft);
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

	public void FadeInElement(float timeBetweenElements)
	{
		StartCoroutine(FadeInSelection(timeBetweenElements));
	}

	public void FadeInMainText()
	{
		//StartCoroutine(FadeTextElement(backdrop, mainText, 0.8f, 0, 1, mainBackdrop));
		StartCoroutine(FadeTextElement(backdrop, mainText, 0.8f, mainBackdrop));
	}

	public void FadeInLeft()
	{
		//StartCoroutine(FadeTextElement(leftButtonBackdrop, leftButtonText, 0.8f, 0, 1, selectedButtonColor));
		StartCoroutine(FadeTextElement(leftButtonBackdrop, leftButtonText, 0.8f, selectedButtonColor));
	}

	public void FadeInRight()
	{
		//StartCoroutine(FadeTextElement(rightButtonBackdrop, rightButtonText, 0.8f, 0, 1, selectedButtonColor));
		StartCoroutine(FadeTextElement(rightButtonBackdrop, rightButtonText, 0.8f, selectedButtonColor));
	}

	public void FadeInMid()
	{
		//StartCoroutine(FadeTextElement(midButtonBackdrop, midButtonText, 0.8f, 0, 1, selectedButtonColor));
		StartCoroutine(FadeTextElement(midButtonBackdrop, midButtonText, 0.8f, selectedButtonColor));
	}

	private IEnumerator FadeTextElement(Image img, Text t, float panTime, Color targCol, float toAlphaText = 1f)
	{
		// Initial delay
		yield return new WaitForSeconds(0.3f);
		float curTime = 0;

		float fromAlpha = img.color.a;
		float fromAlphaText = t.color.a;
		float toAlpha = targCol.a;

		t.color = new Color(t.color.r, t.color.g, t.color.b, fromAlpha);
		img.color = new Color(img.color.r, img.color.g, img.color.b, fromAlpha);

		Color startCol = img.color;

		img.gameObject.SetActive(true);
		t.gameObject.SetActive(true);

		while(true)
		{
			yield return null;

			curTime += Time.deltaTime;

			Color c = Color.Lerp(startCol, targCol, curTime / panTime);

			float a = Mathf.Lerp(fromAlpha, toAlpha, curTime / panTime);
			float at = Mathf.Lerp(fromAlphaText, toAlphaText, curTime / panTime);
			//c.a = a;
			img.color = c;
			t.color = new Color(t.color.r, t.color.g, t.color.b, at);

			if(curTime > panTime)
				break;
		}
		t.color = new Color(t.color.r, t.color.g, t.color.b, toAlpha);
		img.color = targCol;
	}

	private IEnumerator FadeInSelection(float timeBetweenElements)
	{
		//yield return StartCoroutine(FadeTextElement(backdrop, mainText, 0.4f, 0, 1, hiddenButtonColor));
		yield return StartCoroutine(FadeTextElement(backdrop, mainText, 0.4f, mainBackdrop, 1f));

		//yield return new WaitForSeconds(timeBetweenElements);

		if(type == UITypes.singleButton)
			yield return StartCoroutine(FadeTextElement(midButtonBackdrop, midButtonText, 0.4f, selectedButtonColor));
			//yield return StartCoroutine(FadeTextElement(midButtonBackdrop, midButtonText, 0.4f, 0, 1, selectedButtonColor));
		else
		{
			yield return StartCoroutine(FadeTextElement(leftButtonBackdrop, leftButtonText, 0.1f, selectedButtonColor));
			//yield return StartCoroutine(FadeTextElement(leftButtonBackdrop, leftButtonText, 0.1f, 0, 1, selectedButtonColor));
			//yield return new WaitForSeconds(timeBetweenElements);
			yield return StartCoroutine(FadeTextElement(rightButtonBackdrop, rightButtonText, 0.1f, selectedButtonColor));
			//yield return StartCoroutine(FadeTextElement(rightButtonBackdrop, rightButtonText, 0.1f, 0, 1, selectedButtonColor));
		}

		EnableButtonFunctionality();
	}

	public void FadeToSmall(float t)
	{
		DisableButtonFunctionality();
		StartCoroutine(FadeSelectionToSmall(t));
	}

	public IEnumerator FadeSelectionToSmall(float timeBetweenElements)
	{
		bool isLeft = (buttonState == DialogButtonState.left);

		StartCoroutine(FadeTextElement(backdrop, mainText, 0.5f, idleButtonColor, idleButtonColor.a));
		//StartCoroutine(FadeTextElement(backdrop, mainText, 0.4f, 1, 0.5f, idleButtonColor));

		if(type == UITypes.singleButton)
			yield return StartCoroutine(FadeTextElement(midButtonBackdrop, midButtonText, 0.5f, new Color(0,0,0,0), 0));
			//yield return StartCoroutine(FadeTextElement(midButtonBackdrop, midButtonText, 0.4f, 1, 0.5f, selectedButtonColor));
		else
		{
			StartCoroutine(FadeTextElement(leftButtonBackdrop, leftButtonText, (isLeft) ? 0.5f : 0, (isLeft) ? selectedButtonColor : hiddenButtonColor, (isLeft) ? selectedButtonColor.a : hiddenButtonColor.a));
			//StartCoroutine(FadeTextElement(leftButtonBackdrop, leftButtonText, 0.2f, 1, (isLeft) ? 0.5f : 0, (isLeft) ? selectedButtonColor : hiddenButtonColor));
			yield return StartCoroutine(FadeTextElement(rightButtonBackdrop, rightButtonText, (!isLeft) ? 0.5f : 0, (!isLeft) ? selectedButtonColor : hiddenButtonColor, (!isLeft) ? selectedButtonColor.a : hiddenButtonColor.a));
			//yield return StartCoroutine(FadeTextElement(rightButtonBackdrop, rightButtonText, 0.2f, 1, (!isLeft) ? 0.5f : 0, (!isLeft) ? selectedButtonColor : hiddenButtonColor));

			leftButtonObj.SetActive(isLeft);
			rightButtonObj.SetActive(!isLeft);

			if(!isLeft)
			{
				float curTime = 0f;
				float panTime = 0.3f;
				Vector3 startPos = rightButtonObj.transform.localPosition;
				while(true)
				{
					yield return null;
					curTime += Time.deltaTime;
					rightButtonObj.transform.localPosition = Vector3.Lerp(startPos, highPos.localPosition, curTime / panTime);
					if(curTime > panTime)
					{
						rightButtonObj.transform.localPosition = highPos.localPosition;
						break;
					}
				}
			}
		}
	}
}
