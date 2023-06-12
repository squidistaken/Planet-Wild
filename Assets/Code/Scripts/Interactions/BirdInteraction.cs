using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdInteraction : MonoBehaviour, IInteractable
{
	GameManager gameManager;

	string animalName = "Bird";

	public void Interact()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gameManager.LoadDrawingUI(animalName);
	}
}
