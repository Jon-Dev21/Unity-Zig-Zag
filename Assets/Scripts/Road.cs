using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script used to continuously generate the stage.
/// </summary>
public class Road : MonoBehaviour
{
    // Storing the road prefab with the ring
    public GameObject roadPrefab;

    // Last Block Position is (-2.980232e-07, 0, 7.071068) 

    // Getting position of the last hardcoded road part
    public Vector3 lastBlockPosition;

    // Distance between road blocks
    public float offset = 0.7071068f;

    // Count of created roads.
    private int roadCount = 0;

    /// <summary>
    /// When the script loads, invoke the CreateNewRoadPart method each second.
    /// </summary>
    public void StartBuilding()
    {
        InvokeRepeating("CreateNewRoadPart", 1f, 0.05f);
    }

    /// <summary>
    /// Method used to create new road parts.
    /// </summary>
    public void CreateNewRoadPart()
    {
        // The spawning position of the road part.
        Vector3 spawnPos = Vector3.zero;

        // Get a number between 0 and 100
        float change = Random.Range(0, 100);
        
        // Calculate the spawn position. (Leave it to chance)
        // If the number generated is less than 50
        if(change < 50)
        {
            // Spawn block to the right side. (Add the offset value)
            spawnPos = new Vector3(lastBlockPosition.x + offset, lastBlockPosition.y, lastBlockPosition.z + offset);
        } else
        {
            // Spawn block to the right side. (Subtract the offset value)
            spawnPos = new Vector3(lastBlockPosition.x - offset, lastBlockPosition.y, lastBlockPosition.z + offset);
        }

        // Create the roadPart object.
        GameObject roadBlock = Instantiate(roadPrefab, spawnPos, Quaternion.Euler(0, 45, 0));

        // Set the last block position.
        lastBlockPosition = roadBlock.transform.position;


        // Spawn Rings Section.
        
        // Increment Road Count when a road is created
        roadCount++;

        // Random number that will be used to compare it to the road count.
        float spawnIn = Random.Range(1, 3);
        // If the roadCount is bigger than the spawnIn range, reset it to 0.
        if (roadCount>2)
        {
            roadCount = 0;
        } else
        {
            // If the row count is equal to the spawnIn number.
            if(roadCount == spawnIn)
            {
                // Show the ring
                roadBlock.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
    
}
