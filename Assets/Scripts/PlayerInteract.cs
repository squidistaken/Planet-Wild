using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Source: https://youtu.be/K06lVKiY-sY

// Inheritable interface.
interface IInteractable
{
    public void Interact();
}

public class PlayerInteract : MonoBehaviour
{
    public Transform InteractorSource;
    // Range to interact from
    public float InteractRange = 10;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Ray = Infinite light starting at origin and going in some direction.
            // Ray is created from interactor source position and is forward.
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);

            // If the raycast hits an object
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                // Collision attempt
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    // Interact method
                    interactObj.Interact();
                }
            }
        }
    }
}
