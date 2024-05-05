using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class ButtonPressManager : MonoBehaviour
{
    public GameObject podium; // Reference to the podium GameObject
    public static int buttonPressCount = 0; // Counter for the number of button presses
    public Material goldMaterial;
    // This function is called automatically when the GameObject is clicked
    public Material gold2;
    public GameObject buttonMiddle;
    private InputAction buttonAction;
    private float lastTriggerTime = 0f;
    private float triggerCooldown = 0.5f;
    public Transform controllerTransform;
    public GameObject button;

    private void Start()
    {
        // Enable the lever action
        buttonAction = new InputAction(binding: "<XRController>/trigger", interactions: "tap");
        buttonAction.Enable();
        buttonAction.performed += OnButtonAction;
    }

    private void OnDisable()
    {
        // Disable the lever action when the script is disabled
        buttonAction.Disable();
    }

    private void OnButtonAction(InputAction.CallbackContext context)
    {
        if (Time.time - lastTriggerTime >= triggerCooldown)
        {
            lastTriggerTime = Time.time;
            // Ensure the action only happens once per press
            // Set the flag to prevent further action until the trigger is released
            // Handle the lever action
            RaycastHit hit;
            if (Physics.Raycast(controllerTransform.position, controllerTransform.forward, out hit, Mathf.Infinity))
            {
                if (hit.transform.gameObject == button)
                {
                    Debug.Log("Pointing at button");
                    ChangeButton();
                }
            }
        }
    }

    private void ChangeButton()
    {
        if (buttonPressCount < 1)
        {
            buttonPressCount++;
            podium.SetActive(true);
            GetComponent<Renderer>().material = goldMaterial;
            buttonMiddle.GetComponent<Renderer>().material = gold2;
        }
    }
} 