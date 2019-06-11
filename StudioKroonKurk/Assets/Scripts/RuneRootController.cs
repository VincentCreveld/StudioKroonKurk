using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneRootController : MonoBehaviour
{
	public Material rootMat;
	private Shader rootShader;

	private void Awake()
	{
		rootShader = rootMat.shader;
	}
}
