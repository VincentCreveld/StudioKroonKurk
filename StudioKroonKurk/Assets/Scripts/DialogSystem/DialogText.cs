using System;

[Serializable]
public class DialogText : DialogEntity, IDialogText
{
	public string text;
	public int nextId;

	public DialogText(int i, int nId, string t)
	{
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
}
