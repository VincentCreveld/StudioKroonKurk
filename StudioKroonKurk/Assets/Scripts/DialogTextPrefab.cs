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
	public Color idleButtonColor, fadedTextElement, selectedButtonColor, hiddenButtonColor, playerBackdrop, mainBackdrop;

	private bool isPlayer = false;

	public bool isLeft = false;

	public bool IsLeft { get => isLeft; set => isLeft = value; }

	public void SetIsLeft(bool isL)
	{
		IsLeft = isL;
	}

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

        if (t == string.Empty || t.Length < 2)
        {
            mainText.gameObject.SetActive(false);
            backdrop.gameObject.SetActive(false);
        }

		mainText.text = t;
		midButtonText.text = mid;

		if(isPlayer)
			backdrop.color = playerBackdrop;
		else
			backdrop.color = mainBackdrop;

		this.isPlayer = isPlayer;

		midButtonObj.SetActive(true);
		leftButtonObj.SetActive(false);
		rightButtonObj.SetActive(false);
	}

	// Used for double button setups
	public void Init(string t, string left, string right, bool isPlayer = false)
	{
		type = UITypes.twoButton;

        if (t == string.Empty || t.Length < 2)
        {
            mainText.gameObject.SetActive(false);
            backdrop.gameObject.SetActive(false);
        }

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

	public void FadeInElement(float timeBetweenElements, bool useDelay = false)
	{
		StartCoroutine(FadeInSelection(timeBetweenElements, useDelay));
	}

	private IEnumerator FadeTextElement(Image img, Text t, float panTime, Color targCol, float toAlphaText = 1f, bool useDelay = false)
	{
		if(useDelay)
			yield return new WaitForSeconds(0.15f);
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
			img.color = c;
			t.color = new Color(t.color.r, t.color.g, t.color.b, at);

			if(curTime > panTime)
				break;
		}
		t.color = new Color(t.color.r, t.color.g, t.color.b, toAlpha);
		img.color = targCol;
	}

	private IEnumerator FadeInSelection(float timeBetweenElements, bool useDelay)
	{
        if (!(mainText.text == string.Empty || mainText.text.Length < 2))
            yield return StartCoroutine(FadeTextElement(backdrop, mainText, 0.3f, (isPlayer) ? selectedButtonColor : mainBackdrop, 1f, useDelay));
		GameManager.instance.FlipCameraFocus(isPlayer);

		if(mainText.text != string.Empty)
			GameManager.instance.TalkAnim(isPlayer);

		if(type == UITypes.singleButton)
			yield return StartCoroutine(FadeTextElement(midButtonBackdrop, midButtonText, 0.3f, selectedButtonColor));
		else
		{
			yield return StartCoroutine(FadeTextElement(rightButtonBackdrop, rightButtonText, 0.3f, selectedButtonColor));
			yield return StartCoroutine(FadeTextElement(leftButtonBackdrop, leftButtonText, 0.3f, selectedButtonColor));
		}

		EnableButtonFunctionality();
	}

	public void FadeToSmall(float t, bool isLeft = false)
	{
		DisableButtonFunctionality();
		StartCoroutine(FadeSelectionToSmall(t));
	}

	public IEnumerator FadeSelectionToSmall(float timeBetweenElements)
	{
		yield return null;

        if(!(mainText.text == string.Empty || mainText.text.Length < 2))
		    StartCoroutine(FadeTextElement(backdrop, mainText, timeBetweenElements, (isPlayer) ? hiddenButtonColor : fadedTextElement, idleButtonColor.a));

		if(type == UITypes.singleButton)
			StartCoroutine(FadeTextElement(midButtonBackdrop, midButtonText, timeBetweenElements, new Color(0,0,0,0), 0));
		else
		{
			StartCoroutine(FadeTextElement(leftButtonBackdrop, leftButtonText, (IsLeft) ? timeBetweenElements : 0, (IsLeft) ? selectedButtonColor : hiddenButtonColor, (IsLeft) ? selectedButtonColor.a : hiddenButtonColor.a));
			yield return StartCoroutine(FadeTextElement(rightButtonBackdrop, rightButtonText, (!IsLeft) ? timeBetweenElements : 0, (!IsLeft) ? selectedButtonColor : hiddenButtonColor, (!IsLeft) ? selectedButtonColor.a : hiddenButtonColor.a));

			leftButtonObj.SetActive(IsLeft);
			rightButtonObj.SetActive(!IsLeft);

			if(!IsLeft)
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
