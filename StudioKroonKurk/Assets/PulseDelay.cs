using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulseDelay : MonoBehaviour
{
    public float pulseSpeed, downtime;

    private float loopTime;

    public Material pulseMaterial;

    public float breatheValue = 2.567f;

    private float t = 0;
    private float val = 0;

    private void Start()
    {
        // no linked shader
        if (pulseMaterial == null)
            Destroy(this);
    }

    private void Update()
    {
        loopTime = pulseSpeed + downtime;
        if (t >= loopTime)
            t = 0;

        t += Time.deltaTime;

        float temp = Mathf.Lerp(0, Mathf.PI, t / loopTime * breatheValue);

        val = Mathf.Sin(temp);//(t >= downtime) ? 1 : 0;

        pulseMaterial.SetFloat("_pulseSpeed", val);
    }
}
