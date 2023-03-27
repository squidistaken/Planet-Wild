using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableInteract : MonoBehaviour, IInteractable
{
	public void Interact()
	{
		Debug.Log("Interaction confirmed.");
	}
}
