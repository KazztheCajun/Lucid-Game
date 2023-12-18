using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnMouseOver : MonoBehaviour
{
   
   [SerializeField] private AudioSource soundToPlay;

    public void OnMouseEnter(){
        Debug.Log("ON MOUSE Enter");
        soundToPlay.Play();
    }
}
