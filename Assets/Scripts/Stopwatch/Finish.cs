using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public delegate void ClickAction();
    public static event ClickAction OnFinishClicked;
    private float maxDistance = 3f;

    private void OnMouseDown()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distanceToObject = Vector3.Distance(player.transform.position, transform.position);

        if (distanceToObject <= maxDistance)
        {
            OnFinishClicked?.Invoke();
        }
        
    }
    
}
