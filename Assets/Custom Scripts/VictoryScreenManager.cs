using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class VictoryScreenManager : MonoBehaviour
{

    GameObject gameManagerReference;
    public TextMeshProUGUI text;


    // Start is called before the first frame update
    void Start()
    {
        gameManagerReference = GameObject.Find("GameManager");
        Debug.Log("I'm in the victory screen!");
        if(gameManagerReference){
            float totalLucid = gameManagerReference.GetComponent<GameManager>().totalAmountOfLucidUsed;
            totalLucid *= -1f; //turn it into a positive number.
            text.text = "Total amount of lucid used is " + totalLucid;
        }
    }

    public void OnBackToStart(){
        SceneManager.LoadScene("StartScreen");
    }

   
}
