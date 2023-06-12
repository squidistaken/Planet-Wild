using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterflyInteraction : MonoBehaviour, IInteractable
{
	GameManager gameManager;

	string animalName = "Butterfly";

	public void Interact()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gameManager.LoadDrawingUI(animalName);
	}
}
