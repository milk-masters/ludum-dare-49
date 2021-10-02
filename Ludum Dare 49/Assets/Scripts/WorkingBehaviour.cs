using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkingBehaviour : MonoBehaviour
{
    StateMachineState ready;
    StateMachineState create;
    StateMachineState customer;
    StateMachineState dispose;
    StateMachineState finished;
    StateMachine stateMachine;
    // Start is called before the first frame update
    void Awake()
    {
        stateMachine = new StateMachine(InitStates());
    }

    StateMachineState[] InitStates()
    {
        ready = new StateMachineState("Work.Ready");
        create = new StateMachineState("Work.Create");
        customer = new StateMachineState("Work.Customer");
        dispose = new StateMachineState("Work.Dispose");
        finished = new StateMachineState("Work.Finished");

        StateMachineState[] stateArray = {ready, create, customer, dispose, finished};
        return stateArray;
    }
}
