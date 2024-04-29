using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject model1; // Reference to the first model
    public GameObject model2; // Reference to the second model
    private bool isModel1Active = true; // Flag to track which model is currently active

    // This function is called when the lever is clicked
    private void OnMouseDown()
    {
        // Toggle between the two models
        if (isModel1Active)
        {
            model1.SetActive(false);
            model2.SetActive(true);
            isModel1Active = false;
        }
        else
        {
            model1.SetActive(true);
            model2.SetActive(false);
            isModel1Active = true;
        }
    }
}
