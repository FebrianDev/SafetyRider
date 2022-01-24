using UnityEngine;

public class TrafficLane : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            Data.message = "Kamu menabrak marka jalan!, lain kali hindari";
            
            // is Game Over
            Data.isGameOver = true;
            Time.timeScale = 0f;
        }
    }
}