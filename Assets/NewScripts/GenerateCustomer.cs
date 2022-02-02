using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerateCustomer : MonoBehaviour
{
    [SerializeField] private GameObject[] list;

    public static bool generate;

    void Start()
    {
        generate = false;
    }

    private void Update()
    {
        if (!generate)
        {
            Instantiate(list[Random.Range(0, list.Length - 1)], transform.position, Quaternion.identity);
            generate = true;
        }
    }

}