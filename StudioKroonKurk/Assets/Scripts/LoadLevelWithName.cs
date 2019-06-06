using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelWithName : MonoBehaviour
{
	public string levelName;

	public void LoadLevel()
	{
		SceneManager.LoadScene(levelName);
	}
}
