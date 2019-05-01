using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboarding : MonoBehaviour
{
    private Transform target;
    private void Awake()
    {
        target = Camera.main.transform;
    }
    
    private void Update()
    {
        transform.LookAt(target);
    }
}
