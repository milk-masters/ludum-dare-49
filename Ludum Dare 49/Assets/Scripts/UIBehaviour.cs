using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIBehaviour : MonoBehaviour
{
    public UIPage[] UIPages;
    // Start is called before the first frame update
    void Start()
    {
        LogAllPages();
    }
    
    public UIPage ShowPage(int pageIndex)
    {
        for (int i = 0; i < UIPages.Length; i++)
        {
            UIPages[i].gameObject.SetActive(false);
        }
        
        UIPages[pageIndex].gameObject.SetActive(true);

        return UIPages[pageIndex];
    }

    public UIPage GetPage(int pageIndex)
    {
        return UIPages[pageIndex];
    }

    public void HidePage(int pageIndex)
    {
        UIPages[pageIndex].gameObject.SetActive(false);
    }

    public void LogAllPages()
    {
        for (int i = 0; i < UIPages.Length; i++)
        {
            UIPages[i].SetIndex(i);
            Debug.Log(UIPages[i].Name);
        }
    }
}
