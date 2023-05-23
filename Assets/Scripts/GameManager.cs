using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

// Credit: Marcus

public class GameManager : MonoBehaviour
{
	private GameObject Player;
	public static string animalName;

	private void Start()
	{
		LoadScene("POVScene", true);
		Player = GameObject.Find("Player");
	}

	#region Scene Manager

	public void LoadScene(string scene, bool isAdditive)
	{
		switch (isAdditive)
		{
			case true:
				SceneManager.LoadScene(scene, LoadSceneMode.Additive);
				break;
			case false:
				SceneManager.LoadScene(scene, LoadSceneMode.Single);
				break;
		}
	}

	public void UnloadScene(string scene)
	{
		SceneManager.UnloadSceneAsync(scene);
	}

	#endregion

	#region Drawing Manager

	public void LoadDrawing(string selectedAnimal)
	{
		animalName = selectedAnimal;
		Player.GetComponent<PlayerControls>().DisablePlayerControls();
		UnloadScene("POVScene");
		ScreenCapture.CaptureScreenshot(Application.dataPath + "/TemporaryScreenshot.png");
		LoadScene("DrawingScene", true);
	}

	private BrushManager brushManager;
	public void UnloadDrawing()
	{
		brushManager = GameObject.Find("BrushManager").GetComponent<BrushManager>();
		Player.GetComponent<PlayerControls>().EnablePlayerControls();
		Player.GetComponentInChildren<PlayerInteract>().IsInteracting = false;

		brushManager.ClearLines();
		UnloadScene("DrawingScene");
		LoadScene("POVScene", true);
	}

	#endregion
}
