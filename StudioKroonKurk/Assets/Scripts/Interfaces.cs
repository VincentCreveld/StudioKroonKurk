public interface IDialogGate
{
	int IsGatePassed();
}

public interface IDialogText
{
	string GetText();
}

public enum UITypes { singleButton, twoButton }