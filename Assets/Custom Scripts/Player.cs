using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Enumerated Types
    public enum PlayerState {IDLE, DREAM, LUCID, DEAD}

    // Public Variables
    [Range(0,200)]
    public float speed;
    [Range(0,200)]
    public float jump;

    // Private Variables
    private PlayerState state;
    public Transform target;
    private Rigidbody2D physics;

    // Start is called before the first frame update
    void Start()
    {
        ChangeState("dream");
        physics = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (state)
        {
            case PlayerState.IDLE:
                break;
            case PlayerState.DREAM:
                DreamWalk();
                break;
            case PlayerState.LUCID:
                LucidControl();
                break;
            case PlayerState.DEAD:
                // Change to dead model
                break;
        }
    }

    private void DreamWalk()
    {
        Debug.Log(Vector3.Distance(transform.position, target.position));
        if (Vector3.Distance(transform.position, target.position) <= .1)
        {
            ChangeState("idle");
            return;
        }

        Vector3 vel = Vector3.right * speed * Time.fixedDeltaTime;
        //Vector3 pos = Vector3.MoveTowards(transform.position, target.position, vel);
        physics.MovePosition(transform.position + vel);
    }

    private void LucidControl()
    {

    }

    public void ChangeTarget()
    {

    }

    private void ChangeState(string newState)
    {
        switch(newState)
        {
            case "idle":
                state = PlayerState.IDLE;
                break;
            case "dream":
                state = PlayerState.DREAM;
                break;
            case "lucid":
                state = PlayerState.LUCID;
                break;
            case "dead":
                state = PlayerState.DEAD;
                break;
            default:
                Debug.Log($"Invalid Player State Transition: {newState}");
                break;
        }
        Debug.Log($"Player stat is now: {state}");
    }
}
