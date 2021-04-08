using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Start is called before the first frame update
    void Start()
    {
        print("started");
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

        enemySphere.SetActive(true);
        enemySphere.transform.position = location.transform.position;
        enemySphere.transform.rotation = location.transform.rotation;
        Enemy spawnedEnemy = enemySphere.AddComponent<Enemy>();
        enemySphere.GetComponent<path>().points = goal;
        enemySphere.tag = "Enemy";



        enemies.Add(spawnedEnemy);
        //print("something happened...");
        if (stopSpawning){
            CancelInvoke("SpawnObject");
        }
    }
}
