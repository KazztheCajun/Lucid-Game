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

    [SerializeField] private SpriteRenderer body;

    [SerializeField] private AudioSource laughSoundEffect;

    // Start is called before the first frame update
    protected override void Start()
    {
        ChangeState("idle");
    }

    // Update is called once per frame
    void Update()
    {
        timeSpentInCurrentState += Time.deltaTime;
        switch(currentState){
            case DentistState.IDLE:
                if(timeSpentInCurrentState > timeToSpendInIdle){
                    ChangeToRandomDifferentState();
                }
                break;
            case DentistState.LAUGHING:
                if(timeSpentInCurrentState > timeToSpendInLaughing){
                    ChangeToRandomDifferentState();
                }
            break;
            case DentistState.SUMMONING:
                if(timeSpentInCurrentState > timeToSpendInSummoning){
                    ChangeToRandomDifferentState();
                }
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
                body.color = Color.blue;
                break;
            case "laughing":
                currentState = DentistState.LAUGHING;
                laughSoundEffect.Play();
                body.color = Color.green;
                break;
            case "summoning":
                currentState = DentistState.SUMMONING;
                body.color = Color.gray;
                break;
            default:
                Debug.Log($"Invalid Dentist State Transition: {newState}");
                break;
        }
        Debug.Log($"Dentist state is now: {currentState}");
        timeSpentInCurrentState = 0f;
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
