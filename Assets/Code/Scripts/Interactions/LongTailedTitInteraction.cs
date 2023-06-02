using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongTailedTitInteraction : MonoBehaviour, IInteractable
{
	GameManager gameManager;

	string animalName = "LongTailedTit";

	public void Interact()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gameManager.LoadDrawingUI(animalName);
	}
}
