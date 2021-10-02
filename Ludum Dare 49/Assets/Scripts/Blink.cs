using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField]
    Transform open;
    [SerializeField]
    Transform closed;
    [SerializeField]
    float freq = 3f;
    [SerializeField]
    float length = .5f;
    bool isOpen = true;
    float interval;
    [SerializeField]
    bool doSwitch = false;
    void Start()
    {
        interval = freq + Random.Range(-length, length);
    }

    void Update()
    {
        interval -= Time.deltaTime;

        if (interval < 0)
        {
            open.gameObject.SetActive(!isOpen);
            closed.gameObject.SetActive(isOpen);

            if (doSwitch)
                interval = freq + Random.Range(-length, length);
            else
                interval = Random.Range(0, length) + (isOpen? 0: freq);

            isOpen = !isOpen;
        }
    }
}

