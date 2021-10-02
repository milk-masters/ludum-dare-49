using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{

    StateMachineState loading;
    StateMachineState menu;
    StateMachineState intro;
    StateMachineState customer;
    StateMachineState gameover;
    StateMachineState complete;
    StateMachine stateMachine;
    // Start is called before the first frame update
    void Start()
    {
        stateMachine = new StateMachine(InitStates());
    }

    StateMachineState[] InitStates()
    {
        loading = new StateMachineState();
        menu = new StateMachineState();
        intro = new StateMachineState();
        customer = new StateMachineState();
        gameover = new StateMachineState();
        complete = new StateMachineState();
        
        StateMachineState[] stateArray = {loading, menu, intro, customer, gameover, complete};
        return stateArray;
    }

    // Update is called once per frame
    void Update()
    {
        //if (stateHasChanged)

    }
}
