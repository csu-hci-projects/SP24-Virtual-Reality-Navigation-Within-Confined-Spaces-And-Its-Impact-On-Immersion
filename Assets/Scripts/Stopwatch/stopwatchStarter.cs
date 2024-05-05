using UnityEngine;
using UnityEngine.InputSystem;

public class stopwatchStarter : MonoBehaviour
{
    public delegate void ClickAction();
    public static event ClickAction OnStarterClicked;

    private InputAction triggerAction;

    private void Start()
    {
        triggerAction = new InputAction(binding: "<XRController>/trigger", interactions: "tap");
        triggerAction.Enable();
        triggerAction.performed += OnTriggerAction;
    }

    private void OnDisable()
    {
        triggerAction.Disable();
    }

    private void OnTriggerAction(InputAction.CallbackContext context)
    {
        OnStarterClicked?.Invoke();
    }
}
