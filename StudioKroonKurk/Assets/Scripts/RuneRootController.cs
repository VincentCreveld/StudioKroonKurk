using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneRootController : MonoBehaviour
{
	public Material rootMat;
	public string rootDirVarName = "_PulseDirection", rootTextureVarName = "_LightVeinTex";
	public float positiveVal = 1.346f, negativeVal = -1.346f;
	
	public Color color1, color2;

	[ContextMenu("SetFwd")]
	public void SetFwd()
	{
		SetRootDir(true);
	}

	[ContextMenu("SetBwd")]
	public void SetBwd()
	{
		SetRootDir(false);
	}

	public void SetRootDir(bool isFwd)
	{
		rootMat.SetFloat(rootDirVarName, (isFwd) ? positiveVal : negativeVal);
	}

	[ContextMenu("Disable")]
	public void DisableRoots()
	{
		rootMat.SetTextureScale(rootTextureVarName, Vector2.zero);
	}

	[ContextMenu("Enable")]
	public void EnableRoots()
	{
		rootMat.SetTextureScale(rootTextureVarName, Vector2.one);
	}
}
