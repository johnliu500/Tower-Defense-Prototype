using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;


public class gameOver : MonoBehaviour
{
    public GameObject livesLeft;
    public GameObject totalScore;
    private bool finished = false;
    public GameObject scoreBoard;
    public GameObject eliteSwitch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!finished){
            string[] words = livesLeft.GetComponent<TextMeshPro>().text.Split(' ');
            if (Int32.Parse(words[2]) <= 0){
                Finish();
                finished = true;
            }
        }

    }

    public void Finish(/*int score*/){
        gameObject.GetComponent<Canvas> ().enabled = true;
        string[] words = totalScore.GetComponent<TextMeshPro>().text.Split(' ');
        //print(words[1]);/
        //.GetChild(0).GetComponent<TextMeshPro>();
        //gameObject.transform.GetChild(0).GetChild(1).GetComponent<TextMeshPro>().SetText("");
        scoreBoard.GetComponent<TMP_Text>().SetText("Final Score: "+words[1]);
        ///print(gameObject.transform.GetChild(0).GetChild(1)/*.text*/);

    }

    public void Restart(){
        gameObject.GetComponent<Canvas> ().enabled = false;
        
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject go in gos)
        {
            go.GetComponent<enemyHP>().ExitsSafely();
        }
        gos = GameObject.FindGameObjectsWithTag("Turret");
        foreach (GameObject go in gos)
        {
            Destroy(go);
        }
        gos = GameObject.FindGameObjectsWithTag("Wall");
        foreach (GameObject go in gos)
        {
            go.GetComponent<cubeClickOn>().reset();
        }

        totalScore.GetComponent<TextMeshPro>().SetText("Currency: 6");
        livesLeft.GetComponent<TextMeshPro>().SetText("Lives Left: 5");

        eliteSwitch.GetComponent<EnemySpawn>().counter = 0;
        finished = false;
        eliteSwitch.GetComponent<EnemySpawn>().notif.GetComponent<TextMeshPro>().SetText("");

    }
}
