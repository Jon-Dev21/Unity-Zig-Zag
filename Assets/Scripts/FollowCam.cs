using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to make the camera follow the player 
/// while it's progressing through the course.
/// </summary>
public class FollowCam : MonoBehaviour
{
    // Position of the target we want to follow (Player).
    public Transform target;

    // Offset to our player (What is our position in comparison to the player)
    private Vector3 offset;

    // Method runs when script loads
    void Awake()
    {
        // Setting the offset (camera position - player position)
        offset = transform.position - target.position;
    }

    // This method is called in every frame if the behavior is enabled.
    // (Method usually used for camera updates)
    private void LateUpdate()
    {
        // Change the position of our camera. (Follow the player)
        transform.position = target.position + offset;
    }
}
