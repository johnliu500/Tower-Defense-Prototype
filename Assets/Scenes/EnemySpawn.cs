using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class EnemySpawn : MonoBehaviour
{
    public GameObject location;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    //public int numEnemies = 5;
    private List<Enemy> enemies;
    //private int counter = 0;
    public GameObject enemyPrefab;
    public GameObject[] goal;

    private int counter;

    public GameObject notif;

    // Start is called before the first frame update
    void Start()
    {
        //print("started");
        enemies = new List<Enemy>();
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnObject(){
        //Enemy spawnedEnemy = new Enemy();
        //containEnemy = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //Enemy enemy = gameObject.addComponent<Enemy> as Enemy;
        GameObject enemySphere = Instantiate(enemyPrefab, location.transform.position, location.transform.rotation);
        Renderer rend = enemySphere.GetComponent<Renderer>();
        rend.material.color = Color.red;
        counter++;
        if (counter>5){
            if (counter==8) notif.GetComponent<TextMeshPro>().SetText("Elite Enemies now Spawning");
            if (counter==14) notif.GetComponent<TextMeshPro>().SetText("");
            counter++;
            if (counter%5>0){
                rend.GetComponent<enemyHP>().maxHP = 10;
            } else {
                rend.material.color = Color.blue;
                rend.GetComponent<enemyHP>().maxHP = 20;
            }
        }

        enemySphere.SetActive(true);
        enemySphere.transform.position = location.transform.position;
        enemySphere.transform.rotation = location.transform.rotation;
        Enemy spawnedEnemy = enemySphere.AddComponent<Enemy>();
        enemySphere.GetComponent<path>().points = goal;
        enemySphere.tag = "Enemy";



        enemies.Add(spawnedEnemy);
        if (stopSpawning){
            CancelInvoke("SpawnObject");
        }
    }
}
