using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Animator[] anim;

    void Start()
    {
        foreach (var a in anim)
        {
            a.enabled = false;
        }

        StartCoroutine("StartTutorial");
    }

    IEnumerator StartTutorial()
    {
        anim[0].enabled = true;
        yield return new WaitForSeconds(8);
        anim[1].enabled = true;
        yield return new WaitForSeconds(8);
        anim[2].enabled = true;
        yield return new WaitForSeconds(8);
        PlayerPrefs.SetString(Constant.TUTORIAL, Constant.TUTORIAL);
        SceneManager.LoadScene("SampleScene");
    }
}