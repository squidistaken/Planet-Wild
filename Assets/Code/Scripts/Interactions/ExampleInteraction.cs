using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleInteraction : MonoBehaviour, IInteractable
{
	GameManager gameManager;

	string animalName = "Example";

	public void Interact()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gameManager.LoadDrawingUI(animalName);
	}
}
