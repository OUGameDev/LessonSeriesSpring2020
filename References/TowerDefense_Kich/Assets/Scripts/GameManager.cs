using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : UnityEngine.MonoBehaviour
{
    public static bool isGameOver;

    private void Start()
    {
        isGameOver = false;
    }

    private void Update()
    {
        if (isGameOver)
        {
            Debug.Log("Game is over");
            enabled = false;
        }
    }

    public void GameOver()
    {
        isGameOver = true;
    }
}
