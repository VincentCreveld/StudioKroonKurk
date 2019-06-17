﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
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

	public GameObject mainCanvas, dialogCanvas, inspectCanvas;

	public Button inspectButton;

	public DialogEntity currentDialog, previousDialog;

	private DialogSystemFunctionStorage dsStorage;

	private Interactable currentInteractable = null;
	private bool isFocusingPlayer = true;

	public DialogueCanvasManager diaManager;

	public QuestProgressUIManager qpUImanager;

	public bool skipAnimations = false;

	// Hacky component for making talking gestures.
	public Animator jackAnimator, jackAnimator2, playerAnimator;

	// Hacky bucket interfaces
	public GameObject waterBucketCanvas, emptyBucketCanvas;
    public GameObject rootsToDisable;
    public List<GameObject> objectsToDisable = new List<GameObject>();
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
		CreateItemRelevantDialogs();
		CreateQuestNotReadyDialog();
		allOptions.Add(new ReturnControl(404));

		allOptions.Add(new InspectElement(405, 404));
		CheckForEndLeafs();
	}

	public void CheckForEndLeafs()
	{
		foreach(DialogEntity e in allOptions)
		{
			if(e is ReturnControl)
				if(!allEndLeafIDs.Contains(e.id))
					allEndLeafIDs.Add(e.id);
		}
	}

	public void SetNewQuestProgress(string text)
	{
		string t = text.Replace("<br>", "\n");
		qpUImanager.CreateNewElement(t);
	}

	public void CreateQuestNotReadyDialog()
	{
		allOptions.Add(new DialogText(401, 404, "You are not ready for this quest yet."));
	}

	public void CreateItemRelevantDialogs()
	{
		allOptions.Add(new DialogText(403, 404, "Je ziet nog geen reden om hier \niets mee te doen."));
	}

	// Probably the most important video.
	public void SetNewDialogOption(int i)
	{
		mainCanvas.SetActive(true);
		inspectCanvas.SetActive(false);
		dialogCanvas.SetActive(false);

		// Stops previous voice line
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

		// Failsafe
		if(currentDialog is ReturnControl)
		{
			OpenGamestate();
			return;
		}

		if(currentDialog is InspectElement)
		{
			SetupUI(currentDialog as InspectElement);
		}
		else if(currentDialog is DialogText)
		{
			//FlipCameraFocus((currentDialog as DialogText).IsFocusPlayer());
				
			SetupUI(currentDialog as DialogText);
		}
		else if(currentDialog is Choice)
		{
			//FlipCameraFocus((currentDialog as Choice).IsFocusPlayer());

			SetupUI(currentDialog as Choice);
		}
		else if(!skipAnimations && currentDialog is DelayElement)
		{
			DoAnimation(currentDialog as DelayElement);
			mainCanvas.SetActive(false);
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
		dialogCanvas.SetActive(true);

		diaManager.CreateNewOption(option.text, option.IsFocusPlayer());
		diaManager.SetButtonFunctions(() => SetNewDialogOption(currentDialog.ExecuteNodeAndGetNextId()));
	}

	public void SetupUI(InspectElement option)
	{
		inspectCanvas.SetActive(true);
		inspectButton.onClick.RemoveAllListeners();
		inspectButton.onClick.AddListener
			(() => 
				{
					camManager.MoveCamAmbi();
					SetNewDialogOption(currentDialog.ExecuteNodeAndGetNextId());
				}
			);
	}

	public void SetupUI(Choice choice)
	{
		dialogCanvas.SetActive(true);

		diaManager.CreateNewOption(choice.text, choice.GetText(0), choice.GetText(1), choice.IsFocusPlayer());
		diaManager.SetButtonFunctions(() => SetNewDialogOption(choice.GetNextId(0)), () => SetNewDialogOption(choice.GetNextId(1)));
	}

	public void EndLeafFunction()
	{
		// Clean up dialog here
		OpenGamestate();
	}

    [ContextMenu("OpenArea")]
    public void OpenArea()
    {
        //                1111
        player.areaMask = 15;
        rootsToDisable.SetActive(false);
    }

    [ContextMenu("CloseArea")]
    public void CloseArea()
    {
        //                0111
        player.areaMask = 7;
        rootsToDisable.SetActive(true);
    }

    [ContextMenu("CloseDialogue")]
    public void CloseDia()
    {
        SetNewDialogOption(404);
    }

	public void TalkAnim(bool isPlayer)
	{
		if(!isPlayer)
		{
			if(jackAnimator.gameObject.activeInHierarchy)
			{
				StartCoroutine(FlipTalk(jackAnimator));
			}
			if(jackAnimator2.gameObject.activeInHierarchy)
			{
				StartCoroutine(FlipTalk(jackAnimator2));
			}
		}
		else
		{
			StartCoroutine(FlipTalk(playerAnimator));
		}
	}

	private IEnumerator FlipTalk(Animator anim)
	{
		anim.SetTrigger("TalkTrigger");
		anim.SetBool("IsTalking", false);
		yield return new WaitForEndOfFrame();
		anim.SetBool("IsTalking", true);
	}

	#region GameStateRelated
	public void CloseGameState(Interactable focus)
	{
		// Requires reference to player controls (pathfinding component)
		// Shut off player controls here
		StartCoroutine(CloseGame(focus));
	}

	public void CloseGameWithoutAnim(Interactable focus)
	{
		currentInteractable = focus;
		isFocusingPlayer = false;
		isGameStateOpen = false;
		mainCanvas.SetActive(true);
	}

	public IEnumerator CloseGame(Interactable focus)
	{
		currentInteractable = focus;
		isFocusingPlayer = false;

        questList[1].DisableMarkerGraphic();


        isGameStateOpen = false;
		yield return StartCoroutine(camManager.MoveInLoop(focus.GetFocusTransform(), 0.8f));
		mainCanvas.SetActive(true);
	}

	public void OpenGameWithoutAnim()
	{
		diaManager.ResetOptions();
		currentInteractable = null;
		mainCanvas.SetActive(false);
		isGameStateOpen = true;
	}

	public void OpenGamestate()
	{
        // Finish up dialog as far as that is needed
        // Re-enable player movement
        questList[1].EnableMarkerGraphic();

        diaManager.ResetOptions();
		StartCoroutine(OpenGame());
	}

	public IEnumerator OpenGame()
	{
		currentInteractable = null;
		isFocusingPlayer = true;

		mainCanvas.SetActive(false);
		yield return StartCoroutine(camManager.MoveOutLoop(0.8f));
		isGameStateOpen = true;
	}
	#endregion

	#region ReturnFunctions
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
	#endregion

	#region Misc

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

	public void StartNoInteractionYetDialog(Interactable focus)
	{
		CloseGameState(focus);
		SetNewDialogOption(403);
	}

	public void StartPickupItemDialog(Interactable focus, bool isWaterBucket = false)
	{
		//CloseGameState(focus);
		CloseGameWithoutAnim(focus);
		if(isWaterBucket)
			waterBucketCanvas.SetActive(true);
		else
			emptyBucketCanvas.SetActive(true);

		//SetNewDialogOption(dialogToStart);
	}

	public void FlipCameraFocus(bool b)
	{
		if(currentInteractable == null || b == isFocusingPlayer)
			return;


        if (isFocusingPlayer)
            camManager.FocusCamOnTarget(currentInteractable.GetFocusTransform());
        else
            camManager.FocusCamOnTarget(player.gameObject.transform, 0.4f, true);

        isFocusingPlayer = b;
	}
	#endregion

	public void IncrementMarkerPos(int questNo)
	{
		if(questList.ContainsKey(questNo))
			questList[questNo].IncrementQuestMarkerPos();
	}

	public void EndGameScene()
	{
        camManager.fadePlane.SetActive(true);
        camManager.FadeCamInAndOut(0.6f, 1, () =>
         {
             foreach (GameObject go in objectsToDisable)
             {
                 go.SetActive(false);
             }
         });
    }
}
