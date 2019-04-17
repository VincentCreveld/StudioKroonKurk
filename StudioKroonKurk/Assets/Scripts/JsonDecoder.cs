using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class JsonDecoder : MonoBehaviour
{
	public TextAsset json;

	public List<DialogEntity> entities;

	private void Awake()
	{
		DecodeJson(json.text);
	}

	public void DecodeJson(string str)
	{
		DialogEntityStorageMirror mirror;


	}
}
