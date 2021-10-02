using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    public BackgroundItem[] Backgrounds;
    
    public void ShowBackground(string backgroundName)
    {
        foreach (var background in Backgrounds)
        {
            background.gameObject.SetActive(background.Name == backgroundName);
        }
    }
}
