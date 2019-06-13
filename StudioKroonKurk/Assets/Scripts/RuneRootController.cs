using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneRootController : MonoBehaviour
{
	public Material rootMat;
	public string rootDirVarName = "_PulseDirection", rootTextureVarName = "_LightVeinTex", rootColorVarName = "_Color_Lightvein";
	public float positiveVal = 1.346f, negativeVal = -1.346f;
	public Color color1, color2;

    public bool startFwd = true;
    public bool startCol1 = true;
    public bool startEnabled = true;


    private void Start()
    {
        if (startFwd)
            SetFwd();
        else
            SetBwd();

        if (startCol1)
            SetColor1();
        else
            SetColor2();

        if (startEnabled)
            EnableRoots();
        else
            DisableRoots();
    }

    [ContextMenu("SetC1")]
    public void SetColor1()
    {
        rootMat.SetColor(rootColorVarName, color1);
    }

    [ContextMenu("SetC2")]
    public void SetColor2()
    {
        rootMat.SetColor(rootColorVarName, color2);
    }

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
