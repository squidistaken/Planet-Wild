using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum crosshairType
{
	normal,
	interact
}

public class POVManager : MonoBehaviour
{
	Image crosshair;
	
	[SerializeField]
	Sprite crosshairNormal;
	[SerializeField]
	Sprite crosshairInteract;

	TMP_Text checklist;

	Scene activeScene;


	private void OnEnable()
	{
		GameManager.OnFound += CompleteTask;
	}

	private void Awake()
	{
		crosshair = GameObject.Find("Crosshair").GetComponent<Image>();

		activeScene = SceneManager.GetActiveScene();

		switch (activeScene.name)
		{
			case "ForestScene":
				GameObject.Find("HeatherTasks").SetActive(false);
				GameObject.Find("CoastTasks").SetActive(false);
				break;
			case "HeatherScene":
				GameObject.Find("ForestTasks").SetActive(false);
				GameObject.Find("CoastTasks").SetActive(false);
				break;
			case "CoastScene":
				GameObject.Find("ForestTasks").SetActive(false);
				GameObject.Find("HeatherTasks").SetActive(false);
				break;
			case "TutorialScene":
				GameObject.Find("Tasks").SetActive(false);
				break;
		}
	}

	private void OnDisable()
	{
		GameManager.OnFound -= CompleteTask;
	}

	public void EditCrosshair(crosshairType type)
	{
		switch (type)
		{
			case crosshairType.normal:
				crosshair.sprite = crosshairNormal;
				break;
			case crosshairType.interact:
				crosshair.sprite = crosshairInteract;
				break;
			default:
				crosshair.sprite = crosshairNormal;
				break;
		}
	}

	void CompleteTask(string animalName)
	{
		checklist = GameObject.Find(animalName).GetComponent<TMP_Text>();

		Debug.Log(checklist);

		checklist.fontStyle = FontStyles.Strikethrough;

		checklist.ForceMeshUpdate(true);
	}
}

