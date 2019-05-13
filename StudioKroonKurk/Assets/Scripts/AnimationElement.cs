using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationElement : MonoBehaviour
{
	private Animator anim;
	public int nextId;

	public List<GameObject> activesToFlipStart = new List<GameObject>();
	public List<GameObject> activesToFlipEnd = new List<GameObject>();

	private void Awake()
	{
		anim = GetComponent<Animator>();
	}

	[ContextMenu("StartAnim")]
	public void StartAnimation()
	{
		anim.SetTrigger("Start");
		foreach(GameObject g in activesToFlipStart)
		{
			g.SetActive(!g.activeSelf);
		}
	}

	public void ContinueDialog()
	{
		foreach(GameObject g in activesToFlipEnd)
		{
			g.SetActive(!g.activeSelf);
		}
		Debug.Log("here");
		GameManager.instance.SetNewDialogOption(nextId);
	}
}
