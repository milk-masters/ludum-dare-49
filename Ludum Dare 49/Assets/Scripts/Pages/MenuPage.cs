using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerPage : UIPage
{
    public static int StaticIndex;
    public UnityEngine.UI.Button ScoreButton;
    
    public override void SetIndex(int index)
    {
        Index = index;
        StaticIndex = index;
    }
}
