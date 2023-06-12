using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyInteraction : MonoBehaviour, IInteractable
{
	GameManager gameManager;

	string animalName = "Bunny";

	public void Interact()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gameManager.LoadDrawingUI(animalName);
	}
}
