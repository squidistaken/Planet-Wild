using System.Collections;
using System.Diagnostics;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
	private GameManager gameManager;

	// Initialisation
	private void OnEnable()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
	}

	#region General
	private void Update()
	{
		if (!SceneManager.GetSceneByName("DrawingScene").isLoaded || !SceneManager.GetSceneByName("MainMenuScene").isLoaded)
		{
			if (Input.GetButtonDown("Jump"))
			{
				gameManager.UnloadUI(gameObject.scene.name);
			}
		}
	}

	public void GoBackToMenu()
	{
		GameManager.LoadUI("JournalScene", gameObject.scene.ToString());
	}

	public void CloseGame()
	{
		#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
	}

	#endregion

	#region Main Menu

	public void PlayGame()
	{
		GameManager.LoadScene("TutorialScene", false);

		GameManager.LoadScene("ManagerScene", true);
		GameManager.LoadScene("POVScene", true);
		GameManager.UnloadScene("MainMenuScene");
	}

	#endregion

	#region Journal Menu

	public void OpenDrawings()
	{
		string filepath = Application.dataPath + "/MyDrawings";

		if (!Directory.Exists(filepath))
		{
			Directory.CreateDirectory(filepath);
		}
		Process.Start(filepath);
	}

	public void ResumeGame()
	{
		gameManager.UnloadUI("JournalScene");
	}

	public void LoadOption(string option)
	{
		GameManager.LoadUI(option, "JournalScene");
	}

	#endregion

	#region Region Menu

	public void LoadRegion(string regionName)
	{
		GameManager.LoadScene(regionName, false);

		GameManager.LoadScene("ManagerScene", true);
		GameManager.LoadScene("POVScene", true);
		GameManager.UnloadScene("RegionSelectScene");
	}

	#endregion
}
