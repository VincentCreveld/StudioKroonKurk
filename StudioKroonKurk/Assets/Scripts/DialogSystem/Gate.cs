using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gate : DialogEntity
{
	protected int positiveResult, negativeResult, requiredItemId;

	public int PositiveResult { get { return positiveResult; } }
	public int NegativeResult { get { return negativeResult; } }
	public int RequiredItemId { get { return requiredItemId; } }
}
