using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	public GameObject objToScale;

	public void LoadLevel(string levelToLoad)
	{
		if(levelToLoad.Length < 1 || levelToLoad == string.Empty)
			return;
		StartCoroutine(OperationTracker(levelToLoad));
	}

	private IEnumerator OperationTracker(string levelToLoad)
	{
		AsyncOperation op = SceneManager.LoadSceneAsync(levelToLoad);

		Debug.Log("Started loading");

		while(!op.isDone)
		{
			objToScale.transform.localScale = new Vector3(Mathf.Clamp01(op.progress), 1, 1);
			yield return null;
		}

		Debug.Log("Done loading");
	}
}
