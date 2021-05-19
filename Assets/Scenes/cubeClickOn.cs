using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.UI;

public class cubeClickOn : MonoBehaviour
{
    public GameObject[] turretPrefab;
    private bool clickedOn = false;
    public Toggle[] toggles;

    private GameObject menu;
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        if (!clickedOn){
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("text");
            string[] words = gos[0].GetComponent<TextMeshPro>().text.Split(' ');
            
            if (toggles[0].isOn){
                if (Int32.Parse(words[1]) >= 3){
                    menu = Instantiate(turretPrefab[0], gameObject.transform.position, gameObject.transform.rotation);
                    Vector3 parentTrans = gameObject.transform.position;
                    menu.transform.position = new Vector3(parentTrans.x, parentTrans.y+0.5f, parentTrans.z);
                    clickedOn = true;
                    gos[0].GetComponent<TextMeshPro>().SetText("Currency: "+(Int32.Parse(words[1])
                        -menu.GetComponent<shootsAtEnemies>().buyPrice));
                }
            } else {
                if (Int32.Parse(words[1]) >= 6){
                    menu = Instantiate(turretPrefab[1], gameObject.transform.position, gameObject.transform.rotation);
                    Vector3 parentTrans = gameObject.transform.position;
                    menu.transform.position = new Vector3(parentTrans.x, parentTrans.y+0.5f, parentTrans.z);
                    clickedOn = true;
                    gos[0].GetComponent<TextMeshPro>().SetText("Currency: "+(Int32.Parse(words[1])
                        -menu.GetComponent<shootsAtEnemies>().buyPrice));
                }

            }
        } else {
            clickedOn = false;

            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("text");
            string[] words = gos[0].GetComponent<TextMeshPro>().text.Split(' ');
            gos[0].GetComponent<TextMeshPro>().SetText("Currency: "+(Int32.Parse(words[1])
                +menu.GetComponent<shootsAtEnemies>().sellPrice));
            Destroy(menu);


        }

    }

    public void reset(){
        clickedOn = false;
    }
    void Update()
    {
        
    }
}
