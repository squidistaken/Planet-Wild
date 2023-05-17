using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Credit: Marcus

public class GameManager : MonoBehaviour
{
	private GameObject Player;

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

	public void LoadDrawing()
	{
		Player.GetComponent<PlayerControls>().DisablePlayerControls();
			

		UnloadScene("POVScene");
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
