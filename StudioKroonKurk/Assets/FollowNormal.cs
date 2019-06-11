using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowNormal : MonoBehaviour
{
    private void Update()
    {
        //Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 1f))
        {
            transform.up = hit.normal;
        }
        else
            transform.up = Vector3.up;
    }
}
