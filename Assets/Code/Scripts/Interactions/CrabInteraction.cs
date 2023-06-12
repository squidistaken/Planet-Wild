using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabInteraction : MonoBehaviour, IInteractable
{
	GameManager gameManager;

	string animalName = "Crab";

	public void Interact()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gameManager.LoadDrawingUI(animalName);
	}
}
