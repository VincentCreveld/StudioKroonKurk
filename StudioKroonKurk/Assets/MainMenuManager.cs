using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
	public bool resetPrefs = true;

	public InputField input;

	public int maxNameLength = 16;
	public string defaultName = "Alex";
	private bool nameIsSet = false;

	public string levelToLoad;

	public GameObject setNameInterface;
	public GameObject nameWarning;
	public GameObject mainMenu, mainMenu1, mainMenu2;

	public GameObject mainSelection, menuSelection, statsSelection, loadingScreen;

	public GameObject objToScale;

	[ContextMenu("ResetPrefs")]
	public void ResetPrefs()
	{
		PlayerPrefs.DeleteAll();
		PlayerPrefs.SetInt("IsPlayed", 0);
	}

	private void Start()
	{
		if(Application.isEditor && resetPrefs)
			ResetPrefs();

		if(!PlayerPrefs.HasKey("IsPlayed"))
			PlayerPrefs.SetInt("IsPlayed", 0);

		if(PlayerPrefs.HasKey("PlayerName"))
			nameIsSet = true;
		SetupMainMenu();
	}

	private void SetupMainMenu()
	{
		if(nameIsSet)
		{
			mainMenu1.SetActive(false);
			mainMenu2.SetActive(true);
		}
		else
		{
			mainMenu1.SetActive(true);
			mainMenu2.SetActive(false);
		}
	}

	// String sanitising
	public void OnGUI()
	{
		string tx = input.text;
		tx = Regex.Replace(tx, @"[^a-zA-Z0-9 ]", "");
		input.text = tx;
	}

	public void OpenNameSetInterface()
	{
		nameWarning.SetActive(false);
		setNameInterface.SetActive(true);
		mainMenu.SetActive(false);
	}

	public void CloseNameSetInterface()
	{
		nameWarning.SetActive(false);
		setNameInterface.SetActive(false);
		mainMenu.SetActive(true);
		SetupMainMenu();
	}

	public void SetPlayerName()
	{
		if(input.text.Length < 3)
		{
			nameWarning.SetActive(true);
			return;
		}
		PlayerPrefs.SetString("PlayerName", input.text);
		nameIsSet = true;
		CloseNameSetInterface();
		CloseMainSelection();
		nameWarning.SetActive(false);
		SetupMainMenu();
	}

	public void ChooseDefaultName()
	{
		PlayerPrefs.SetString("PlayerName", defaultName);
		nameIsSet = true;
		CloseNameSetInterface();
		SetupMainMenu();
	}

	public void CloseMainSelection()
	{
		if(nameIsSet)
		{
			mainSelection.SetActive(false);
			menuSelection.SetActive(true);
			statsSelection.SetActive(false);
		}
		else if(!PlayerPrefs.HasKey("PlayerName") ||
			PlayerPrefs.GetString("PlayerName") == string.Empty ||
			PlayerPrefs.GetString("PlayerName") == defaultName)
		{
			OpenNameSetInterface();
		}
		SetupMainMenu();
	}

	public void CloseMainSelection2()
	{
		if(nameIsSet)
		{
			mainSelection.SetActive(false);
			menuSelection.SetActive(true);
		}
	}

	public void OpenMainSelection()
	{
		mainSelection.SetActive(true);
		menuSelection.SetActive(false);
		statsSelection.SetActive(false);
		SetupMainMenu();
	}

	public void OpenStatsSelection()
	{
		mainSelection.SetActive(false);
		menuSelection.SetActive(false);
		statsSelection.SetActive(true);
	}

	public void LoadLevel()
	{
		if(nameIsSet)
		{
			LoadLevel(levelToLoad);
		}
		else if(!PlayerPrefs.HasKey("PlayerName") ||
			PlayerPrefs.GetString("PlayerName") == string.Empty ||
			PlayerPrefs.GetString("PlayerName") == defaultName)
		{
			OpenNameSetInterface();
		}

		PlayerPrefs.SetInt("IsPlayed", 1);
	}

	public void LoadLevel(string levelToLoad)
	{
		if(levelToLoad.Length < 1 || levelToLoad == string.Empty)
			return;

		mainSelection.SetActive(false);
		menuSelection.SetActive(false);
		statsSelection.SetActive(false);
		loadingScreen.SetActive(true);

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
