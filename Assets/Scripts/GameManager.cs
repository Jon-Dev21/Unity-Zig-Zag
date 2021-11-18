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

    // Text element for the current score in the game.
    public Text scoreText;

    // Text element for the current highscore in the game.
    public Text highscoreText;

    /// <summary>
    /// Will get highscore from player prefs on awake.
    /// </summary>
    private void Awake()
    {
        // Set the highscore.
        highscoreText.text = "Highscore: " + GetHighScore().ToString();
    }

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
    /// It also sets the highscore.
    /// </summary>
    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
        if (score > GetHighScore())
        {
            PlayerPrefs.SetInt("Highscore", score);
        }
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

    /// <summary>
    /// Method returns the high score from PlayerPrefs.
    /// </summary>
    /// <returns></returns>
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("Highscore");
    }
}
