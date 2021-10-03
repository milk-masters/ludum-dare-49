using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoringPage : UIPage
{
    public TMPro.TMP_Text ContinueButtonText;
    public UnityEngine.UI.Button ContinueButton;
    public TMPro.TMP_Text AccuracyValueText;
    public TMPro.TMP_Text TargetValueText;
    public RectTransform CompleteRect;
    public RectTransform FailedRect;
    public static int StaticIndex;

    public override void SetIndex(int index)
    {
        Index = index;
        StaticIndex = index;
    }
    
    public void Show(float target, float accuracy, CustomerBehaviour customer)
    {
        AccuracyValueText.text = ConvertToPercentage(accuracy);
        TargetValueText.text = ConvertToPercentage(target);

        float fairTarget = target-0.05f;
        CompleteRect.gameObject.SetActive(accuracy >= fairTarget);
        FailedRect.gameObject.SetActive(accuracy <= fairTarget);

        //if ()
        ContinueButton.onClick.AddListener(customer.Finish);
    }

    public void Hide()
    {
        ContinueButton.onClick.RemoveAllListeners();
    }
}
