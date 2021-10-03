using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPage : MonoBehaviour
{
    public string Name;
    public int Index;


    public virtual void SetIndex(int index) {}

    public static string ConvertToPercentage(float val)
    {
        return Mathf.Round(val * 100f) + "%";
    }
}
