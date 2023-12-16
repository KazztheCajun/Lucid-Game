using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
   [SerializeField] protected float damageOnCollide;

   [SerializeField] protected float speed;

   [SerializeField] protected LayerMask playerLayer;

   [SerializeField] protected Rigidbody2D physics;

   public virtual void Start(){
    damageOnCollide = 10;
    physics = GetComponent<Rigidbody2D>();
   }
}
