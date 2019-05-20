using UnityEngine;
public interface IDialogGate
{
	int IsGatePassed();
}

public interface IDialogText
{
	bool IsFocusPlayer();
	string GetText();
}

public enum UITypes { singleButton, twoButton }

public interface IInteracter
{
	Vector3 GetPos();
	void LookAtTarget(Vector3 target);
}

public interface ICamControl
{
	void TakeOverCam(Vector3 moveTarg, Vector3 lookPos, float speed = 3f);
	void ReturnCamControl();
}