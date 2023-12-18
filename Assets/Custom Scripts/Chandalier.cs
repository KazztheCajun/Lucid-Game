using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chandalier : Trap
{
    // Start is called before the first frame update

    Ray rayDirection;
    RaycastHit2D rayInfo;

    [SerializeField] bool playerDetected;
    protected override void Start()
    {
        base.Start();
        rayDirection = new Ray(this.transform.position, Vector3.down);
        rayInfo = new RaycastHit2D();
        playerDetected = false;
        speed = 20;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        //If we haven't seen the player yet... check out for the player!
        Debug.DrawRay(this.transform.position, Vector3.down*100, Color.green);
        if(!playerDetected){
            rayInfo = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity);
            if(rayInfo){
           
                if(rayInfo.collider != null){
                    //Debug.Log("RAY INFO HAS INFO!");
                    if(rayInfo.collider.tag == "Player"){
                        //Debug.DrawRay(this.transform.position, Vector3.down*100, Color.red);
                        Debug.Log("PLAYER DETECTED!!!!!!!!");
                        playerDetected = true;
                    }
                }
            }
            else{
                //Debug.DrawRay(this.transform.position, Vector3.down*100, Color.green);
            }
        }

        if(playerDetected){
            Vector3 vel = Vector3.down * speed * Time.fixedDeltaTime;
            //Vector3 pos = Vector3.MoveTowards(transform.position, target.position, vel);
            physics.MovePosition(transform.position + vel);
        }

    }


}
