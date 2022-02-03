using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomizeCustomer : MonoBehaviour
{
    [SerializeField] private SpriteRenderer sepeda, kaos;
    [SerializeField] private GameObject[] rambut;

    void Start()
    {
        sepeda.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        kaos.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        var rand = Random.Range(0, rambut.Length);
        for (var i = 0; i < rambut.Length; i++)
        {
            rambut[i].SetActive(rand == i);
        }
    }
}