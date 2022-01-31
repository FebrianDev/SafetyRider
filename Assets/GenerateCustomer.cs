using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCustomer : MonoBehaviour
{
    [SerializeField] private GameObject[] list;

    void Start()
    {
        StartCoroutine("Generate");
    }

    IEnumerator Generate()
    {
        while (true)
        {
            Instantiate(list[Random.Range(0, list.Length - 1)], transform.position, Quaternion.identity);
            yield return new WaitForSeconds(8);
        }
    }
}