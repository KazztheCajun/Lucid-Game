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
    [HideInInspector]
    public bool isLucid;


    // Private Variables
    private PlayerState state;
    public Transform target;
    private Rigidbody2D physics;
    private float fearMod;
    private Vector3 fly;

    // Start is called before the first frame update
    void Start()
    {
        ChangeState("dream");
        physics = GetComponent<Rigidbody2D>();
        physics.drag = 0;
        physics.velocity = Vector2.right * speed;
        fearMod = 0;

    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case PlayerState.DREAM:
                DreamCheck();
                break;
            case PlayerState.IDLE:
                break;
            case PlayerState.LUCID:
                LucidControl();
                break;
            case PlayerState.DEAD:
                // Change to dead model
                break;
        }
    }

    void FixedUpdate()
    {
        switch (state)
        {
            case PlayerState.DREAM:
                DreamWalk();
                break;
            case PlayerState.IDLE:
            case PlayerState.LUCID:
            case PlayerState.DEAD:
                // Change to dead model
                break;
        }
    }

    private void DreamCheck()
    {
        if(Input.GetButtonDown("ToggleLucid"))
        {
            ChangeState("lucid");
            physics.velocity = Vector2.zero;
        }
    }

    private void DreamWalk()
    {
        //Debug.Log(Vector3.Distance(transform.position, target.position));
        //Debug.Log(physics.velocity);
        if (Vector3.Distance(transform.position, target.position) <= .2)
        {
            ChangeState("idle");
            physics.velocity = Vector2.zero;
            return;
        }

        //Vector3 vel = Vector3.right * speed * Time.fixedDeltaTime;
        //Vector3 pos = Vector3.MoveTowards(transform.position, target.position, vel);

        MaintainSpeed();
    }

    private void LucidControl()
    {
        if(Input.GetButtonDown("ToggleLucid"))
        {
            ChangeState("dream");
            MaintainSpeed();
        }

        // if(Input.GetButtonDown("Jump"))
        // {
        //     LucidJump();
        // }

        fly = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * (speed - fearMod) * Time.fixedDeltaTime;
        physics.MovePosition(transform.position + fly);
    }

    public void LucidJump()
    {
        physics.AddForce(transform.up * (jump * fearMod));
    }

    public void DreamJump()
    {
        physics.AddForce(transform.up * jump, ForceMode2D.Impulse);
    }

    public void WalkRight()
    {
        physics.velocity = Vector2.right * speed;
    }

    public void MaintainSpeed()
    {
        physics.velocity = new Vector2(speed, physics.velocity.y);
    }

    public void IncreaseFear(float fear)
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
                isLucid = false;
                break;
            case "lucid":
                state = PlayerState.LUCID;
                isLucid = true;
                break;
            case "dead":
                state = PlayerState.DEAD;
                break;
            default:
                Debug.Log($"Invalid Player State Transition: {newState}");
                break;
        }
        Debug.Log($"Player state is now: {state}");
    }
}
