using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Credit: Marcus
// Sourced and modified from: https://youtu.be/K06lVKiY-sY

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

    public GameObject journal;
    public GameObject Crossair;

    public bool IsInteracting = false;
    
    //Credit: Stan
    public GameObject ItemPosition;
    public GameObject PickedUpItem = null;
    public bool IsHoldingItem = false;
    public GameObject ItemCollection;
    public Transform Camera;

    public float dropForwardForce = 1f;
    public float dropUpForce = 1f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !IsInteracting)
        {
            // Ray = Infinite light starting at origin and going in some direction.
            // Ray is created from interactor source position and is forward.
            Ray r = new Ray(InteractorSource.position, InteractorSource.forward);
            
            if (IsHoldingItem)
            {
                PickedUpItem.GetComponent<Rigidbody>().isKinematic = false;
                PickedUpItem.GetComponent<Rigidbody>().AddForce(Camera.forward * dropForwardForce, ForceMode.Impulse);
                PickedUpItem.GetComponent<Rigidbody>().AddForce(Camera.up * dropUpForce, ForceMode.Impulse);
                IsHoldingItem = false;
                PickedUpItem.transform.parent = ItemCollection.transform;
            }

            // If the raycast hits an object
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.tag == "Item" && !IsHoldingItem)
                {
                    hitInfo.transform.parent = ItemPosition.transform;
                    hitInfo.transform.localPosition = Vector3.zero;
                    hitInfo.rigidbody.isKinematic = true;
                    PickedUpItem = hitInfo.transform.gameObject;
                    IsHoldingItem = true;
                }
 
                //Credit: Marcus               
                // Collision attempt
                if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    // Interact method
                    interactObj.Interact();

                    // Credit: Stan
                    // TODO: Make this indepedent of this script.
                    Crossair.SetActive(false); //hides cursor
                    OpenJournal(); //opens journal
                    DisablePlayerControls(); //disables the players movement and 
                    IsInteracting = true;
                }
            }
        }
    }

    

    public void OpenJournal()
    {
        journal.SetActive(true); //open journal
        Cursor.visible = true; //show cursor
        Cursor.lockState = CursorLockMode.None;
    }

    public GameObject Player;

    public void DisablePlayerControls()
    {
        this.gameObject.GetComponent<MouseLook>().enabled = false;
        Player.GetComponent<PlayerMovement>().enabled = false;
    }
}
