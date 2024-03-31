using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSquare : MonoBehaviour
{

    public Transform teleportTarget;

    // Start is called before the first frame update
    void Start()
    {
        Renderer render = GetComponent<Renderer>();
        render.material.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 teleportPosition = teleportTarget.position + Vector3.up * 1.0f;
            other.transform.position = teleportPosition;
        }
    }
}
