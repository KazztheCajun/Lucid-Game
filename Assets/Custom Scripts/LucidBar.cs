using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucidBar : Bar
{
    [SerializeField] private float lucidityChangeRate; // percent to drain per second.

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        lucidityChangeRate = -1;
        barFillVisual = GameObject.Find("LucidBarFill");
    }

    // Update is called once per frame
    void Update()
    {
        
        //Figure out how much the current lucidty changes based on drain rate.
        float amountToDrain = lucidityChangeRate * Time.deltaTime;

        //Actually update the current lucidity.
        adjustCurrentBarValue(amountToDrain);

    }


/*





    }



    */
}
