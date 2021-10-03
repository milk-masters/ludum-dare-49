using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerBehaviour : MonoBehaviour
{
    StateMachineState start;
    StateMachineState shaving;
    StateMachineState checking;
    StateMachineState scoring;
    StateMachineState finished;
    StateMachine stateMachine;

    public string Name;
    public Transform[] TargetBeards;
    int beardIndex = -1;
    public Transform Face;
    public Transform StartingBeard;
    public Transform Bubble;
    public float Difficulty;
    public float Score {get; private set;}
    public BeardBehaviour BeardBehaviour;
    Texture2D activeBeardTexture;
    Texture2D targetBeardTexture;
    public WorkingBehaviour WorkingBehaviour;

    void Awake()
    {
        stateMachine = new StateMachine(InitStates());
        activeBeardTexture = new Texture2D(512, 512);
        targetBeardTexture = new Texture2D(512, 512);
    }

    public void Begin()
    {
        stateMachine.ChangeState(start);
    }

    public void Shave()
    {
        stateMachine.ChangeState(shaving);
    }

    public void Check()
    {
        stateMachine.ChangeState(checking);
    }

    StateMachineState[] InitStates()
    {
        start = new StateMachineState("Customer.Start", StartBegin);
        shaving = new StateMachineState("Customer.Shaving", null, ShavingComplete);
        checking = new StateMachineState("Customer.Checking", StartChecking);
        scoring = new StateMachineState("Customer.Scoring", StartScoring, CompleteScoring);
        finished = new StateMachineState("Customer.Finished", StartFinished);

        StateMachineState[] stateArray = {start, shaving, checking, scoring, finished};
        return stateArray;
    }

    void StartBegin()
    {
        Debug.Log("Activating " + Name);

        if (TargetBeards.Length == 0)
        {
            Debug.Log("No available beards");
            return;
        }
        
        // select a random texture
        beardIndex = Random.Range(0, TargetBeards.Length);

        // apply a beard to the render texture
        BeardBehaviour.SetTargetBeard(StartingBeard);
        BeardBehaviour.SetDefaultBeard(TargetBeards[beardIndex]);

        // enable face
        Face.gameObject.SetActive(true);
        Bubble.gameObject.SetActive(true);
    }

    void ShavingComplete()
    {
        
    }
    

    void StartChecking()
    {
        var oldTex = RenderTexture.active;

        var tex = BeardBehaviour.TargetCameraTransform.gameObject.GetComponent<Camera>().targetTexture;
        RenderTexture.active = tex;
        targetBeardTexture.ReadPixels(new Rect(0,0,tex.width, tex.height),0,0);
        targetBeardTexture.Apply();
        
        tex = BeardBehaviour.ActiveCameraTransform.gameObject.GetComponent<Camera>().targetTexture;
        RenderTexture.active = tex;
        activeBeardTexture.ReadPixels(new Rect(0,0,tex.width, tex.height),0,0);
        activeBeardTexture.Apply();

        RenderTexture.active = oldTex;

        // do check math
        Score = CalculateScore(targetBeardTexture, activeBeardTexture);
        Debug.Log(Score);
        // score
        stateMachine.ChangeState(scoring);
    }

    void StartScoring()
    {
        ScoringPage scoringPage = WorkingBehaviour.UIBehaviour.ShowPage(ScoringPage.StaticIndex) as ScoringPage;
        scoringPage.Show(Difficulty, Score, this);
    }

    void CompleteScoring()
    {
        (WorkingBehaviour.UIBehaviour.GetPage(ScoringPage.StaticIndex) as ScoringPage).Hide();
        WorkingBehaviour.UIBehaviour.HidePage(ScoringPage.StaticIndex);
    }

    public void Finish()
    {
        stateMachine.ChangeState(finished);
    }

    public float CalculateScore(Texture2D target, Texture2D actual)
    {
        var targetData = target.GetPixels32();
        Debug.Log(targetData.Length);
        var actualData = actual.GetPixels32();
        Debug.Log(actualData.Length);

        int pixelCount = actualData.Length;
        int matchCount = 0;
        int potentialCount = 0;

        // Debug.Log(targetData[0].b);
        // Debug.Log(actualData[0].b);

        for (int i = 0; i < targetData.Length; i++)
        {
            if (targetData[i].r > 0)
            {
                potentialCount++;
                if(actualData[i].r > 0)
                    matchCount++;
            }
            else
                if(actualData[i].r > 0)
                    matchCount--;
        }

        Debug.Log("Potential: " + potentialCount);
        Debug.Log("Actual: " + matchCount);

        if (potentialCount < 1 || matchCount < 1)
            return 0f;

        float score = (float)matchCount/potentialCount;

        score = Mathf.Min(score + 0.1f, 1f);

        return score;
    }

    void StartFinished()
    {
        WorkingBehaviour.NextCustomer();
        Face.gameObject.SetActive(false);
        Bubble.gameObject.SetActive(false);
    }
}
