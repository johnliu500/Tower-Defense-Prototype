using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroysEnemies : MonoBehaviour
{
    // Start is called before the first frame update
    private int timeAlive = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive++;
        Destroy(gameObject, 1);
    }
    void OnCollisionEnter(Collision col) 
    {
        // When target is hit
        if(col.gameObject.tag == "Enemy")
        {
            Destroy(col.gameObject);
            Destroy(gameObject);
        }else if ((col.gameObject.tag!="Turret") && (col.gameObject.tag!="Bullet")&& (timeAlive>10))
            Destroy(gameObject);
    }

}
