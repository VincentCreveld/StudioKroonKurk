using UnityEngine;
public interface IDialogGate
{
	int IsGatePassed();
}

public interface IDialogText
{
	string GetText();
}

public enum UITypes { singleButton, twoButton }

public interface IInteracter
{
	Vector3 GetPos();
	void LookAtTarget(Vector3 target);
}