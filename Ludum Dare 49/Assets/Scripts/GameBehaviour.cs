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

    public UIBehaviour UIBehaviour;
    public WorkingBehaviour WorkingBehaviour;

    // Start is called before the first frame update
    void Awake()
    {
        stateMachine = new StateMachine(InitStates());
    }

    void Start()
    {
        stateMachine.ChangeState(loading);
    }

    StateMachineState[] InitStates()
    {
        loading = new StateMachineState("Game.Loading", LoadingBegin, LoadingComplete);
        intro = new StateMachineState("Game.Intro");
        menu = new StateMachineState("Game.Menu", MenuBegin, MenuComplete);
        working = new StateMachineState("Game.Working", WorkingBegin);
        gameover = new StateMachineState("Game.Over");

        StateMachineState[] stateArray = {loading, menu, intro, working, gameover};
        return stateArray;
    }

    void LoadingBegin()
    {
        // Connect to UI
        stateMachine.ChangeState(menu);
    }

    void LoadingComplete()
    {
        // Create menu
        // Connect to items
    }

    void MenuBegin()
    {
        // Show menu UI
        MenuPage menuPage = UIBehaviour.ShowPage(MenuPage.StaticIndex) as MenuPage;

        menuPage.StartButton.onClick.AddListener(() => stateMachine.ChangeState(working));
    }

    void MenuComplete()
    {
        // Hide menu UI
        UIBehaviour.HidePage(MenuPage.StaticIndex);
    }

    void WorkingBegin()
    {
        // Create new work behaviour
        WorkingBehaviour.Begin();
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
