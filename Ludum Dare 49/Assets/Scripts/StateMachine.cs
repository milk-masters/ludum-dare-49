using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public List<StateMachineState> States;

    public bool HasStateChanged {get; private set;}
    public StateMachineState CurrentState {get { return States[currentStateIndex]; }}
    int currentStateIndex;

    public StateMachine(StateMachineState[] states)
    {
        States = new List<StateMachineState>();
        States.AddRange(states);
        for (int i = 0; i < States.Count; i++)
            States[i].SetIndex(i);
    }

    public void ChangeState(StateMachineState state)
    {
        int newStateIndex = state.Index;
        int oldStateIndex = currentStateIndex;
        if (newStateIndex >= States.Count)
        {
            throw new System.Exception("Tried to change to a state that doesn't exist");
        }

        if (oldStateIndex == newStateIndex)
            return;

        currentStateIndex = newStateIndex;

        Debug.Log(string.Format("State has changed from {0} to {1}", oldStateIndex, newStateIndex));

        States[oldStateIndex].OnStateComplete();
        States[newStateIndex].OnStateBegin();
    }
}