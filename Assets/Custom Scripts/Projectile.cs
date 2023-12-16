using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Range(0, 200)]
    public float speed;

    private Rigidbody2D physics;
    // Start is called before the first frame update
    void Start()
    {
        physics = GetComponent<Rigidbody2D>();
        physics.velocity = Vector2.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Floor")
        {
            physics.AddForce(transform.up * 5, ForceMode2D.Impulse);
        }

        if(other.gameObject.tag == "Destructable")
        {
            other.gameObject.GetComponent<Destructable>().DestroyObject();
        }
    }
}
