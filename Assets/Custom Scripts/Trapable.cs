using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trapable : MonoBehaviour
{

    [SerializeField] private FearBar fearBar;

    public void OnTriggerEnter2D(Collider2D other){
        Debug.Log("OUCH! I just got hit by " + other.name);
        Trap theThingThatHitMe = other.GetComponent<Trap>();
        
        //Update the fear bar (assuming it isn't null)
        fearBar?.adjustCurrentBarValue(theThingThatHitMe.getDamageOnCollide() * -1);
        
    }
}
