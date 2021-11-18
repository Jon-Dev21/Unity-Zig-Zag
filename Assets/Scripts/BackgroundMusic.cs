using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    public static BackgroundMusic instance;

    private void Awake()
    {
        // This code prevents the script from creating new instances of the background music when the character dies.
        // If the BackgroundMusic is null
        if (instance == null)
            instance = this;    // Set instance to this current one.
        else if (instance != this) // Else if the instance is not equal to this instance.
            Destroy(gameObject); // Destroy the current instance and let the previous one keep playing

        // Keep music running even when character dies.
        DontDestroyOnLoad(gameObject);
    }
}
