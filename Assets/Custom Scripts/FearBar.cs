using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FearBar : Bar
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        barFillVisual = GameObject.Find("FearBarFill");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
