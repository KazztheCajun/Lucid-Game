using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScreenManager : MonoBehaviour
{
   public void OnBackToTitleButtonClicked(){
    Debug.Log("Back to title button clicked!");
    SceneManager.LoadScene("StartScreen");
   }
}
