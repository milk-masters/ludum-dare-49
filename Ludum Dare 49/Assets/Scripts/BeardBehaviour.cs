using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeardBehaviour : MonoBehaviour
{
    public Transform TargetCameraTransform;
    public Transform ActiveCameraTransform;
    GameObject defaultBeard;
    GameObject targetBeard;
    void Start()
    {
        
    }

    public void SetDefaultBeard(Transform beardTransform)
    {
        defaultBeard = beardTransform.gameObject;
    }

    public void SetTargetBeard(Transform beardTransform)
    {
        targetBeard = beardTransform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (targetBeard != null)
        {
            if (targetBeard.activeSelf)
            {
                targetBeard.SetActive(false);
                targetBeard = null;
            }
            else
                targetBeard.SetActive(true);
        }

        if (defaultBeard != null)
        {
            if (defaultBeard.activeSelf)
            {
                defaultBeard.SetActive(false);
                defaultBeard = null;
            }
            else
                defaultBeard.SetActive(true);
        }
    }
}
