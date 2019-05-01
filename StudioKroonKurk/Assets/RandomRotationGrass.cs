using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotationGrass : MonoBehaviour
{
    public List<GrassCluster> grass = new List<GrassCluster>();

    [ContextMenu("Fill grass list")]
    private void GetChildren()
    {
        grass = new List<GrassCluster>();
        foreach (GrassCluster t in GetComponentsInChildren<GrassCluster>())
        {
            grass.Add(t);
        }
    }

    [ContextMenu("Randomise")]
    private void Randomise()
    {
        ResetGrass();
        GetChildren();
        foreach (GrassCluster gc in grass)
        {
            foreach (Transform t in gc.grass)
            {
                float num = Random.Range(0.8f, 1.2f);
                t.localScale = new Vector3(num, num, num);
            }
        }
          
    }

    [ContextMenu("reset")]
    private void ResetGrass()
    {
        foreach (GrassCluster gc in grass)
        {
            foreach (Transform t in gc.grass)
            {
                t.localScale = Vector3.one;
            }
        }
    }
}
