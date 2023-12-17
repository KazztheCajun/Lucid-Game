using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dentist : Enemy
{

    private enum DentistState {IDLE, LAUGHING, SUMMONING}

    [SerializeField] private DentistState currentState;

    [SerializeField] private GameObject drillPrefab;

    [SerializeField] private float timeSpentInCurrentState;
    [SerializeField] private float timeToSpendInIdle;
    [SerializeField] private float timeToSpendInSummoning;
    [SerializeField] private float timeToSpendInLaughing;

    // Start is called before the first frame update
    protected override void Start()
    {
        ChangeState("idle");
    }

    // Update is called once per frame
    void Update()
    {
        switch(currentState){
            case DentistState.IDLE:
            break;
            case DentistState.LAUGHING:
            break;
            case DentistState.SUMMONING:
            break;
        }

        if(Input.GetKeyDown(KeyCode.R)){
            ChangeToRandomDifferentState();
        }
    }

    private void ChangeToRandomDifferentState(){
        string[] dentistStates = System.Enum.GetNames(typeof(DentistState));
        int numberOfDentistStates = dentistStates.Length;

        int randomStateIndex = Random.Range(0, numberOfDentistStates);
        string newState = dentistStates[randomStateIndex];

        //If it is the same state, try again.
        while(newState == currentState.ToString()){
            randomStateIndex = Random.Range(0, numberOfDentistStates);
            newState = dentistStates[randomStateIndex];
        }
        ChangeState(newState.ToLower());
        //Debug.Log("current state is " + currentState + " new state is " + newState);
        
    }

    protected override void ChangeState(string newState)
    {
        switch(newState)
        {
            case "idle":
                currentState = DentistState.IDLE;
                break;
            case "laughing":
                currentState = DentistState.LAUGHING;
                break;
            case "summoning":
                currentState = DentistState.SUMMONING;
                break;
            default:
                Debug.Log($"Invalid Dentist State Transition: {newState}");
                break;
        }
        Debug.Log($"Dentist state is now: {currentState}");
    }

    //Overloaded version that switches based on a DentistState
    private void ChangeState(DentistState newState)
    {
        switch(newState)
        {
            case DentistState.IDLE: ChangeState("idle"); break;
            case DentistState.LAUGHING: ChangeState("laughing"); break;
            case DentistState.SUMMONING: ChangeState("summoning"); break;
            default: ChangeState("???"); break;
        }
        Debug.Log($"Dentist state is now: {currentState}");
    }
}
