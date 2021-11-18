using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script used for the player movement.
/// </summary>
public class CharacterMovement : MonoBehaviour
{
    // Object to store a rigid body.
    private Rigidbody rb;

    // Variable to check if the player is walking left or right.
    private bool IsWalkingRight = true;

    // Run a ray from the bottom of our character and see if we hit a physical body.
    public Transform rayStart;

    // Animator property
    private Animator anim;


    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Initialize the rigid body. (Getting character's rigid body)
        rb = GetComponent<Rigidbody>();

        // Initialize the Animator. (Getting character's animations.)
        anim = GetComponent<Animator>();
    }

    // Function called every fixed framerate frame
    private void FixedUpdate()
    {
        // Move the player by a certain amount forward depending on how much time has passed.
        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
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
    }

    private void Switch()
    {
        IsWalkingRight = !IsWalkingRight;

        // If the player is walking right, change the player's rotation to 45 degrees
        if (IsWalkingRight)
            transform.rotation = Quaternion.Euler(0, 45, 0);
        else 
            // If the player is walking left, change the player's rotation to -45 degrees
            transform.rotation = Quaternion.Euler(0, -45, 0);
    }
}
