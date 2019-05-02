using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomLeafColor : MonoBehaviour
{
	private GameObject curPrefab;
	public List<TreeMeshGroup> targetRenderers;
	public List<MaterialSet> materialSets;

	[ContextMenu("Apply New Materials")]
	public void ApplyRandomMaterials()
	{
        foreach (TreeMeshGroup ren in targetRenderers)
        {
            int i = UnityEngine.Random.Range(0, materialSets.Count);
            foreach (MeshRenderer r in ren.leaves)
            {
                foreach (Material m in r.materials)
                {
                    DestroyImmediate(m);
                }
                List<Material> mats = new List<Material>();
                mats.AddRange(materialSets[i].leafMaterials);

                r.materials = mats.ToArray();
            }
			foreach(MeshRenderer r in ren.treeBallsTransparent)
			{
				r.material = materialSets[i].transparentMaterial;
			}

			foreach(MeshRenderer r in ren.treeBallsOpaque)
			{
				r.material = materialSets[i].opaqueBallMaterial;
			}
		}
	}
}

[Serializable]
public class MaterialSet
{
	public List<Material> leafMaterials;
	public Material opaqueBallMaterial;
	public Material transparentMaterial;
}
