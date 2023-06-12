using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogInteraction : MonoBehaviour, IInteractable
{
	GameManager gameManager;

	string animalName = "Dog";

	public void Interact()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gameManager.LoadDrawingUI(animalName);
	}
}
