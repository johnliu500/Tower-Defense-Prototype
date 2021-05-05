using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class helpPause : MonoBehaviour
{
    public GameObject helpScreen;
    void Start(){
        Time.timeScale = 0;
        helpScreen.GetComponent<Canvas>().enabled = true;
    }
    public void Pause(){
        Time.timeScale = 0;
        helpScreen.GetComponent<Canvas>().enabled = true;
    }
    public void Return(){
        Time.timeScale = 1;
        helpScreen.GetComponent<Canvas> ().enabled = false;
    }
}
