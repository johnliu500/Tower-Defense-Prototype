using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shootsAtEnemies : MonoBehaviour
{
    public GameObject[] targets;
    private float range = 3f;

    private Quaternion _lookRotation;
    private Vector3 _direction;

    public GameObject bulletPrefab;
    public int damageDealt;
    public int buyPrice;
    public int sellPrice;
    public int interval;
    private int counter = 180;

    void Start()
    {
        counter = interval - 20;

    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    void Update()
    {
        if (Time.timeScale == 0)
            return;

        if (counter == interval){
            if (FindClosestEnemy()==null) {
                
            } else if (Vector3.Distance(FindClosestEnemy().transform.position, gameObject.transform.position)>range){
                gameObject.transform.LookAt(FindClosestEnemy().transform.position);

            }else if (Vector3.Distance(FindClosestEnemy().transform.position, gameObject.transform.position)<range){

                gameObject.transform.LookAt(FindClosestEnemy().transform.position);
                GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);

                bullet.transform.position = new Vector3(bullet.transform.position.x, 
                bullet.transform.position.y, bullet.transform.position.z);
                bullet.GetComponent<destroysEnemies>().damageDealt = damageDealt;
                bullet.GetComponent<Rigidbody>().velocity 
                    = new Vector3( (FindClosestEnemy().transform.position.x-bullet.transform.position.x)*5.0f, 
                    0,
                (FindClosestEnemy().transform.position.z-bullet.transform.position.z)*5.0f);
                counter=0;
                gameObject.GetComponent<AudioSource>().Play();
            }
        } else {
            if (FindClosestEnemy()!=null) 
                gameObject.transform.LookAt(FindClosestEnemy().transform.position);
            counter++;
        }
    }
}
