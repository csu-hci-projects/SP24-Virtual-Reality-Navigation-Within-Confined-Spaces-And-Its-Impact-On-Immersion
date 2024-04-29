using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject model1; // Reference to the first model
    public GameObject model2; // Reference to the second model
    public GameObject leverStick;
    private bool isModel1Active = true; // Flag to track which model is currently active
    private Quaternion initialRotation = Quaternion.Euler(-30f, 0f, 0f);
    private Quaternion destRotation = Quaternion.Euler(30f, 0f, 0f);
    // This function is called when the lever is clicked
    private void OnMouseDown()
    {
        // Toggle between the two models
        if (isModel1Active)
        {
            model1.SetActive(false);
            model2.SetActive(true);
            isModel1Active = false;
            RotateLever(destRotation);
        }
        else
        {
            model1.SetActive(true);
            model2.SetActive(false);
            isModel1Active = true;
            RotateLever(initialRotation);
        }
    }

    private void RotateLever(Quaternion targetRotation)
    {
        Quaternion currentRotation = leverStick.transform.rotation;
        Quaternion newRotation = Quaternion.Euler(targetRotation.eulerAngles.x, currentRotation.eulerAngles.y,
                                                  currentRotation.eulerAngles.z);
        leverStick.transform.rotation = newRotation;
    }
}
