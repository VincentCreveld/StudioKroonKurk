using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class FPSCounter : MonoBehaviour
{
	public Text text;
	private float deltaTime;

	private Queue<float> fpsHistory = new Queue<float>();

    private void Update()
    {
		deltaTime += Time.deltaTime - deltaTime;
		float fps = 1.0f / deltaTime;
		fpsHistory.Enqueue(fps);
		if(fpsHistory.Count > 90)
			fpsHistory.Dequeue();
		text.text = GetFPS().ToString();
    }

	private int GetFPS()
	{
		float total = 0f;

		foreach(float f in fpsHistory)
		{
			total += f;
		}

		return Mathf.CeilToInt(total / fpsHistory.Count);
	}
}
