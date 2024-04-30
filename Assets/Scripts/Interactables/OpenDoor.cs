using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject model1;
    public GameObject model2;
    public GameObject leverStick;
    private bool isModel1Active = true;
    private Quaternion initialRotation = Quaternion.Euler(-30f, 0f, 0f);
    private Quaternion destRotation = Quaternion.Euler(30f, 0f, 0f);
    private float maxDistance = 3f;
    private void OnMouseDown()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            float distanceToLever = Vector3.Distance(player.transform.position, transform.position);

            if (distanceToLever <= maxDistance) 
            {
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

    private void RotateLever(Quaternion targetRotation)
    {
        Quaternion currentRotation = leverStick.transform.rotation;
        Quaternion newRotation = Quaternion.Euler(targetRotation.eulerAngles.x, currentRotation.eulerAngles.y,
                                                  currentRotation.eulerAngles.z);
        leverStick.transform.rotation = newRotation;
    }
}
