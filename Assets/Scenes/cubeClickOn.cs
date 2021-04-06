using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeClickOn : MonoBehaviour
{
    public GameObject turretPrefab;
    private bool clickedOn = false;

    private GameObject menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown()
    {
        // Destroy the gameObject after clicking on it
        //Destroy(gameObject);
        //print("Hello World");
        if (!clickedOn){
             menu = Instantiate(turretPrefab, gameObject.transform.position, gameObject.transform.rotation);
            //GameObject parent = (GameObject)FindObjectOfType(typeof(cubeClickOn));
            Vector3 parentTrans = gameObject.transform.position;
            menu.transform.position = new Vector3(parentTrans.x, parentTrans.y+1, parentTrans.z);
            clickedOn = true;
            shootsAtEnemies shoots = menu.AddComponent<shootsAtEnemies>();
        } else {
            Destroy(menu);
            clickedOn = false;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
