using UnityEngine;

public class stopwatchStarter : MonoBehaviour
{
    public delegate void ClickAction();
    public static event ClickAction OnStarterClicked;


    private void OnMouseDown()
    {
        OnStarterClicked?.Invoke();
    }
}
