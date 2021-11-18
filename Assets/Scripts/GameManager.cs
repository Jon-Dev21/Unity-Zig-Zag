using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script controls our game states.
/// </summary>
public class GameManager : MonoBehaviour
{
    // Boolean value to tell if the game is started or not.
    public bool gameStarted;

    /// <summary>
    /// Sets gameStarted to true
    /// </summary>
    public void StartGame()
    {
        gameStarted = true;
    }

    /// <summary>
    /// Check for user input to start the game.
    /// Sets gameStarted to True
    /// </summary>
    private void Update()
    {
        // If the Enter key is pressed, start the game.
        if(Input.GetKeyDown(KeyCode.Return))
        {
            StartGame();
        }
    }
}
