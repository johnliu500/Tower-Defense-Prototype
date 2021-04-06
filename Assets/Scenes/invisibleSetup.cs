using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invisibleSetup : MonoBehaviour
{
    public Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Toggle the Object's visibility each second.
    void Update()
    {
        rend.enabled = false;
    }

}
