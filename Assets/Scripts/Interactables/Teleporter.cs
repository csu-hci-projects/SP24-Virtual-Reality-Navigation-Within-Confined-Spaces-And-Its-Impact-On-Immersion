using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public GameObject teleportTarget;
    public float maxDistance = 3333f; // Maximum distance allowed for interaction

    private void OnMouseDown()
    {
        if (teleportTarget != null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null)
            {
                // Calculate the distance between the player and the lever
                float distanceToLever = Vector3.Distance(player.transform.position, transform.position);

                // Check if the player is within the maximum distance
                if (distanceToLever <= maxDistance)
                {
                    // Get the direction from the teleport target to the player
                    Vector3 direction = player.transform.position - teleportTarget.transform.position;

                    // Calculate the teleport position based on the direction, maintaining the distance
                    Vector3 teleportPosition = teleportTarget.transform.position - direction;

                    // Calculate the distance between the player and the teleporter
                    float distanceToTeleporter = Vector3.Distance(player.transform.position, transform.position);

                    // Calculate the distance between the player and the teleport target
                    float distanceToTarget = Vector3.Distance(player.transform.position, teleportTarget.transform.position);

                    // Calculate the proportion of the distance between the player and the teleporter relative to the distance between the player and the target
                    float proportion = distanceToTeleporter / distanceToTarget;

                    // Apply the proportion to the direction vector to adjust the teleport position
                    teleportPosition += direction * proportion;

                    // Preserve the player's current Y position
                    float playerHeight = player.transform.position.y;

                    // Set the preserved Y position
                    teleportPosition.y = playerHeight;

                    // Teleport the player to the calculated position
                    player.transform.position = teleportPosition;

                    // Rotate the player 180 degrees
                    player.transform.Rotate(Vector3.up, 180f);
                }
            }
        }
    }
}
