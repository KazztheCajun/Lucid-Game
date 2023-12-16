using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseEnemy : Enemy
{
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
