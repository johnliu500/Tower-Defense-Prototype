using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCams : MonoBehaviour
{
    public GameObject textCurr;
    public GameObject[] textLives;
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Rotate(Vector3.back * 1.0f);
            foreach (GameObject text in textLives)
            {  
                Transform textform = text.transform;
                textform.RotateAround(
                    new Vector3(gameObject.transform.position.x, textform.position.y, gameObject.transform.position.z),
                     Vector3.up, 1.0f);


            }
        }
        if (Input.GetKey(KeyCode.D)){
            gameObject.transform.Rotate(Vector3.forward * 1.0f);
            foreach (GameObject text in textLives)
            {  
                Transform textform = text.transform;
                textform.RotateAround(
                    new Vector3(gameObject.transform.position.x, textform.position.y, gameObject.transform.position.z),
                     Vector3.up, -1.0f);
            } 
        }

        

    }
}
