using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HedgehogInteraction : MonoBehaviour, IInteractable
{
	GameManager gameManager;

	string animalName = "Hedgehog";

	public void Interact()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gameManager.LoadDrawingUI(animalName);
	}
}
