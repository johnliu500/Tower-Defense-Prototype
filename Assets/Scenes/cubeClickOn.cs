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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        // Destroy the gameObject after clicking on it
        //Destroy(gameObject);
        //print("Hello World");
        //print(turretPrefab.Length);
        foreach (var toggle in toggles)
        {
            //print(toggle.isOn);
        }

        if (!clickedOn){
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("text");
            string[] words = gos[0].GetComponent<TextMeshPro>().text.Split(' ');
            //gos[0].GetComponent<TextMeshPro>().SetText("Currency: "+(Int32.Parse(words[1])));
            
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
            //GameObject parent = (GameObject)FindObjectOfType(typeof(cubeClickOn));
                
            //shootsAtEnemies shoots = menu.AddComponent<shootsAtEnemies>();
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
