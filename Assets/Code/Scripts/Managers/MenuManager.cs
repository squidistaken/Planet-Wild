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

	// in reflection we could've just thrown the bool here lmao
	private void Update()
	{
		if (!SceneManager.GetSceneByName("MainMenuScene").isLoaded) 
		{
			// You can't do a logical or statement for multiple scene loads???
			if (!SceneManager.GetSceneByName("DrawingScene").isLoaded)
			{
				if (Input.GetButtonDown("Jump"))
				{
					FindObjectOfType<AudioManager>().PlayAudio("CloseJournal");
					gameManager.UnloadUI(gameObject.scene.name);
				}
			}
		}
	}

	public void GoBackToMenu()
	{
		FindObjectOfType<AudioManager>().PlayAudio("CloseJournal");
		GameManager.LoadUI("JournalScene", gameObject.scene.ToString());
	}

	public void CloseGame()
	{
		FindObjectOfType<AudioManager>().PlayAudio("OptionSelect");
		#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
	}

	#endregion

	#region Main Menu

	public void PlayGame()
	{
		FindObjectOfType<AudioManager>().PlayAudio("OpenJournal");
		GameManager.LoadScene("SlidesScene", false);
	}

	#endregion

	#region Journal Menu

	public void OpenDrawings()
	{
		string filepath = Application.dataPath + "/MyDrawings";
		FindObjectOfType<AudioManager>().PlayAudio("OptionSelect");
		if (!Directory.Exists(filepath))
		{
			Directory.CreateDirectory(filepath);
		}
		Process.Start(filepath);
	}

	public void ResumeGame()
	{
		FindObjectOfType<AudioManager>().PlayAudio("CloseJournal");
		gameManager.UnloadUI("JournalScene");
	}

	public void LoadOption(string option)
	{
		FindObjectOfType<AudioManager>().PlayAudio("OpenJournal");
		GameManager.LoadUI(option, "JournalScene");
	}

	#endregion

	#region Region Menu

	public void LoadRegion(string regionName)
	{
		FindObjectOfType<AudioManager>().PlayAudio("OptionSelect");
		GameManager.LoadScene(regionName, false);
		GameManager.LoadScene("ManagerScene", true);
		GameManager.LoadScene("POVScene", true);
		GameManager.UnloadScene("RegionSelectScene");
	}

	#endregion
}
