using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public float totalAmountOfLucidUsed;
    
    void Start()
    {
        DontDestroyOnLoad(this);
        totalAmountOfLucidUsed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q)){
            Debug.Log("The player pushed Q! Time to quit!");
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }
        if(Input.GetKeyDown(KeyCode.V)){
            SceneManager.LoadScene("VictoryScreen");
        }
    }
}
