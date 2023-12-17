using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{

   [SerializeField] protected float damageOnCollide;

   [SerializeField] protected float speed;

   [SerializeField] protected Rigidbody2D physics;


    [SerializeField] protected float timeSpentInCurrentState;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        damageOnCollide = 10;
        speed = 15;
        physics = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update(){
        timeSpentInCurrentState += Time.deltaTime;
    }

   public float getDamageOnCollide(){
    return damageOnCollide;
   }

   protected virtual void ChangeState(string newState){

   }
}
