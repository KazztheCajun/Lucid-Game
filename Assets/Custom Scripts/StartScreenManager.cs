using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenManager : MonoBehaviour
{
 
    [SerializeField] private GameObject megaParticleSystem;
    [SerializeField] private Image fadeToBlack;
    private float timeBeforeTransition;
    private float fadeRate;

    private bool beginTransition = false;

    public void Start(){
        beginTransition = false;
        fadeRate = 0.25f;
        timeBeforeTransition = 4f;
    }

    public void Update(){
        if(beginTransition){
            timeBeforeTransition -= Time.deltaTime;
            Color newColor = fadeToBlack.color;
            newColor.a += fadeRate * Time.deltaTime;
            fadeToBlack.color = newColor;
            if(timeBeforeTransition <= 0){
                SceneManager.LoadScene("MainScene");
            }
        }
    }


    public void OnStartGameButtonClicked(){
        Debug.Log("Start button clicked!");
        megaParticleSystem.SetActive(true);
        fadeToBlack.gameObject.SetActive(true);
        beginTransition = true;
       // SceneManager.LoadScene("MainScene");
    }

    public void OnCreditsButtonClicked(){
        Debug.Log("Credits button clicked!");
        SceneManager.LoadScene("CreditsScene");
    }

    public void OnHowToPlayButtonClicked(){
        Debug.Log("How to Play Button Clicked");
        SceneManager.LoadScene("HowToPlayScene");
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
