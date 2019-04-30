using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMeshGroup : MonoBehaviour
{
    public List<MeshRenderer> renderers;
	public bool isFaded { get; private set; }
	private bool startedFade;

	public void Fadeout()
	{
		if(!isFaded && !startedFade)
		{
			StopCoroutine(FadeIn());
			StartCoroutine(FadeOut());
		}
	}

	private IEnumerator FadeOut()
	{
		float curTime = 0f;
		float totalTime = 0.8f;

		startedFade = true;

		while(true)
		{
			yield return null;
			curTime += Time.deltaTime;

			float val = Mathf.Lerp(1f, 0.4f, curTime / totalTime);

			foreach(Renderer r in renderers)
			{
				foreach(Material m in r.materials)
				{
					Color c = m.color;

					m.color = new Color(c.r, c.g, c.b, val);
				}
			}

			if(curTime > totalTime)
				break;
		}
		startedFade = false;
		isFaded = true;
	}

	public void Fadein()
	{
		if(isFaded && !startedFade)
		{
			StopCoroutine(FadeOut());
			StartCoroutine(FadeIn());
		}
	}

	private IEnumerator FadeIn()
	{
		float curTime = 0f;
		float totalTime = 0.8f;

		startedFade = true;

		while(true)
		{
			yield return null;
			curTime += Time.deltaTime;

			float val = Mathf.Lerp(0.4f, 1f, curTime / totalTime);

			foreach(Renderer r in renderers)
			{
				foreach(Material m in r.materials)
				{
					Color c = m.color;

					m.color = new Color(c.r, c.g, c.b, val);
				}
			}

			if(curTime > totalTime)
				break;
		}
		startedFade = false;
		isFaded = false;
	}
}
