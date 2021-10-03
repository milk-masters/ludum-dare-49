using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public float freq;
    float interval;

    private void Start()
    {
        interval = 0;
    }

    private void Update()
    {
        interval -= Time.deltaTime;

        if (interval < 0)
        {
            EZCameraShake.CameraShaker.Instance.ShakeOnce(3f, 3f, .1f, 1f);

            interval = freq;
        }
    }
}
