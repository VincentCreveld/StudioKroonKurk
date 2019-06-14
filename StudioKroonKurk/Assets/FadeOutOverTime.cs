using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutOverTime : MonoBehaviour
{
	public Image imgToFade;
	public GameObject entryButton, exitButton;
	public Color activeColor;
	private Color inactiveColor;

	public float hoverTime = 1f;
	public float fadeOutTime = 1.5f;

	public void Start()
	{
		inactiveColor = activeColor;
		inactiveColor.a = 0;
	}

	public void SpawnImage()
	{
		StopAllCoroutines();
		StartCoroutine(FadeImage());
	}

	public void CloseOption()
	{
		StopAllCoroutines();
		entryButton.SetActive(true);
		exitButton.SetActive(false);
		imgToFade.gameObject.SetActive(false);
	}

	private IEnumerator FadeImage()
	{
		imgToFade.gameObject.SetActive(true);
		imgToFade.color = activeColor;
		entryButton.SetActive(false);
		exitButton.SetActive(true);
		yield return new WaitForSeconds(hoverTime);

		float curTime = 0;

		while(true)
		{
			yield return null;

			imgToFade.color = Color.Lerp(activeColor, inactiveColor, curTime / fadeOutTime);

			curTime += Time.deltaTime;

			if(curTime > fadeOutTime)
			{
				CloseOption();
				break;
			}
		}
	}
}
