using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressManager : MonoBehaviour
{
    public GameObject podium; // Reference to the podium GameObject
    public static int buttonPressCount = 0; // Counter for the number of button presses
    public Material goldMaterial;
    // This function is called automatically when the GameObject is clicked
    public Material gold2;
    public GameObject loser;
    private void OnMouseDown()
    {
        // Increment the button press count
        buttonPressCount++;

        // Check if the button press count has reached four
        if (buttonPressCount >= 1)
        {
            // Activate the podium to make it appear
            podium.SetActive(true);
            GetComponent<Renderer>().material = goldMaterial;
            loser.GetComponent<Renderer>().material = gold2;
        }
    }
} 