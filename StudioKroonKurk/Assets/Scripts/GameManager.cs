using System;
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
	public Dictionary<int, Action> dSFuncDict = new Dictionary<int, Action>();

	public GameObject canvas;

	public Text display;

	public Button button, button1, button2;

	public DialogEntity currentDialog, previousDialog;

	private DialogSystemFunctionStorage dsStorage;

	public void Awake()
	{
		if(instance == null)
			instance = this;
		else
			Debug.LogError("Too many GameManagers in scene");

		dsStorage = new DialogSystemFunctionStorage();
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
		allOptions.Add(new DialogText(14, 35, "dialog14 reached"));

		allOptions.Add(new ItemGate(12, 13, 199, 10));

		allOptions.Add(new Choice(35, 36, 21, "Go left?", "yes", "no"));
		allOptions.Add(new Choice(36, 20, 21, "Go right?", "no", "yes"));

		allOptions.Add(new DialogText(21, 200, "You went the wrong way and died."));
		allOptions.Add(new DialogText(20, 200, "You got out safely."));

		itemList.Add(0, true);
		itemList.Add(1, false);

		itemList.Add(10, true);

		CreateDebugDialog();
		CreateItemUnlockDialog();
		CreateGetItemDialog();
		CreateItemRelevantDialogs();

		foreach(DialogEntity e in allOptions)
		{
			if(e is ReturnControl)
				allEndLeafIDs.Add(e.id);
		}
	}

	public void CreateItemRelevantDialogs()
	{
		allOptions.Add(new DialogText(403, 404, "You don't see a reason to do that yet."));
		allOptions.Add(new DialogText(402, 404, "You Pick up the item."));
	}

	public void CreateDebugDialog()
	{
		allOptions.Add(new DialogText(1000, 1001, "At the end of this sequence a debug will apear"));
		allOptions.Add(new DialogText(1001, 1002, "Agree with the following statement"));
		allOptions.Add(new DialogText(1002, 2000, "Just do it"));
		allOptions.Add(new Choice(2000, 9003, 9004, "Do you agree?", "Yea sure", "lmao no"));
		allOptions.Add(new Choice(2001, 1005, 1006, "Do regret what you did?", "Yes?", "lmao no"));
		allOptions.Add(new Function(9003, 1003, 0));
		allOptions.Add(new Function(9004, 1004, 1));
		allOptions.Add(new DialogText(1003, 404, "Good boy"));
		allOptions.Add(new DialogText(1004, 2001, "Everything blew up"));
		allOptions.Add(new DialogText(1005, 404, "I hope you've learned from the experience then"));
		allOptions.Add(new DialogText(1006, 404, "You monster."));
		allOptions.Add(new ReturnControl(404));
	}

	public void CreateItemUnlockDialog()
	{
		itemList.Add(4, false);

		allOptions.Add(new Choice(2010, 6000, 6001, "Agree first", "agree", "disagree"));
		allOptions.Add(new ItemGate(6000, 1052, 7000, 4));
		allOptions.Add(new ItemGate(6001, 1051, 1053, 4));
		allOptions.Add(new Function(7000, 1050, 2));
		allOptions.Add(new DialogText(1050, 2010, "Item unlocked!"));
		allOptions.Add(new DialogText(1052, 2010, "You already have the item, you greedy bastard"));
		allOptions.Add(new DialogText(1053, 2010, "You need the item, try again"));
		allOptions.Add(new DialogText(1051, 404, "You made it, gj"));
	}

	public void CreateGetItemDialog()
	{
		questList.Add(0, false);
		itemList.Add(100, false);

		allOptions.Add(new QuestGate(8100, 1200, 1100, 0));
		allOptions.Add(new DialogText(1100, 2100, "You see that item down the road?"));
		allOptions.Add(new Choice(2100, 6100, 1102, "Will you get it for me?", "Yes", "No"));
		// Initiates the quest
		allOptions.Add(new Function(6100, 1101, 3));
		allOptions.Add(new DialogText(1101, 404, "Thanks! \nYou started the quest."));
		allOptions.Add(new DialogText(1102, 404, "Alright, I get it."));

		allOptions.Add(new DialogText(1200, 2200, "Hey! Welcome back."));
		allOptions.Add(new Choice(2200, 7101, 1202, "Do you remember what you were doing?", "Yes", "No"));
		allOptions.Add(new DialogText(1202, 404, "You were fetching me the item down the road."));
		allOptions.Add(new Choice(2201, 7100, 1211, "Will you hand me the item?", "Sure", "Not yet"));
		allOptions.Add(new ItemGate(7100, 1210, 1212, 100));
		allOptions.Add(new DialogText(1210, 404, "Thank you! \nQuest complete!"));
		allOptions.Add(new DialogText(1212, 2200, "You don't have it yet."));

		allOptions.Add(new ItemGate(7101, 2201, 1213, 100));
		allOptions.Add(new DialogText(1211, 2201, "No need to be shy."));
		allOptions.Add(new DialogText(1213, 404, "I see you don't have the item yet. \nPlease go get it for me."));
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
		if(Input.GetKeyDown(KeyCode.T))
		{
			if(isGameStateOpen)
			{
				SetNewDialogOption(1000);
				CloseGameState();
			}
		}
		if(Input.GetKeyDown(KeyCode.I))
		{
			if(isGameStateOpen)
			{
				SetNewDialogOption(2010);
				CloseGameState();
			}
		}
	}
	
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
		{
			SetupUI(currentDialog as DialogText);
		}
		else if(currentDialog is Choice)
		{
			SetupUI(currentDialog as Choice);
		}
		else
		{
			// If it's not a text oriented option, execute immediately
			SetNewDialogOption(currentDialog.ExecuteNodeAndGetNextId());
			return;
		}
	}

	public bool IsGameStateOpen()
	{
		return isGameStateOpen;
	}

	public void SetupUI(DialogText option)
	{
		button.gameObject.SetActive(true);
		button1.gameObject.SetActive(false);
		button2.gameObject.SetActive(false);

		display.text = option.text;
		button.onClick.RemoveAllListeners();
		button.onClick.AddListener(() => SetNewDialogOption(currentDialog.ExecuteNodeAndGetNextId()));
		button.GetComponentInChildren<Text>().text = "Next";
	}

	public void SetupUI(Choice choice)
	{
		button.gameObject.SetActive(false);
		button1.gameObject.SetActive(true);
		button2.gameObject.SetActive(true);


		display.text = choice.text;
		button1.GetComponentInChildren<Text>().text = choice.GetText(0);
		button2.GetComponentInChildren<Text>().text = choice.GetText(1);

		button1.onClick.RemoveAllListeners();
		button1.onClick.AddListener(() => SetNewDialogOption(choice.GetNextId(0)));

		button2.onClick.RemoveAllListeners();
		button2.onClick.AddListener(() => SetNewDialogOption(choice.GetNextId(1)));
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

	public void ExecuteFunctionById(int i)
	{
		if(dSFuncDict.ContainsKey(i))
			dSFuncDict[i].Invoke();
		else
			Debug.LogError("Called invalid function id");
	}

	public void UnlockItemById(int i)
	{
		if(itemList.ContainsKey(i))
			itemList[i] = true;
	}

	public void UnlockQuestById(int i)
	{
		if(questList.ContainsKey(i))
			questList[i] = true;
	}

	public void StartNoInteractionYetDialog()
	{
		CloseGameState();
		SetNewDialogOption(403);
	}
	public void StartPickupItemDialog()
	{
		CloseGameState();
		SetNewDialogOption(402);
	}
}
