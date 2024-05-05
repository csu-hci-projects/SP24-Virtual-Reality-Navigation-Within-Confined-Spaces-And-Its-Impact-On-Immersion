using UnityEngine;
using UnityEngine.InputSystem;

public class OpenDoor : MonoBehaviour
{
    public GameObject model1;
    public GameObject model2;
    public GameObject leverStick;
    public GameObject lever;
    public Transform controllerTransform;
    private bool isModel1Active = true;
    private Quaternion initialRotation = Quaternion.Euler(-30f, 0f, 0f);
    private Quaternion destRotation = Quaternion.Euler(30f, 0f, 0f);
    private InputAction leverAction;
    private float lastTriggerTime = 0f;
    private float triggerCooldown = 0.5f;

    private void Start()
    {
        // Enable the lever action
        leverAction = new InputAction(binding: "<XRController>/trigger", interactions: "tap");
        leverAction.Enable();
        leverAction.performed += OnLeverAction;
    }

    private void OnDisable()
    {
        // Disable the lever action when the script is disabled
        leverAction.Disable();
    }

    private void OnLeverAction(InputAction.CallbackContext context)
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
                if (hit.transform.gameObject == lever)
                {
                    Debug.Log("Pointing at lever");

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
            }
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