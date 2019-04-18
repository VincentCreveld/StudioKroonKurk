using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionQuest : Quest
{
	public List<Transform> questMarkerPositions;
	public Transform marker;
	public int questNo;

	public void Start()
	{
		Initialise(questNo);
		state = QuestState.canAccept;
	}

	// Sets up all dialog options
	public override void Initialise(int id)
	{
		gm = GameManager.instance;
		questId = id;

		gm.dSFuncDict.Add(1000, EnableMarker);
		gm.dSFuncDict.Add(1001, ()=>SetQuestState(QuestState.ongoing));
		gm.dSFuncDict.Add(1002, () => SetQuestState(QuestState.completed));
		gm.dSFuncDict.Add(1003, () => SetQuestState(QuestState.canAccept));
		gm.dSFuncDict.Add(1004, SetNextQuestMarker);

		gm.questList.Add(0, this);
		
		gm.itemList.Add(4, false);
		gm.itemList.Add(100, false);

		gm.allOptions.Add(new QuestGate(8100, 1160, 8500, 1400, 2013, 0));
		gm.allOptions.Add(new QuestStepGate(8500, 8501, 1890, 0, 1, 2, 3, 4, 5));
		gm.allOptions.Add(new QuestStepGate(8501, 1100, 1200, 0, 1));
		gm.allOptions.Add(new DialogText(1890, 1891, "You need to go speak to someone before \nyou can help me."));
		gm.allOptions.Add(new DialogText(1891, 404, "I've marked the guy you need to speak to \nto advance"));
		// Still closed
		gm.allOptions.Add(new DialogText(1400, 1401, "You need to go speak to someone before \nyou can help me."));
		gm.allOptions.Add(new DialogText(1401, 1717, "I've marked the guy you need to speak to \nto advance"));
		gm.allOptions.Add(new Function(1717, 1718, 1000));
		gm.allOptions.Add(new Function(1718, 404, 1001));

		// Open
		gm.allOptions.Add(new DialogText(1100, 2100, "You see that item down the road?"));
		// Completed
		gm.allOptions.Add(new DialogText(1160, 404, "You already helped me! \nI don't need any more help. \nThanks a bunch!"));
		gm.allOptions.Add(new Choice(2100, 6100, 1102, "Will you get it for me?", "Yes", "No"));
		// Initiates the quest
		gm.allOptions.Add(new Function(6100, 1101, 1004));
		gm.allOptions.Add(new DialogText(1101, 404, "Thanks! \nYou started the quest."));
		gm.allOptions.Add(new DialogText(1102, 404, "Alright, I get it."));
		// Ongoing
		gm.allOptions.Add(new DialogText(1200, 2200, "Hey! Welcome back."));
		gm.allOptions.Add(new Choice(2200, 7101, 1202, "Do you remember what you were doing?", "Yes", "No"));
		gm.allOptions.Add(new DialogText(1202, 404, "You were fetching me the item down the road."));
		gm.allOptions.Add(new Choice(2201, 7100, 1211, "Will you hand me the item?", "Sure", "Not yet"));
		gm.allOptions.Add(new ItemGate(7100, 1616, 1212, 100));
		gm.allOptions.Add(new Function(1616, 1617, 1002));
		gm.allOptions.Add(new Function(1617, 1210, 1004));
		gm.allOptions.Add(new DialogText(1210, 404, "Thank you! \nQuest complete!"));
		gm.allOptions.Add(new DialogText(1212, 2200, "You don't have it yet."));

		gm.allOptions.Add(new ItemGate(7101, 2201, 1213, 100));
		gm.allOptions.Add(new DialogText(1211, 2201, "No need to be shy."));
		gm.allOptions.Add(new DialogText(1213, 404, "I see you don't have the item yet. \nPlease go get it for me."));

		// NPC2 dialog
		gm.allOptions.Add(new QuestGate(8800, 2014, 8555, 2013, 2013, 0));
		//gm.allOptions.Add(new Function(6000, 6600, 1003));
		gm.allOptions.Add(new Function(6000, 2012, 1004));
		gm.allOptions.Add(new QuestStepGate(8555, 2010, 2011, 0, 0));
		gm.allOptions.Add(new Choice(2010, 6000, 404, "Want to open up the \ncollect quest?", "Do it", "Walk away"));
		gm.allOptions.Add(new DialogText(2011, 404, "I already sent you on your way.\nGo speak with the other guy."));
		gm.allOptions.Add(new DialogText(2014, 404, "Thanks, you were a big help!"));
		gm.allOptions.Add(new DialogText(2012, 404, "Quest is opened up! \nReturn to the previous guy to continue."));
		gm.allOptions.Add(new DialogText(2013, 404, "We don't have any business with eachother."));

		if(questMarkerPositions.Count > 0)
			SetNextQuestMarker();
	}

	private void EnableMarker()
	{
		marker.gameObject.SetActive(true);
	}

	private void SetNextQuestMarker()
	{
		currentQuestProgress++;
		if(currentQuestProgress > questMarkerPositions.Count - 1)
		{
			marker.gameObject.SetActive(false);
			return;
		}
		marker.position = questMarkerPositions[currentQuestProgress].position;
	}
}
