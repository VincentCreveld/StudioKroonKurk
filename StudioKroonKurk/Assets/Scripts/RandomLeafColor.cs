using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomLeafColor : MonoBehaviour
{
	private GameObject curPrefab;
	public List<TreeMeshGroup> targetRenderers;
	public List<MaterialSet> materialSets;

	[ContextMenu("Apply New Materials")]
	public void PlaceRandomPrefab()
	{
        foreach (TreeMeshGroup ren in targetRenderers)
        {
            int i = UnityEngine.Random.Range(0, materialSets.Count);
            foreach (MeshRenderer r in ren.renderers)
            {
                foreach (Material m in r.materials)
                {
                    DestroyImmediate(m);
                }
                List<Material> mats = new List<Material>();
                mats.AddRange(materialSets[i].materials);

                r.materials = mats.ToArray();
            }
			foreach(MeshRenderer r in ren.transparentRenderers)
			{
				r.material = materialSets[i].transparentMaterial;
			}
        }
	}
}

[Serializable]
public class MaterialSet
{
	public List<Material> materials;
	public Material transparentMaterial;
}
