using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Enumerated Types
    public enum PlayerState {IDLE, DREAM, LUCID, DEAD}

    // Public Variables
    [Range(0,200)]
    public float speed;
    [Range(0,200)]
    public float jump;
    [Range(0, 10)]
    public float attackCooldown;
    [Range(0, 20)]
    public float lucidDrain;
    [Range(0, 20)]
    public float lucidFill;
    [HideInInspector]
    public bool isLucid;
    public GameObject attackPrefab;
    public Transform attackSpawn;
    public GameObject gameOverScreen;
    public Animator animations;


    // Private Variables
    private PlayerState state;
    public Transform target;
    private Rigidbody2D physics;
    private float fearMod;
    private Vector3 fly;
    private LucidBar lucidBar;
    private float timer;
    private float direction;
    private bool inNightmare = false;
    
    
    //Audio
    public AudioSource lucidSFX;
    public AudioSource screamSFX;
    public AudioSource walkSFX;
    public AudioSource dreamMusic;
    public AudioSource nightmareMusic;
    public AudioSource lucidNightSFX;

    // Start is called before the first frame update
    void Start()
    {
        gameOverScreen.SetActive(false);
        physics = GetComponent<Rigidbody2D>();
        physics.drag = 0;
        physics.velocity = Vector2.right * speed;
        fearMod = 0;
        lucidBar = GameObject.Find("LucidBar").GetComponent<LucidBar>();
        timer = attackCooldown;
        fly = Vector2.zero;
        direction = 1f;
        ChangeState("dream");

        //Audio
        AudioSource[] audioArray = GetComponents<AudioSource>();
        lucidSFX = audioArray[0];
        screamSFX = audioArray[1];
        walkSFX = audioArray[2];
        dreamMusic = audioArray[3];
        nightmareMusic = audioArray[4];
        lucidNightSFX = audioArray[5];
        lucidSFX.Stop();
        lucidNightSFX.mute = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
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
        CheckVictory();

        //Vector3 vel = Vector3.right * speed * Time.fixedDeltaTime;
        //Vector3 pos = Vector3.MoveTowards(transform.position, target.position, vel);

        MaintainSpeed();
    }

    private void LucidControl()
    {
        CheckVictory();

        if(Input.GetButtonDown("ToggleLucid"))
        {
            ChangeState("dream");
            MaintainSpeed();
        }

        if(Input.GetButton("Attack") && timer >= attackCooldown)
        {
            Instantiate(attackPrefab, attackSpawn.position, Quaternion.identity);
            timer = 0;
        }

        // if(Input.GetButtonDown("Jump"))
        // {
        //     LucidJump();
        // }

        fly = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")) * (speed - fearMod) * Time.fixedDeltaTime;
        physics.MovePosition(transform.position + fly);

        if(lucidBar.getCurrentBarValue() <= 0)
        {
            ChangeState("dead");
        }
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
        physics.velocity = new Vector2(speed * direction, physics.velocity.y);
    }

    public void Stop()
    {
        physics.gravityScale = 0;
        physics.velocity = Vector2.zero;
    }

    public void IsDead()
    {
        ChangeState("dead");
    }

    public void IncreaseFear(float fear)
    {

    }

    public void ChangeTarget()
    {

    }

    public void CheckVictory()
    {
        if (Vector3.Distance(transform.position, target.position) <= 1)
        {
            ChangeState("idle");
            physics.velocity = Vector2.zero;
            return;
        }
    }

    public void ChangeDirection()
    {
        direction = -1f;
        GetComponentInChildren<SpriteRenderer>().flipX = true;

        //Dream music: stop
        dreamMusic.Stop();
        //Nightmare music: play
        nightmareMusic.Play();
        
        lucidSFX.mute = true;
        inNightmare = true;

    }

    private void ChangeState(string newState)
    {
        switch(newState)
        {
            case "idle":
                state = PlayerState.IDLE;
                SceneManager.LoadScene("VictoryScreen");
                break;
            case "dream":
                state = PlayerState.DREAM;
                isLucid = false;
                physics.gravityScale = 3;
                animations.Play("Player_Walk_Test");
                lucidBar.setChangeRate(lucidFill);

                //Lucid: stop audio
                lucidSFX.Stop();
                lucidNightSFX.Stop();
                //Walk: play audio
                walkSFX.Play();
                
                break;
            case "lucid":
                state = PlayerState.LUCID;
                isLucid = true;
                physics.gravityScale = 0;
                lucidBar.setChangeRate(-lucidDrain);
                animations.Play("Player_Idle_Test");

                //Lucid: play audio
                lucidSFX.Play();

                //Walk: stop audio
                walkSFX.Stop();

                if (inNightmare){
                    lucidNightSFX.mute = false;
                    lucidNightSFX.Play();
                }
                

                break;
            case "dead":
                state = PlayerState.DEAD;
                isLucid = false;
                Stop();
                animations.Play("Player_Death_Test");
                //gameOverScreen.SetActive(true);

                

                //Nightmare music: stop
                dreamMusic.Stop();
                nightmareMusic.Stop();

                //Walk: stop audio
                walkSFX.Stop();

                //Scream: play audio
                //screamSFX.Play();
                StartCoroutine(DeathScream());

                break;
            default:
                Debug.Log($"Invalid Player State Transition: {newState}");
                break;
        }
        Debug.Log($"Player state is now: {state}");
    }

    IEnumerator DeathScream()
    {
        screamSFX.Play();
        while(screamSFX.isPlaying)
        {
            yield return new WaitForSeconds(.1f);
        }

        SceneManager.LoadScene("AwakeScene");
    }
}
