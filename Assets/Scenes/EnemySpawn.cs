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
    private List<Enemy> enemies;
    public GameObject enemyPrefab;
    public GameObject[] goal;

    public int counter = 0;

    public GameObject notif;

    void Start()
    {
        enemies = new List<Enemy>();
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }

    void Update()
    {
        
    }

    public void SpawnObject(){
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
