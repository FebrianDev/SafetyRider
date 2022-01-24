using System.Collections;
using UnityEngine;

public class LampuMerahActive : MonoBehaviour
{
    [SerializeField] private GameObject red, yellow, green;

    public static bool redActive;

    void Start()
    {
        StartCoroutine("Red");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Lampu "+redActive);
    }

    IEnumerator Red()
    {
        SetSprite(true, false,false);
        redActive = true;
        yield return new WaitForSeconds(4);
        StartCoroutine("Yellow");
    }

    IEnumerator Yellow()
    {
        SetSprite(false, true,false);
        yield return new WaitForSeconds(1);
        StartCoroutine("Green");
    }

    IEnumerator Green()
    {
        redActive = false;
        yield return new WaitForSeconds(2);
        SetSprite(false, false,true);
        yield return new WaitForSeconds(4);
        redActive = false;
        yield return new WaitForSeconds(2);
        StartCoroutine("Red");
    }

    private void SetSprite(bool redAct, bool yellowActive, bool greenActive)
    {
        red.SetActive(redAct);
        yellow.SetActive(yellowActive);
        green.SetActive(greenActive);
    }
}