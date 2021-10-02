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
    // Start is called before the first frame update
    void Awake()
    {
        stateMachine = new StateMachine(InitStates());
    }

    StateMachineState[] InitStates()
    {
        start = new StateMachineState("Customer.Start");
        shaving = new StateMachineState("Customer.Shaving");
        checking = new StateMachineState("Customer.Checking");
        scoring = new StateMachineState("Customer.Scoring");
        finished = new StateMachineState("Customer.Finished");

        StateMachineState[] stateArray = {start, shaving, checking, scoring, finished};
        return stateArray;
    }
}
