using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Stopwatch stopwatch; // Reference to the Stopwatch script

    // Update is called once per frame
    void Update()
    {
        // Check for mouse button click
        if (Input.GetMouseButtonDown(0)) // 0 corresponds to the left mouse button
        {
            // Cast a ray from the mouse position into the scene
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits this object
            if (Physics.Raycast(ray, out hit) && hit.collider.gameObject == gameObject)
            {
                // Check if the stopwatch reference is assigned
                if (stopwatch != null)
                {
                    // Stop the stopwatch
                    stopwatch.StopStopwatch();
                }
            }
        }
    }
}
