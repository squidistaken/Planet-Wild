using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WolfInteraction : MonoBehaviour, IInteractable
{
	GameManager gameManager;

	string animalName = "Wolf";

	public void Interact()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gameManager.LoadDrawing(animalName);
	}
}
