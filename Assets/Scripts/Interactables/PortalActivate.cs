using UnityEngine;

public class PortalActivate : MonoBehaviour
{
    public GameObject portal;
    public GameObject portal2;
    public GameObject leverStick;
    private bool isEmptyPortal = true;
    private Quaternion initialRotation = Quaternion.Euler(-30f, 0f, 0f);
    private Quaternion finalRotation = Quaternion.Euler(30f, 0f, 0f);
    private float maxDistance = 3333f; // Maximum distance allowed for interaction
    private void OnMouseDown() 
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Calculate the distance between the player and the lever
            float distanceToLever = Vector3.Distance(player.transform.position, transform.position);

            // Check if the player is within the maximum distance
            if (distanceToLever <= maxDistance) 
            {
                if (isEmptyPortal) 
                {
                    portal.SetActive(true);
                    portal2.SetActive(true);
                    isEmptyPortal = false;
                    RotateLever(finalRotation);
                }
                else 
                {
                    portal.SetActive(false);
                    portal2.SetActive(false);
                    isEmptyPortal = true;
                    RotateLever(initialRotation);
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
