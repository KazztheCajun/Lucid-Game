using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour
{
 
    public void OnStartGameButtonClicked(){
        Debug.Log("Start button clicked!");
        SceneManager.LoadScene("AwakeScene");
    }

    public void OnCreditsButtonClicked(){
        Debug.Log("Credits button clicked!");
        SceneManager.LoadScene("CreditsScene");
    }

    public void OnQuitButtonClicked(){
        Debug.Log("Quit button clicked!");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }

    public void BenButtonClicked(){
        Debug.Log("Ben button clicked!");
        SceneManager.LoadScene("BenScene");
    }

    public void AAronButtonClicked(){
        Debug.Log("AAron button clicked!");
        SceneManager.LoadScene("AAronScene");
    }

    public void SergioButtonClicked(){
        Debug.Log("Sergio button clicked!");
        SceneManager.LoadScene("Sergio Scene");
    }
}
