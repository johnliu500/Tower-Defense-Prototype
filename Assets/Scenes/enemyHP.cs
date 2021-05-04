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

    public GameObject healthBarUI;
    public GameObject HPPrefab;
    private GameObject sliderPrefab;
    public Slider slider;

    private GameObject myHP;
    // Start is called before the first frame update
    void Start()
    {
        
        /*GameObject tempObject = GameObject.Find("CanvasHP");
        if(tempObject != null){
        //If we found the object , get the Canvas component from it.
            healthBarUI = tempObject;
            print("piper");
        } else print ("oogoa");*/


        myHP = Instantiate(/*sliderPrefab*/HPPrefab, gameObject.transform.position, gameObject.transform.rotation);
        //bullet.transform.position.x = bullet.transform.position.x - FindClosestEnemy().transform.position.x*.1;
        //bullet.transform.position.z = bullet.transform.position.z - FindClosestEnemy().transform.position.z*.1;

        /*bullet.transform.position = new Vector3(bullet.transform.position.x,
        bullet.transform.position.y, bullet.transform.position.z);*/
        //GameObject canvas = GameObject.Find("Canvas");
        //slider = canvas.GetComponentInChildren(typeof(Slider)) as Slider;//canvas.transform.Find("enemyHPSlider").GetComponent<Slider>();
        slider = myHP.transform.GetChild(0).GetChild(0).GetComponent<Slider>();
        //print(myHP.transform.GetChild(0));
        //print(myHP.transform.GetChild(0).GetChild(0));
        currHP = maxHP;
        slider.value = currHP/maxHP;
        //print(slider.value);
    }

    // Update is called once per frame
    void Update()
    {
        myHP.transform.position = gameObject.transform.position;
        //currHP-=1;
        slider.value = currHP/maxHP;
        //print(slider.value);

        /*if (currHP<maxHP) 
            healthBarUI.SetActive(true);*/
        if (currHP<=0){
            GameObject[] gos;
            gos = GameObject.FindGameObjectsWithTag("text");
            string[] words = gos[0].GetComponent<TextMeshPro>().text.Split(' ');
            if (gameObject.GetComponent<Renderer>().material.color == Color.red)
                gos[0].GetComponent<TextMeshPro>().SetText("Currency: "+(Int32.Parse(words[1])+1));
            else if (gameObject.GetComponent<Renderer>().material.color == Color.blue)
                gos[0].GetComponent<TextMeshPro>().SetText("Currency: "+(Int32.Parse(words[1])+2));

            //print(gameObject.GetComponent<Renderer>().material.color == Color.red);

            Destroy(myHP);
            Destroy(gameObject);
        }

    }

    public void TakesDamage(int damage){
        currHP-=damage;
       // print(currHP/maxHP);
    }

    public void ExitsSafely(){
        Destroy(myHP);
        Destroy(gameObject);
    }

}
