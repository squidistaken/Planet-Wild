using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealInteraction : MonoBehaviour, IInteractable
{
	GameManager gameManager;

	string animalName = "Seal";

	public void Interact()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gameManager.LoadDrawingUI(animalName);
	}
}
