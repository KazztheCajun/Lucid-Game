using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hurtable : MonoBehaviour
{

    [SerializeField] private FearBar fearBar;

    public void OnTriggerEnter2D(Collider2D other){
        Debug.Log("OUCH! I just got hit by " + other.name);
        DamageDealer theThingThatHurtMe = other.GetComponent<DamageDealer>();
       
        //Update the fear bar (assuming it isn't null)
        fearBar?.adjustCurrentBarValue(theThingThatHurtMe.getDamageOnCollide() * -1);
        
    }
}
