﻿using UnityEngine;

public class TrafficLane : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // is Game Over
            Data.isGameOver = true;
            Time.timeScale = 0f;
        }
    }
}