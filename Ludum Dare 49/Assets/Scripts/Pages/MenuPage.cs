using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPage : UIPage
{
    public static int StaticIndex;
    public UnityEngine.UI.Button StartButton;
    public UnityEngine.UI.Button MuteButton;

    public override void SetIndex(int index)
    {
        Index = index;
        StaticIndex = index;
    }
}
