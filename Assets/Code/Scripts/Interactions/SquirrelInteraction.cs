using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelInteraction : MonoBehaviour, IInteractable
{
	GameManager gameManager;

	string animalName = "Squirrel";

	public void Interact()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gameManager.LoadDrawingUI(animalName);
	}
}
