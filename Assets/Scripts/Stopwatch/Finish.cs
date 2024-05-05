using UnityEngine;
using UnityEngine.InputSystem;

public class InteractableObject : MonoBehaviour
{
    public delegate void ClickAction();
    public static event ClickAction OnFinishClicked;
    private InputAction triggerAction;
    public float maxDistance = 3f;

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
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distanceToObject = Vector3.Distance(player.transform.position, transform.position);

        if (distanceToObject <= maxDistance)
        {
            OnFinishClicked?.Invoke();
        }
    }
}
