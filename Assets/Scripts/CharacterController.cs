using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    // Object to store a rigid body.
    private Rigidbody rb;

    // Variable to check if the player is walking left or right.
    private bool IsWalkingRight = true;

    // Awake is called when the script instance is being loaded
    void Awake()
    {
        // Initialize the rigid body. (Getting character's rigid body)
        rb = GetComponent<Rigidbody>();
    }

    // Function called every fixed framerate frame
    private void FixedUpdate()
    {
        // Mpve the player by a certain amount forward depending on how much time has passed.
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
