using UnityEngine;

public class Stop : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Data.message = "Kamu melanggar rambu berhenti!";

            // is Game Over
            Data.isGameOver = true;
            Time.timeScale = 0f;
        }
    }
}