using System;
using UnityEngine;

public class LampuMerah : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && LampuMerahActive.redActive)
        {
            Data.message = "Kamu menerobos! Lain kali tunggu hijau dulu";
            
            // is GamevOver
            Data.isGameOver = true;
            Time.timeScale = 0f;
        }
    }
}