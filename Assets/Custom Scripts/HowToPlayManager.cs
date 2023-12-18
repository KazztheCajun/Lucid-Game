using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlayManager : MonoBehaviour
{
   
   public void OnBackButtonPushed(){
        Debug.Log("Back button pushed!");
        SceneManager.LoadScene("StartScreen");
   }
}
