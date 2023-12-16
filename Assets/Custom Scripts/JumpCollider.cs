using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCollider : MonoBehaviour
{
    //private Collider2D collider;
    // Start is called before the first frame update
    void Start()
    {
        //collider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"Trigger entered by {other.gameObject.name}");
        if(other.gameObject.tag == "Player")
        {
            Player p = other.gameObject.GetComponent<Player>();
            if(!p.isLucid)
            {
                p.DreamJump();
            }
        }
    }
}
