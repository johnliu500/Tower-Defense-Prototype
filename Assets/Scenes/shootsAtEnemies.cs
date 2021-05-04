using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class shootsAtEnemies : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] targets;
    private float range = 3f;
    private int counter = 180;

    private Quaternion _lookRotation;
    private Vector3 _direction;

    public GameObject bulletPrefab;
    public int damageDealt;
    public int buyPrice;
    public int sellPrice;

    void Start()
    {

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
    // Update is called once per frame
    void Update()
    {
       // print(counter);
        if (counter == 200){
            if (FindClosestEnemy()==null) {
                
            } else if (Vector3.Distance(FindClosestEnemy().transform.position, gameObject.transform.position)>range){
                gameObject.transform.LookAt(FindClosestEnemy().transform.position);

            }else if (Vector3.Distance(FindClosestEnemy().transform.position, gameObject.transform.position)<range){
       //         print("we fired");
                /*_direction = (FindClosestEnemy().transform.position - gameObject.transform.position).normalized;
                gameObject.transform
                //create the rotation we need to be in to look at the target
                _lookRotation = Quaternion.LookRotation(_direction);
        
                //rotate us over time according to speed until we are in the required rotation
                gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, _lookRotation, Time.deltaTime);
*/             
                gameObject.transform.LookAt(FindClosestEnemy().transform.position);
                GameObject bullet = Instantiate(bulletPrefab, gameObject.transform.position, gameObject.transform.rotation);
                //bullet.transform.position.x = bullet.transform.position.x - FindClosestEnemy().transform.position.x*.1;
                //bullet.transform.position.z = bullet.transform.position.z - FindClosestEnemy().transform.position.z*.1;

                bullet.transform.position = new Vector3(bullet.transform.position.x/* - FindClosestEnemy().transform.position.x*.1f*/, 
                bullet.transform.position.y, bullet.transform.position.z/* - FindClosestEnemy().transform.position.z*.1f*/);
                bullet.GetComponent<destroysEnemies>().damageDealt = damageDealt;
                bullet.GetComponent<Rigidbody>().velocity 
                    = new Vector3( (FindClosestEnemy().transform.position.x-bullet.transform.position.x)*5.0f, 
                    (bullet.transform.position.y-FindClosestEnemy().transform.position.y)*2.0f,
                (FindClosestEnemy().transform.position.z-bullet.transform.position.z)*5.0f);


                //Destroy(FindClosestEnemy());
                counter=0;
            }
        } else {
            /*if (FindClosestEnemy()!=null) 
                gameObject.transform.LookAt(FindClosestEnemy().transform.position);*/
            counter++;
        }
    }
}
