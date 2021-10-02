using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehaviour : MonoBehaviour
{
    StateMachineState loading;
    StateMachineState menu;
    StateMachineState intro;
    StateMachineState working;
    StateMachineState gameover;
    StateMachine stateMachine;

    UIBehaviour uIBehaviour;
    WorkingBehaviour workingBehaviour;

    // Start is called before the first frame update
    void Awake()
    {
        stateMachine = new StateMachine(InitStates());
    }

    StateMachineState[] InitStates()
    {
        loading = new StateMachineState("Game.Loading", LoadingBegin, LoadingComplete);
        intro = new StateMachineState("Game.Intro", MenuBegin, MenuComplete);
        menu = new StateMachineState("Game.Menu", MenuBegin, MenuComplete);
        working = new StateMachineState("Game.Working");
        gameover = new StateMachineState("Game.Over");

        StateMachineState[] stateArray = {loading, menu, intro, working, gameover};
        return stateArray;
    }

    void LoadingBegin()
    {
        // Connect to UI
    }

    void LoadingComplete()
    {
        // Create menu
        // Connect to items
    }

    void MenuBegin()
    {
        // Show menu UI

        // Add menu events

    }

    void MenuComplete()
    {
        // Hide menu UI
    }

    void WorkingBegin()
    {
        // Create new work behaviour
    }

    void WorkingComplete()
    {
        // get rid of working stuff
    }

    void GameOverBegin()
    {
        // show score
        // show gameover stuff
        // show return to menu button
    }

    void GameOverCustomer()
    {
        // hide stuff
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
