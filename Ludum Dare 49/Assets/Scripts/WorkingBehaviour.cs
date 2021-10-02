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
    public CustomerBehaviour[] Customers;
    public UIBehaviour UIBehaviour;

    [SerializeField]
    int currentCustomerIndex = -1;

    // TOOLS
    // MirrorTool mirror;
    // ClipperTool clipper;
    // RazorTool razor;

    // Start is called before the first frame update
    void Awake()
    {
        stateMachine = new StateMachine(InitStates());
    }

    void Start()
    {
        stateMachine.ChangeState(ready);
    }

    public void Begin()
    {
        stateMachine.ChangeState(create);
    }

    StateMachineState[] InitStates()
    {
        ready = new StateMachineState("Work.Ready", ReadyBegin);
        create = new StateMachineState("Work.Create", CreateBegin);
        customer = new StateMachineState("Work.Customer", CustomerBegin);
        dispose = new StateMachineState("Work.Dispose");
        finished = new StateMachineState("Work.Finished");

        StateMachineState[] stateArray = {ready, create, customer, dispose, finished};
        return stateArray;
    }

    void ReadyBegin()
    {
        currentCustomerIndex = 0;
    }

    void CreateBegin()
    {
        Customers[currentCustomerIndex].Begin();
        stateMachine.ChangeState(customer);
    }

    void CustomerBegin()
    {
        // activate tools

        // let customer know its gonna get shaved
        Customers[currentCustomerIndex].Shave();
        CustomerPage customerPage = UIBehaviour.ShowPage(CustomerPage.StaticIndex) as CustomerPage;
        customerPage.ScoreButton.onClick.AddListener(() => Customers[currentCustomerIndex].Check());
    }
}
