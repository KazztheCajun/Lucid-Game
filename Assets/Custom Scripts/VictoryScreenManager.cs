using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScreenManager : MonoBehaviour
{

    GameObject gameManagerReference;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerReference = GameObject.Find("GameManager");
        Debug.Log("I'm in the victory screen!");
        if(gameManagerReference){
            Debug.Log("total amount of lucid used is " + gameManagerReference.GetComponent<GameManager>().totalAmountOfLucidUsed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
