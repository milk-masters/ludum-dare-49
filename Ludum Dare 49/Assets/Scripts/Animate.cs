using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    public Transform[] Frames;
    public float freq;
    public float interval;
    int frameCounter = 0;

    private void Start()
    {
        foreach(var frame in Frames)
        {
            frame.gameObject.SetActive(false);
        }
        Frames[0].gameObject.SetActive(true);

        interval = freq;
    }

    private void Update() {
        
        interval -= Time.deltaTime;

        if (interval < 0)
        {
            Frames[frameCounter].gameObject.SetActive(false);
            frameCounter = (frameCounter + 1) % Frames.Length;
            Frames[frameCounter].gameObject.SetActive(true);

            interval = freq;
        }
    }
}
