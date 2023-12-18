using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drill : Trap
{

    private enum DrillState {PREPARING, MOVING}

    private DrillState currentState;

    [SerializeField] private SpriteRenderer body;

    [SerializeField] private float timeToSpendInPreparingState;
    [SerializeField] private float timeToSpendInMovingState;

    [SerializeField] private AudioSource preparingSound;
    [SerializeField] private AudioSource movingSound;

    [SerializeField] private Animator animator;

    [SerializeField] private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();

        //Figure out if this is an up drill or a down drill.
        speed = 5;
        if(Random.Range(0,2) == 0){
            speed *= -1;
        }
        else{
            //We need to flip the drill.
            spriteRenderer.flipY = !spriteRenderer.flipY;
        }


        ChangeState(DrillState.PREPARING);
    }

    // Update is called once per frame
   protected override void Update(){
        base.Update();

        switch(currentState){
            case DrillState.PREPARING:
                if(timeSpentInCurrentState > timeToSpendInPreparingState){
                    ChangeState(DrillState.MOVING);
                }
            break;
            case DrillState.MOVING:

                if(timeSpentInCurrentState > timeToSpendInMovingState){
                    //remove the game object
                    Destroy(this.gameObject);
                }
            break;
        }
   }

    protected override void ChangeState(string newState)
    {
        switch(newState)
        {
            case "preparing":
                currentState = DrillState.PREPARING;
                body.color = Color.blue;
                preparingSound.time = 2;
                preparingSound.Play();
                animator.Play("Drill_Prep");
                break;
            case "moving":
                currentState = DrillState.MOVING;
                body.color = Color.green;
                physics.velocity = Vector2.up * speed;
                preparingSound.Stop();
                movingSound.Play();
                animator.Play("Drill_Move");
                break;
            default:
                Debug.Log($"Invalid Drill State Transition: {newState}");
                break;
        }
        Debug.Log($"Drill state is now: {currentState}");
        timeSpentInCurrentState = 0f;
    }

    //Overloaded version that switches based on a DentistState
    private void ChangeState(DrillState newState)
    {
        switch(newState)
        {
            case DrillState.PREPARING: ChangeState("preparing"); break;
            case DrillState.MOVING: ChangeState("moving"); break;
            default: ChangeState("???"); break;
        }
        Debug.Log($"Drill state is now: {currentState}");
    }
}
