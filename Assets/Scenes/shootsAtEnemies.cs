using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootsAtEnemies : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] targets;
    private float range = 3f;
    private int counter = 0;

    private Quaternion _lookRotation;
    private Vector3 _direction;

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
        if (counter == 200){
            if (FindClosestEnemy()==null) {
                
            } else if (Vector3.Distance(FindClosestEnemy().transform.position, gameObject.transform.position)>range){
                gameObject.transform.LookAt(FindClosestEnemy().transform.position);

            }else if (Vector3.Distance(FindClosestEnemy().transform.position, gameObject.transform.position)<range){
                /*_direction = (FindClosestEnemy().transform.position - gameObject.transform.position).normalized;
                gameObject.transform
                //create the rotation we need to be in to look at the target
                _lookRotation = Quaternion.LookRotation(_direction);
        
                //rotate us over time according to speed until we are in the required rotation
                gameObject.transform.rotation = Quaternion.Slerp(gameObject.transform.rotation, _lookRotation, Time.deltaTime);
*/             
                gameObject.transform.LookAt(FindClosestEnemy().transform.position);

                Destroy(FindClosestEnemy());
                counter=0;
            }
        } else {
            if (FindClosestEnemy()!=null)
                gameObject.transform.LookAt(FindClosestEnemy().transform.position);

            counter++;
        }
    }
}
