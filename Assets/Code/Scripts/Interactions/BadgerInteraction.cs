using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgerInteraction : MonoBehaviour, IInteractable
{
	GameManager gameManager;

	string animalName = "Badger";

	public void Interact()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gameManager.LoadDrawingUI(animalName);
	}
}
