using System;
using System.Collections.Generic;

[Serializable]
public class DialogEntityStorageMirror
{
	public List<Choice> choiceEntities;
	public List<DialogText> textOptions;
	public List<ItemGate> itemGates;
	public List<QuestGate> questGates;
	public List<ReturnControl> returnControls;
}
