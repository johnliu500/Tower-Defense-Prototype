using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class destroysEnemies : MonoBehaviour
{
    private int timeAlive = 0;
    public int damageDealt;

    void Update()
    {
        timeAlive++;
        Destroy(gameObject, .2f);
    }
    void OnCollisionEnter(Collision col) 
    {
        if(col.gameObject.tag == "Enemy")
        {
            col.gameObject.GetComponent<enemyHP>().TakesDamage(damageDealt);
            Destroy(gameObject);            
        }else if ((col.gameObject.tag!="Turret") && (col.gameObject.tag!="Bullet")&& (timeAlive>20))
            Destroy(gameObject);
    }

}
