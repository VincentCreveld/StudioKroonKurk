using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeMeshGroup : MonoBehaviour
{
    public List<MeshRenderer> leaves;
	public List<MeshRenderer> treeBallsOpaque;
	public List<MeshRenderer> treeBallsTransparent;

	public Transform opaques, transparents;

	public bool isFaded { get; private set; }
	public bool startedFade { get; private set; }

	private float curAlpha = 1f;
	private float fadedAlpha = 0.2f;
	private float totalTime = 0.5f;

	public void Fadeout()
	{
		if(!isFaded)
		{
			if(treeBallsTransparent != null && treeBallsTransparent.Count > 0)
				StartCoroutine(FadeOut());
		}
	}

	private IEnumerator FadeOut()
	{
		float curTime = Mathf.Lerp(0, totalTime, Mathf.InverseLerp(1f, fadedAlpha, curAlpha)); ;

		startedFade = true;

		opaques.gameObject.SetActive(false);
		transparents.gameObject.SetActive(true);

		while(true)
		{
			yield return null;
			curTime += Time.deltaTime;

			curAlpha = Mathf.Lerp(1f, fadedAlpha, curTime / totalTime);

			foreach(Renderer r in treeBallsTransparent)
			{
				foreach(Material m in r.materials)
				{
					Color c = m.color;

					m.color = new Color(c.r, c.g, c.b, curAlpha);
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
		if(isFaded)
		{
			if(treeBallsTransparent != null && treeBallsTransparent.Count > 0)
				StartCoroutine(FadeIn());
		}
	}

	private IEnumerator FadeIn()
	{
		float curTime = Mathf.Lerp(0, totalTime, Mathf.InverseLerp(fadedAlpha, 1f, curAlpha));

		startedFade = true;

		while(true)
		{
			yield return null;
			curTime += Time.deltaTime;

			curAlpha = Mathf.Lerp(fadedAlpha, 1f, curTime / totalTime);

			foreach(Renderer r in treeBallsTransparent)
			{
				foreach(Material m in r.materials)
				{
					Color c = m.color;

					m.color = new Color(c.r, c.g, c.b, curAlpha);
				}
			}

			if(curTime > totalTime)
				break;
		}

		opaques.gameObject.SetActive(true);
		transparents.gameObject.SetActive(false);

		startedFade = false;
		isFaded = false;
	}

	public void StopFading()
	{
		StopAllCoroutines();
		startedFade = false;
		isFaded = !isFaded;
	}
}
