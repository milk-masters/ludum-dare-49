using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    UIPage[] UIPages;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LogAllPages()
    {
        foreach (var page in UIPages)
        {
            Debug.Log(page.Name);
        }
    }
}
