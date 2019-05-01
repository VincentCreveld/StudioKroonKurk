using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// This script fades out the obstructing objects between the player and the camera.
public class ObjectClipping : MonoBehaviour
{
	public LayerMask mask;
	public Transform playerObj, camObj;

	private List<TreeMeshGroup> currentTrees = new List<TreeMeshGroup>();
	private List<TreeMeshGroup> prevTrees = new List<TreeMeshGroup>();
	private List<TreeMeshGroup> tmgs = new List<TreeMeshGroup>();
	private List<RaycastHit> hits = new List<RaycastHit>();

	private void Update()
	{
		Ray r = new Ray(camObj.position, playerObj.position - camObj.position);
		float dist = Vector3.Distance(playerObj.position, camObj.position);
		hits.Clear();
		hits = Physics.RaycastAll(r, dist + 0.5f, mask).ToList();
		tmgs.Clear();

		// Get all TreeMeshGroups from ray hits
		foreach(RaycastHit hit in hits)
		{
			if(hit.transform.GetComponent<TreeMeshGroup>() != null)
				tmgs.Add(hit.transform.GetComponent<TreeMeshGroup>());
		}

		// If a tree is in currentTrees and not in the RayHit list, remove and move to prevTrees.
		List<TreeMeshGroup> temp = currentTrees.ToList();
		foreach(TreeMeshGroup tmg in temp)
		{
			if(!tmgs.Contains(tmg))
			{
				if(tmg.startedFade)
					tmg.StopFading();
				prevTrees.Add(tmg);
				currentTrees.Remove(tmg);
			}
		}

		// Checks if tmg is in prevTrees list and remove if it should be in 
		foreach(TreeMeshGroup tmg in tmgs)
		{
			if(!currentTrees.Contains(tmg))
			{
				if(prevTrees.Contains(tmg))
					prevTrees.Remove(tmg);

				currentTrees.Add(tmg);
				tmg.Fadeout();
			}
		}

		// Call fade in on all prevTrees and remove as soon as it's faded.
		List<TreeMeshGroup> temp2 = prevTrees.ToList();
		foreach(TreeMeshGroup prevTree in temp2)
		{
			prevTree.Fadein();
			if(!prevTree.isFaded && !prevTree.startedFade)
				prevTrees.Remove(prevTree);
		}
	}
}
