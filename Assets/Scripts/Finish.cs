using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public delegate void ClickAction();
    public static event ClickAction OnFinishClicked;

    private void OnMouseDown()
    {
        OnFinishClicked?.Invoke();
    }
    
}
