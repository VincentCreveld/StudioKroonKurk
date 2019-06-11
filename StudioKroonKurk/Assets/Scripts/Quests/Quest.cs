using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Quest : MonoBehaviour
{
	protected GameManager gm;
	protected int currentQuestProgress = -1;
	protected int questId;
	public List<string> textPerProgressionToDo = new List<string>();
	public List<string> textPerProgressionDone = new List<string>();

	protected QuestState state = QuestState.closed;

	public QuestState GetQuestState()
	{
		return state;
	}

	protected void SetQuestState(QuestState qs)
	{
		state = qs;
	}

	public int GetCurrentQuestProgress()
	{
		return currentQuestProgress;
	}

	public abstract void Initialise(int i);

	public abstract void IncrementQuestMarkerPos();
}
