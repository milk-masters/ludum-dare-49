using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerBehaviour : MonoBehaviour
{

    public enum customerStates { preStart, start, shaving, checking, scoring, finished, error}
    customerStates state;
    bool stateHasChanged = false;
    // Start is called before the first frame update
    void Start()
    {
        state = customerStates.preStart;
    }

    public void ChangeState(customerStates newState)
    {
        Debug.Log("Changing state to " + newState);

        if (state != newState)
            stateHasChanged = true;

        state = newState;
    }

    // Update is called once per frame
    void Update()
    {
        //if (stateHasChanged)

    }
}
