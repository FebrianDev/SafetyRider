using UnityEngine;

    public class Lubang : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {

                Data.message = "Kamu terperosok dalam lubang!, Kondisikan tetap tenang dan fokus";
            
                // is Game Over
                Data.isGameOver = true;
                Time.timeScale = 0f;
            }
        }
    }
