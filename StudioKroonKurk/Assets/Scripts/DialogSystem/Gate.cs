using System;

[Serializable]
public abstract class Gate : DialogEntity
{
	public int positiveResult, negativeResult, requiredItemId;
}
