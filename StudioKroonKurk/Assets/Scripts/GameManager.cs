using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	//Dialog manager
	//UI manager
	private bool isGameStateOpen = true;

	public static GameManager instance;

	public List<DialogEntity> allOptions = new List<DialogEntity>();
	public List<int> allEndLeafIDs = new List<int>();
	
	public Dictionary<int, bool> questList = new Dictionary<int, bool>();
	public Dictionary<int, bool> itemList = new Dictionary<int, bool>();

	public GameObject canvas;

	public Text display;

	public Button button;

	public DialogEntity currentDialog, previousDialog;

	public void Awake()
	{
		if(instance == null)
			instance = this;
		else
			Debug.LogError("Too many GameManagers in scene");
	}

	public void Start()
	{
		DebugFunction();
	}

	public void DebugFunction()
	{
		allOptions.Add(new DialogText(0, 1, "dialog1 reached"));
		allOptions.Add(new DialogText(1, 2, "dialog2 reached"));
		allOptions.Add(new DialogText(3, 4, "gate1 passed"));
		allOptions.Add(new DialogText(4, 5, "dialog4 reached"));

		allOptions.Add(new ItemGate(2, 3, 199, 0));
		allOptions.Add(new ItemGate(5, 8, 199, 1));

		allOptions.Add(new DialogText(199, 200, "Item missing"));
		allOptions.Add(new ReturnControl(200));

		allOptions.Add(new DialogText(10, 11, "dialog11 reached"));
		allOptions.Add(new DialogText(11, 12, "dialog12 reached"));
		allOptions.Add(new DialogText(13, 14, "gate11 passed"));
		allOptions.Add(new DialogText(14, 15, "dialog14 reached"));
		allOptions.Add(new ItemGate(12, 13, 199, 10));
		allOptions.Add(new ItemGate(15, 18, 199, 11));

		itemList.Add(0, true);
		itemList.Add(1, false);

		itemList.Add(10, true);
		itemList.Add(11, false);

		foreach(DialogEntity e in allOptions)
		{
			if(e is ReturnControl)
				allEndLeafIDs.Add(e.id);
		}
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space))
		{
			if(isGameStateOpen)
			{
				SetNewDialogOption(0);
				CloseGameState();
			}
		}
		if(Input.GetKeyDown(KeyCode.Y))
		{
			if(isGameStateOpen)
			{
				SetNewDialogOption(10);
				CloseGameState();
			}
		}
	}

	// Pass this in callbacks
	public void SetNewDialogOption(int i)
	{
		// "Crashes" the dialog if a value is called which doesnt exist.
		// Also throws out if an end leaf is reached.
		if(!IsIdInRegistry(i) || allEndLeafIDs.Contains(i))
		{
			OpenGamestate();
			return;
		}

		previousDialog = currentDialog;
		currentDialog = GetEntityById(i);

		if(currentDialog is DialogText)
			SetupUI(currentDialog as DialogText);
		else
		{
			// If it's not a dialog option (or choice), execute immediately
			SetNewDialogOption(currentDialog.GetNextId());
			return;
		}
		// fallback initialisation
		button.onClick.RemoveAllListeners();
		button.onClick.AddListener(() => SetNewDialogOption(currentDialog.GetNextId()));
	}

	public void SetupUI(DialogText option)
	{
		display.text = option.text;
	}

	public void EndLeafFunction()
	{
		// Clean up dialog here
		CloseGameState();
	}

	public void CloseGameState()
	{
		// Requires reference to player controls (pathfinding component)
		// Shut off player controls here
		isGameStateOpen = false;
		canvas.SetActive(true);
	}

	public void OpenGamestate()
	{
		// Finish up dialog as far as that is needed
		// Re-enable player movement
		isGameStateOpen = true;
		canvas.SetActive(false);
	}

	public bool IsIdInItems(int i)
	{
		if(!itemList.ContainsKey(i))
			return false;

		return itemList[i];
	}

	public bool IsIdInQuests(int i)
	{
		if(!questList.ContainsKey(i))
			return false;

		return questList[i];
	}

	public bool IsIdInRegistry(int i)
	{
		foreach(DialogEntity e in allOptions)
		{
			if(e.id == i)
				return true;
		}
		return false;
	}

	public DialogEntity GetEntityById(int i)
	{
		foreach(DialogEntity e in allOptions)
		{
			if(e.id == i)
				return e;
		}
		return null;
	}
}
