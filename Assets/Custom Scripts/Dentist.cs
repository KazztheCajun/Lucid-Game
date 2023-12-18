using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dentist : Enemy
{

    private enum DentistState {IDLE, LAUGHING, SUMMONING}

    [SerializeField] private DentistState currentState;

    [SerializeField] private GameObject drillPrefab;

    [SerializeField] private Animator animator;

    [SerializeField] private float timeToSpendInIdle;
    [SerializeField] private float timeToSpendInSummoning;
    [SerializeField] private float timeToSpendInLaughing;

    [SerializeField] private int numDrillsToSummon;
    [SerializeField] private int minDrillsToSummon;
    [SerializeField] private int maxDrillsToSummon;
    [SerializeField] private float drillSummonCooldown;
    [SerializeField] private float timeRemainingUntilNextDrill;

    [SerializeField] private float currentDistanceFromDentist;
    [SerializeField] private float distanceBetweenEachDrill;



    [SerializeField] private SpriteRenderer body;

    [SerializeField] private AudioSource laughSoundEffect;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        ChangeState("idle");
        minDrillsToSummon = 7;
        maxDrillsToSummon = 14;
        drillSummonCooldown = 0.2f;
        distanceBetweenEachDrill = 2.5f;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
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

                //update the cooldown for summoning another drill.
                timeRemainingUntilNextDrill -= Time.deltaTime;
                if(timeRemainingUntilNextDrill <= 0 && numDrillsToSummon >= 0){
                    //summon a drill!
                    currentDistanceFromDentist += distanceBetweenEachDrill;
                    Instantiate(drillPrefab, 
                        new Vector3(this.transform.position.x + currentDistanceFromDentist, 
                        this.transform.position.y, 
                        this.transform.position.z), 
                        Quaternion.identity);
                    timeRemainingUntilNextDrill = drillSummonCooldown;
                    numDrillsToSummon -= 1;
                }
            break;
        }

        if(Input.GetKeyDown(KeyCode.R)){
            ChangeToRandomDifferentState();
        }
        if(Input.GetKeyDown(KeyCode.S)){
            ChangeState("summoning");
        }
    }

    private void ChangeToRandomDifferentState(){

        /*
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
        */

        //New functionality! Just switch between laughing and drills.
        if(currentState == DentistState.LAUGHING){
            ChangeState(DentistState.SUMMONING);
        }
        else{
            ChangeState(DentistState.LAUGHING);
        }
        
    }

    protected override void ChangeState(string newState)
    {
        switch(newState)
        {
            case "idle":
                currentState = DentistState.IDLE;
                body.color = Color.blue;
                animator.Play("Dentist2Idle");
                break;
            case "laughing":
                currentState = DentistState.LAUGHING;
                laughSoundEffect.Play();
                body.color = Color.green;
                animator.Play("Dentist2Laugh");
                break;
            case "summoning":
                currentState = DentistState.SUMMONING;
                body.color = Color.gray;
                numDrillsToSummon = Random.Range(minDrillsToSummon, maxDrillsToSummon);
                Debug.Log("Summoning " + numDrillsToSummon + " drills");
                timeRemainingUntilNextDrill = drillSummonCooldown;
                currentDistanceFromDentist = 3f;
                animator.Play("Dentist2Summon");
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
