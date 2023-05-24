using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : GameManager
{
    public static ScoreManager Instance { get; private set; }

    private int score;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddScore(int points)
    {
        score += points;
        Debug.Log("Score increased by: " + points);
    }
}
