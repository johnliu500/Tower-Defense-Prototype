using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;


public class enemyHP : MonoBehaviour
{
    public float currHP;
    public float maxHP;

    public GameObject HPPrefab;
    private Slider slider;

    private GameObject myHP;
    void Start()
    {
        
        myHP = Instantiate(HPPrefab, gameObject.transform.position, gameObject.transform.rotation);
        slider = myHP.transform.GetChild(0).GetChild(0).GetComponent<Slider>();
        currHP = maxHP;
        slider.value = currHP/maxHP;
    }

    void Update()
    {
        myHP.transform.position = gameObject.transform.position;
        slider.value = currHP/maxHP;
        if (currHP<=0){
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("text");
            string[] words = gos[0].GetComponent<TextMeshPro>().text.Split(' ');
            if (gameObject.GetComponent<Renderer>().material.color == Color.red)
                gos[0].GetComponent<TextMeshPro>().SetText("Currency: "+(Int32.Parse(words[1])+1));
            else if (gameObject.GetComponent<Renderer>().material.color == Color.blue)
                gos[0].GetComponent<TextMeshPro>().SetText("Currency: "+(Int32.Parse(words[1])+2));
            Destroy(myHP);
            Destroy(gameObject);
        }

    }

    public void TakesDamage(int damage){
        currHP-=damage;
    }

    public void ExitsSafely(){
        Destroy(myHP);
        Destroy(gameObject);
    }

}
