using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullInteraction : MonoBehaviour, IInteractable
{
	GameManager gameManager;

	string animalName = "Seagull";

	public void Interact()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gameManager.LoadDrawingUI(animalName);
	}
}
