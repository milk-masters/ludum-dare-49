using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPage : UIPage
{
    public static int StaticIndex;
    public UnityEngine.UI.Button StartButton;
    public UnityEngine.UI.Button QuitButton;

    private void Awake() {
        StaticIndex = Index;
    }
}
