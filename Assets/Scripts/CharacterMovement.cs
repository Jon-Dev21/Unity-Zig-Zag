using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script used for the player movement.
/// </summary>
public class CharacterMovement : MonoBehaviour
{
    // Game manager object to handle game states.
    private GameManager gameManager;

    // Object to store a rigid body.
    private Rigidbody rb;

    // Variable to check if the player is walking left or right.
    private bool IsWalkingRight = true;

    // Run a ray from the bottom of our character and see if we hit a physical body.
    public Transform rayStart;

    // Animator property
    private Animator anim;

    // Creating a new ring effect object.
    public GameObject ringEffect;

    // An audioSource for the ring sound when picked up.
    public AudioSource ringSound;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Initialize our game manager. (This object contains our script code).
        gameManager = FindObjectOfType<GameManager>();

        // Initialize the rigid body. (Getting character's rigid body)
        rb = GetComponent<Rigidbody>();

        // Initialize the Animator. (Getting character's animations.)
        anim = GetComponent<Animator>();
    }

    // Function called every fixed framerate frame
    private void FixedUpdate()
    {
        // Check if game has not started.
        if(!gameManager.gameStarted)
        {
            // Don't start moving player.
            return;
        } else // The game is started
        {
            // Set the animation trigger, gameStarted in order to move from idle animation to running animation.
            anim.SetTrigger("gameStarted");
        }

        // Move the player by a certain amount forward depending on how much time has passed.
        rb.transform.position = transform.position + transform.forward * 5 * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Check for input.
        // If the spacebar is clicked.
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Switch();
        }

        // Creating a raycastHit to check if a ray hit a physical body below the character.
        RaycastHit hit;

        // Check if we're still running on ground / not falling.
        // If the ray has not hit anything below the player, it is falling.
        if (!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
        {
            // Sets the value of the trigger parameter in the animation controller.
            anim.SetTrigger("isFalling");
        }

        // If the character fell,
        if(transform.position.y < -2)
        {
            // End the game.
            gameManager.EndGame();
        }
    }

    /// <summary>
    /// Method used to change character direction. 
    /// Direction can be either 45 degrees or -45 degrees.
    /// Direction will change when the spacebar is pressed.
    /// </summary>
    private void Switch()
    {
        // Preventing player to change direction before starting game.
        // Check if game has not started.
        if (!gameManager.gameStarted)
        {
            // Don't start moving player.
            return;
        }

        // Change ballue from true to false and vice versa.
        IsWalkingRight = !IsWalkingRight;

        // If the player is walking right, change the player's rotation to 45 degrees
        if (IsWalkingRight)
            transform.rotation = Quaternion.Euler(0, 45, 0);
        else 
            // If the player is walking left, change the player's rotation to -45 degrees
            transform.rotation = Quaternion.Euler(0, -45, 0);
    }


    /// <summary>
    /// Method is called whenever the character touches a ring (Collides with object)
    /// When a ring is collected, it is destroyed and the score is increased.
    /// The ring effect will also be shown.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ring")
        {
            // Increase the current score.
            gameManager.IncreaseScore();

            // Create a RingEffect object in the position of the raystart (Chest) of our player. (Quaternion.identity means no rotation)
            GameObject ringParticles = Instantiate(ringEffect, rayStart.transform.position, Quaternion.identity);

            // Destroy the particles after 2 seconds.
            Destroy(ringParticles, 2);

            // Destroy the ring Object. (LOTR Music playing)
            Destroy(other.gameObject);

            // Play the ring sound when picked
            ringSound.Play();
        }
    }
}
