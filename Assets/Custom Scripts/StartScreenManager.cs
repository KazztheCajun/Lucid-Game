using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreenManager : MonoBehaviour
{
 
    public void OnStartGameButtonClicked(){
        Debug.Log("Start button clicked!");
    }

    public void OnCreditsButtonClicked(){
        Debug.Log("Credits button clicked!");
    }

    public void OnQuitButtonClicked(){
        Debug.Log("Quit button clicked!");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
