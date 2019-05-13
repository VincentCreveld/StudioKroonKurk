using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
	//Dialog manager
	//UI manager
	private bool isGameStateOpen = true;

	public static GameManager instance;
	public CameraMovementManager camManager;

	public NavMeshAgent player;

	public List<DialogEntity> allOptions = new List<DialogEntity>();
	public List<int> allEndLeafIDs = new List<int>();
	
	public Dictionary<int, Quest> questList = new Dictionary<int, Quest>();
	public Dictionary<int, Item> itemList = new Dictionary<int, Item>();
	public Dictionary<int, Action> dSFuncDict = new Dictionary<int, Action>();

	public List<AnimationElement> animations;

	public GameObject canvas;

	public Text display;

	public Button button, button1, button2;

	public DialogEntity currentDialog, previousDialog;

	private DialogSystemFunctionStorage dsStorage;

	public void Awake()
	{
		Application.targetFrameRate = 60;

		if(instance == null)
			instance = this;
		else
			Debug.LogError("Too many GameManagers in scene");

		dsStorage = new DialogSystemFunctionStorage();
	}

	public void Start()
	{
		Initialise();
	}

	public void Initialise()
	{
		allOptions.Add(new DialogText(1337, 404, "Just asserting my dominance. \nMove along."));

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

		itemList.Add(0, new Item(0, "item0"));
		itemList.Add(1, new Item(1, "item1"));

		itemList.Add(10, new Item(10,"Item10"));

		CreateDebugDialog();
		CreateItemRelevantDialogs();
		CreateQuestNotReadyDialog();

		foreach(DialogEntity e in allOptions)
		{
			if(e is ReturnControl)
				allEndLeafIDs.Add(e.id);
		}
	}

	public void CreateQuestNotReadyDialog()
	{
		allOptions.Add(new DialogText(401, 404, "You are not ready for this quest yet."));
	}

	public void CreateItemRelevantDialogs()
	{
		allOptions.Add(new DialogText(403, 404, "Je ziet nog geen reden om hier \niets mee te doen."));
		//allOptions.Add(new DialogText(402, 9407, "You Pick up the item."));
		//allOptions.Add(new Function(9407, 404, 6006));
	}

	public void CreateDebugDialog()
	{
		allOptions.Add(new DialogText(7777000, 7777001, "Hey there buckaroomatey."));
		allOptions.Add(new DialogText(7777003, 404, "Skidaddle your skadoodle m8."));
		allOptions.Add(new Choice(7777001, 7777002, 7777003, "want to test animation?", "ye", "na"));
		allOptions.Add(new DelayElement(7777002, 7777004, 0));
		allOptions.Add(new DialogText(7777004, 404, "Come talk to me up here"));
		allOptions.Add(new DialogText(7777010, 404, "Good job kiddo"));
		allOptions.Add(new ReturnControl(404));
	}
	
	public void SetNewDialogOption(int i)
	{
		canvas.SetActive(true);

		AudioManager.instance.StopAudioClip();

		// "Crashes" the dialog if a value is called which doesnt exist.
		// Also throws out if an end leaf is reached.
		if(!IsIdInRegistry(i) || allEndLeafIDs.Contains(i))
		{
			OpenGamestate();
			return;
		}

		if(CheckIfAudioShouldBePlayed(i))
		{
			AudioManager.instance.PlayDialogClip(i);
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
		else if(currentDialog is DelayElement)
		{
			DoAnimation(currentDialog as DelayElement);
			canvas.SetActive(false);
		}
		else
		{
			// If it's not a text oriented option, execute immediately
			SetNewDialogOption(currentDialog.ExecuteNodeAndGetNextId());
			return;
		}
	}

	private void DoAnimation(DelayElement d)
	{
		if(animations == null || d.GetAnimId() >= animations.Count)
			return;

		AnimationElement ae = animations[d.GetAnimId()];

		if(ae == null)
			return;

		ae.nextId = d.nextId;

		ae.StartAnimation();
	}

	public bool CheckIfAudioShouldBePlayed(int id)
	{
		if(AudioManager.instance.existingAudioClips.Contains(id))
			return true;
		else
			return false;
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
		OpenGamestate();
	}

	public void CloseGameState(Transform focus)
	{
		// Requires reference to player controls (pathfinding component)
		// Shut off player controls here
		StartCoroutine(CloseGame(focus));
	}

	public IEnumerator CloseGame(Transform focus)
	{
		isGameStateOpen = false;
		yield return StartCoroutine(camManager.MoveInLoop(focus));
		canvas.SetActive(true);
	}

	public void OpenGamestate()
	{
		// Finish up dialog as far as that is needed
		// Re-enable player movement
		StartCoroutine(OpenGame());
	}

	public IEnumerator OpenGame()
	{
		canvas.SetActive(false);
		yield return StartCoroutine(camManager.MoveOutLoop());
		isGameStateOpen = true;
	}

	public bool IsIdInItems(int i)
	{
		return itemList.ContainsKey(i);
	}

	public ItemState IsItemUnlocked(int i)
	{
		if(!IsIdInItems(i))
			return ItemState.not;

		return itemList[i].GetItemState();
	}

	public bool IsIdInQuests(int i)
	{
		return questList.ContainsKey(i);
	}

	public QuestState GetQuestStateById(int i)
	{
		if(!IsIdInQuests(i))
			return QuestState.closed;
		return questList[i].GetQuestState();
	}

	public int GetQuestStepById(int i)
	{
		if(!IsIdInQuests(i))
			return -1;
		return questList[i].GetCurrentQuestProgress();
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

	public void PickupItem(int i)
	{
		if(itemList.ContainsKey(i))
			itemList[i].SetItemState(ItemState.has);
	}

	public void UseItem(int i)
	{
		if(itemList.ContainsKey(i))
			itemList[i].SetItemState(ItemState.used);
	}

	public void StartNoInteractionYetDialog(Transform focus)
	{
		CloseGameState(focus);
		SetNewDialogOption(403);
	}
	public void StartPickupItemDialog(Transform focus, int dialogToStart)
	{
		CloseGameState(focus);
		SetNewDialogOption(dialogToStart);
	}

	public void SetQuestProgressionById(int i, QuestState state)
	{

	}
}
