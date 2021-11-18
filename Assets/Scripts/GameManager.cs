using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// This script controls our game states.
/// </summary>
public class GameManager : MonoBehaviour
{
    // Boolean value to tell if the game is started or not.
    public bool gameStarted;

    // Variable used to store the game score.
    public int score;

    public Text scoreText;

    /// <summary>
    /// Sets gameStarted to true
    /// </summary>
    public void StartGame()
    {
        gameStarted = true;
    }

    /// <summary>
    /// This method reloads the scene.
    /// </summary>
    public void EndGame()
    {
        // Load the main scene again.
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// This method increases the score by 1.
    /// </summary>
    public void IncreaseScore()
    {
        score++;
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
        scoreText.text = "Score: "+score.ToString();
    }
}
