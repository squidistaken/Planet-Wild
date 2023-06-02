using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoeDeerInteraction : MonoBehaviour, IInteractable
{
	GameManager gameManager;

	string animalName = "RoeDeer";

	public void Interact()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gameManager.LoadDrawingUI(animalName);
	}
}
