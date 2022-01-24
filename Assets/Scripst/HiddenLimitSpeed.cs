using UnityEngine;

public class HiddenLimitSpeed : MonoBehaviour
{
    [SerializeField] private GameObject showSpeed;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            showSpeed.SetActive(false);
            LimitSpeed.limitSpeedActive = false;
        }
    }
}