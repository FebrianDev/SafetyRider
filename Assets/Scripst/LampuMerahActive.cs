using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampuMerahActive : MonoBehaviour
{
    [SerializeField] private GameObject red, yellow, green;

    public static bool redActive = true;

    void Start()
    {
        StartCoroutine("Red");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(redActive);
    }

    IEnumerator Red()
    {
        redActive = true;
        SetSprite(true, false,false);
        yield return new WaitForSeconds(10);
        StartCoroutine("Yellow");
    }

    IEnumerator Yellow()
    {
        redActive = false;
        SetSprite(false, true,false);
        yield return new WaitForSeconds(5);
        StartCoroutine("Green");
    }

    IEnumerator Green()
    {
        redActive = false;
        SetSprite(false, false,true);
        yield return new WaitForSeconds(8);
        redActive = false;
        StartCoroutine("Red");
    }

    private void SetSprite(bool redAct, bool yellowActive, bool greenActive)
    {
        red.SetActive(redAct);
        yellow.SetActive(yellowActive);
        green.SetActive(greenActive);
    }
}