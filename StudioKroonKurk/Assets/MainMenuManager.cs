using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
	public InputField input;

	public int maxNameLength = 16;
	public string defaultName = "Alex";
	private bool nameIsSet = false;

	public string levelToLoad;

	public GameObject setNameInterface;
	public GameObject nameWarning;
	public GameObject mainMenu;

	public GameObject mainSelection, menuSelection;

	[ContextMenu("ResetPrefs")]
	public void ResetPrefs()
	{
		PlayerPrefs.DeleteAll();
	}

	private void Start()
	{
		if(Application.isEditor)
			ResetPrefs();
	}

	public void OnGUI()
	{
		string tx = input.text;
		tx = Regex.Replace(tx, @"[^a-zA-Z0-9 ]", "");
		input.text = tx;
	}

	public void OpenNameSetInteface()
	{
		nameWarning.SetActive(false);
		setNameInterface.SetActive(true);
		mainMenu.SetActive(false);
	}

	public void CloseNameSetInteface()
	{
		nameWarning.SetActive(false);
		setNameInterface.SetActive(false);
		mainMenu.SetActive(true);
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
		CloseNameSetInteface();
	}

	public void ChooseDefaultName()
	{
		PlayerPrefs.SetString("PlayerName", defaultName);
		nameIsSet = true;
		CloseNameSetInteface();
	}

	public void CloseMainSelection()
	{
		if(nameIsSet)
		{
			mainSelection.SetActive(false);
			menuSelection.SetActive(true);
		}
		else if(!PlayerPrefs.HasKey("PlayerName") ||
			PlayerPrefs.GetString("PlayerName") == string.Empty ||
			PlayerPrefs.GetString("PlayerName") == defaultName)
		{
			OpenNameSetInteface();
		}
	}

	public void OpenMainSelection()
	{
		mainSelection.SetActive(true);
		menuSelection.SetActive(false);
	}

	public void LoadLevel()
	{
		if(nameIsSet)
		{
			SceneManager.LoadScene(levelToLoad);
		}
		else if(!PlayerPrefs.HasKey("PlayerName") ||
			PlayerPrefs.GetString("PlayerName") == string.Empty ||
			PlayerPrefs.GetString("PlayerName") == defaultName)
		{
			OpenNameSetInteface();
		}
	}
}
