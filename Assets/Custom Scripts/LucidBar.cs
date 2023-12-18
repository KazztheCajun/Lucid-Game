using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LucidBar : Bar
{
    [SerializeField] private float lucidityChangeRate; // percent to drain per second.
    private GameObject gameManager;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        lucidityChangeRate = -1;
        barFillVisual = GameObject.Find("LucidBarFill");
        gameManager = GameObject.Find("GameManager");
    }

    // Update is called once per frame
    void Update()
    {
        
        //Figure out how much the current lucidty changes based on drain rate.
        float amountToDrain = lucidityChangeRate * Time.deltaTime;

        //Actually update the current lucidity.
        adjustCurrentBarValue(amountToDrain);

        if(gameManager && amountToDrain <= 0){
            gameManager.GetComponent<GameManager>().totalAmountOfLucidUsed += amountToDrain;
        }

    }

    public float getChangeRate(){
        return lucidityChangeRate; 
    }

    public void setChangeRate(float newChangeRate){
        lucidityChangeRate = newChangeRate;
    }


/*





    }



    */
}
