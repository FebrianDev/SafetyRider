using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limit : MonoBehaviour
{
    [SerializeField] private Transform posBg;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            posBg.position = new Vector3(posBg.position.x, posBg.position.y + 30, posBg.position.z);
        }
    }
}
