using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.UI;
using System;
using TMPro;


public class path : MonoBehaviour {

    public GameObject[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;

    void Start () {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        GotoNextPoint();
    }


    void GotoNextPoint() {
        if (points.Length == 0)
            return;
        if (destPoint>=points.Length){
            gameObject.GetComponent<enemyHP>().ExitsSafely();
            
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("livesText");
            string[] words = gos[0].GetComponent<TextMeshPro>().text.Split(' ');
            if (Int32.Parse(words[2])>0)
                gos[0].GetComponent<TextMeshPro>().SetText("Lives Left: "+(Int32.Parse(words[2])-1));
            return;
        }

        agent.destination = points[destPoint].transform.position;

        destPoint = (destPoint + 1);
    }


    void Update () {
        if (!agent.pathPending && agent.remainingDistance < 0.5f){
            GotoNextPoint();
        }
    }
}
