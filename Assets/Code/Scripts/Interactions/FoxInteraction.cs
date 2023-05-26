using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoxInteraction : MonoBehaviour, IInteractable
{
	GameManager gameManager;

	string animalName = "Fox";

	public void Interact()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gameManager.LoadDrawing(animalName);
	}
}
