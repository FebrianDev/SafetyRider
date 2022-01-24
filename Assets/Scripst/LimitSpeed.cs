using System.Collections;
using UnityEngine;

public class LimitSpeed : MonoBehaviour
{
    public static bool limitSpeedActive;

    private void Start()
    {
        limitSpeedActive = false;
        showSpeed.SetActive(false);
    }

    [SerializeField] private GameObject showSpeed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !limitSpeedActive)
        {
            showSpeed.SetActive(true);
            StartCoroutine("LimitActive");
        }
    }

    IEnumerator LimitActive()
    {
        yield return new WaitForSeconds(2);
        limitSpeedActive = true;
    }
}