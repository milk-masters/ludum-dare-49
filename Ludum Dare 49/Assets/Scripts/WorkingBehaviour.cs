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
    public BeardBehaviour BeardBehaviour;

    [SerializeField]
    int currentCustomerIndex = -1;
    float newCustomerTimer = 0;

    public Grabbable GrabbedTool = null;
    public Transform ToolsParent;
    public Transform Bubble;
    public RectTransform Credits;
    bool gameIsOver = false;

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

    public void NextCustomer()
    {
        stateMachine.ChangeState(dispose);
    }

    StateMachineState[] InitStates()
    {
        ready = new StateMachineState("Work.Ready", ReadyBegin);
        create = new StateMachineState("Work.Create", CreateBegin);
        customer = new StateMachineState("Work.Customer", CustomerBegin, CustomerComplete);
        dispose = new StateMachineState("Work.Dispose", DisposeBegin);
        finished = new StateMachineState("Work.Finished", FinishedBegin);

        StateMachineState[] stateArray = {ready, create, customer, dispose, finished};
        return stateArray;
    }

    void ReadyBegin()
    {
        currentCustomerIndex = 0;
        BeardBehaviour.Wipe();
    }

    void CreateBegin()
    {
        if (currentCustomerIndex >= Customers.Length)
        {
            stateMachine.ChangeState(finished);
            return;
        }
        
        Customers[currentCustomerIndex].Begin();
        
        stateMachine.ChangeState(customer);
    }

    void CustomerBegin()
    {
        // activate tools
        ToolsParent.gameObject.SetActive(true);
        Bubble.gameObject.SetActive(true);

        // let customer know its gonna get shaved
        Customers[currentCustomerIndex].Shave();
        CustomerPage customerPage = UIBehaviour.ShowPage(CustomerPage.StaticIndex) as CustomerPage;
        customerPage.ScoreButton.onClick.AddListener(CheckCustomer);
        customerPage.targetScoreText.text = UIPage.ConvertToPercentage(Customers[currentCustomerIndex].Difficulty);
    }

    public void CheckCustomer()
    {
        Customers[currentCustomerIndex].Check();
        if (GrabbedTool != null)
        {
            GrabbedTool.Drop();
            GrabbedTool = null;
        }
    }

    void CustomerComplete()
    {
        Bubble.gameObject.SetActive(false);
    }

    public void DisposeBegin()
    {
        BeardBehaviour.Wipe();
        currentCustomerIndex++;
        SetTimer(0.2f);
    }

    public void FinishedBegin()
    {
        ToolsParent.gameObject.SetActive(false);
        Credits.gameObject.SetActive(true);
        gameIsOver = true;
    }

    void SetTimer(float val)
    {
        newCustomerTimer = val;
    }

    private void Update()
    {
        if (newCustomerTimer > 0)
        {
            newCustomerTimer -= Time.deltaTime;
            if (newCustomerTimer <= 0)
            {
                stateMachine.ChangeState(create);
            }
        }

        if (Input.GetMouseButtonDown(0) && stateMachine.CurrentState == customer && Customers[currentCustomerIndex].IsShaving())
        {
            Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit[] hits = Physics.RaycastAll(vec, Vector3.forward, 50, LayerMask.GetMask("Grabbable"));
            if (hits.Length > 0)
            {
                Grabbable grabbable = hits[0].collider.gameObject.GetComponent<Grabbable>();
                if (GrabbedTool == grabbable)
                {
                    GrabbedTool = null;
                    grabbable.Drop();
                }
                else
                    grabbable.Grab();
            }
            else if (GrabbedTool != null && !GrabbedTool.IsRotatable)
            {
                if (Physics.Raycast(vec, Vector3.forward, 50, LayerMask.GetMask("Customer")))
                {
                    CheckCustomer();
                }
            }
        }

        if (gameIsOver && Input.GetKey(KeyCode.Escape))
        {
            Debug.Log("Qutting");
            Application.Quit();
        }
    }
}
