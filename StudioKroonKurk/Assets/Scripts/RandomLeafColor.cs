using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomLeafColor : MonoBehaviour
{
	private GameObject curPrefab;
	public List<MeshRenderer> targetRenderers;
	public List<MaterialSet> materialSets;

	[ContextMenu("Apply New Materials")]
	public void PlaceRandomPrefab()
	{
		foreach(MeshRenderer r in targetRenderers)
		{
			foreach(Material m in r.materials)
			{
				DestroyImmediate(m);
			}
			int i = UnityEngine.Random.Range(0, materialSets.Count);

			List<Material> mats = new List<Material>();
			mats.AddRange(materialSets[i].materials);

			r.materials = mats.ToArray();
		}
	}
}

[Serializable]
public class MaterialSet
{
	public List<Material> materials;
}
