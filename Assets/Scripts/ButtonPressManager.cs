using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressManager : MonoBehaviour
{
    public GameObject podium; // Reference to the podium GameObject
    public static int buttonPressCount = 0; // Counter for the number of button presses

    // This function is called automatically when the GameObject is clicked
    private void OnMouseDown()
    {
        // Increment the button press count
        buttonPressCount++;

        // Check if the button press count has reached four
        if (buttonPressCount >= 4)
        {
            // Activate the podium to make it appear
            podium.SetActive(true);
        }
    }
}