using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// This script fades out the obstructing objects between the player and the camera.
public class ObjectClipping : MonoBehaviour
{
	public LayerMask mask;
	public Transform playerObj, camObj;
	private TreeMeshGroup prevTree;

	private List<TreeMeshGroup> currentTrees = new List<TreeMeshGroup>();
	private List<TreeMeshGroup> prevTrees = new List<TreeMeshGroup>();
	private List<TreeMeshGroup> tmgs = new List<TreeMeshGroup>();
	private List<RaycastHit> hits = new List<RaycastHit>();

	private void Update()
    {
		Ray r = new Ray(camObj.position, playerObj.position - camObj.position);
		float dist = Vector3.Distance(playerObj.position, camObj.position);
		hits = Physics.RaycastAll(r, dist + 0.5f, mask).ToList();
		List<TreeMeshGroup> tmgs = new List<TreeMeshGroup>();

		foreach(RaycastHit hit in hits)
		{
			if(hit.transform.GetComponent<TreeMeshGroup>() != null)
				tmgs.Add(hit.transform.GetComponent<TreeMeshGroup>());
		}

		foreach(RaycastHit hit in hits)
		{
			if(hit.transform.GetComponent<TreeMeshGroup>() != null)
			{
				TreeMeshGroup tmg = hit.transform.GetComponent<TreeMeshGroup>();
				if(!currentTrees.Contains(tmg))
				{
					currentTrees.Add(tmg);
					tmg.Fadeout();

					if(prevTrees.Contains(tmg))
						prevTrees.Remove(tmg);
				}
			}
		}

		List<TreeMeshGroup> temp = tmgs;
		foreach(TreeMeshGroup tmg in temp)
		{
			if(!tmgs.Contains(tmg))
			{
				prevTrees.Add(tmg);
				currentTrees.Remove(tmg);
			}
		}

		List<TreeMeshGroup> temp2 = prevTrees;
		foreach(TreeMeshGroup prevTree in temp2)
		{
			prevTree.Fadein();
			if(!prevTree.isFaded)
				prevTrees.Remove(prevTree);
		}
	}

	private void FadePrevious()
	{
		prevTree.Fadein();
		prevTree = null;
	}
}
