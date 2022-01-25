using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Navigation : MonoBehaviour
{
    [SerializeField] private Text textNav;
    [SerializeField] private List<GameObject> listAlmanac;
    public static int active = 0;

    [SerializeField] private GameObject prevImg, nextImg;

    void Start()
    {
        Loop();
    }

    private void Update()
    {
        textNav.text = $"{active + 1}/3";
    }

    public void Prev()
    {
        if (active > 0)
        {
            active--;
        }

        Loop();
    }

    public void Next()
    {
        if (active < listAlmanac.Count)
        {
            active++;
        }

        Loop();
    }

    private void Loop()
    {
        for (var i = 0; i < listAlmanac.Count; i++)
        {
            if (i == active)
            {
                listAlmanac[i].SetActive(true);
            }
            else
            {
                listAlmanac[i].SetActive(false);
            }
        }

        prevImg.SetActive(active != 0);
        nextImg.SetActive(active != listAlmanac.Count - 1);
    }
}