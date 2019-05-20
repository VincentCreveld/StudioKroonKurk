using System;

[Serializable]
public class DialogText : DialogEntity, IDialogText
{
	public string text;
	public int nextId;
	public bool focusPlayer;

	public DialogText(int i, int nId, string t, bool focus = false)
	{
		focusPlayer = focus;
		id = i;
		nextId = nId;
		text = t;
		uiType = UITypes.singleButton;
	}

	public override int ExecuteNodeAndGetNextId()
	{
		return nextId;
	}

	public string GetText()
	{
		return text;
	}

	public bool IsFocusPlayer()
	{
		return focusPlayer;
	}
}
