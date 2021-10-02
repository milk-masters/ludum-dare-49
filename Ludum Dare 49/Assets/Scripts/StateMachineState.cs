using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachineState
{
    public int Index {get; private set;} = -1;
    public string Name {get; private set;}
    StateMachine parentStateMachine;

    Action onBegin = null;
    Action onComplete = null;

    public StateMachineState(string name, Action onBeginAction = null, Action onCompleteAction = null)
    {
        Name = name;
        onBegin = onBeginAction;
        onComplete = onCompleteAction;
    }

    public void SetIndex(int index)
    {
        if (Index > 0)
            throw new System.Exception("Index is already set but tried to set it again.");

        Index = index;
    }

    public void OnStateBegin()
    {
        if (onBegin != null)
            onBegin.Invoke();
    }

    public void OnStateComplete()
    {
        if (onComplete != null)
            onComplete.Invoke();
    }
}
