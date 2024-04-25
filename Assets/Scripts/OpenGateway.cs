using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGateway : MonoBehaviour
{
    // Reference to the closed model of the gateway
    public GameObject closedModel;

    // Reference to the open model of the gateway
    public GameObject openModel;

    // Boolean to track if the gateway is open
    private bool isOpen = false;

    // OnTriggerEnter is called when the Collider other enters the trigger
    void OnTriggerEnter(Collider other)
    {
        // Check if the player interacts with the gateway
        if (other.CompareTag("Player"))
        {
            // Toggle the gateway's state
            isOpen = !isOpen;

            // Update the visual appearance of the gateway
            UpdateVisuals();
        }
    }

    // Method to update the visual appearance of the gateway
    private void UpdateVisuals()
    {
        // Activate/deactivate the appropriate models based on the gateway's state
        closedModel.SetActive(!isOpen);
        openModel.SetActive(isOpen);
    }
}
