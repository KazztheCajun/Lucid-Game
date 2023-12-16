using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   [SerializeField] protected float damageDealtOnHit;

   [SerializeField] protected float speed;

   protected virtual void Start(){
     damageDealtOnHit = 10;
   }
}
