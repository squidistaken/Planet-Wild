using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// Credit: Marcus
public class GameManager : MonoBehaviour
{
	private GameObject Player;
	// there is probably a better way to do this but ehhhhhh, let's be lazy again
	private GameObject POVManager;

	[System.NonSerialized]
	public string animalName;

	#region Scene Manager
	
	private static bool gameStarted = false;
	private void Awake()
	{		
		if (!gameStarted)
		{
			LoadScene("MainMenuScene", true);
			gameStarted = true;
		}
	}

	public static void LoadScene(string scene, bool isAdditive)
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

	public static void UnloadScene(string scene)
	{
		SceneManager.UnloadSceneAsync(scene);
	}

	#endregion
	
	[System.NonSerialized]
	public static Texture2D screenshotTexture;
	IEnumerator TakeScreenshot()
	{
		yield return null;
		yield return new WaitForEndOfFrame();

		screenshotTexture = ScreenCapture.CaptureScreenshotAsTexture();

		// All the following is necessary due to a Unity bug when working in Linear color space
		// See forum post: https://answers.unity.com/questions/1655518/screencapturecapturescreenshotastexture-is-making.html

		Texture2D newScreenshotTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		newScreenshotTexture.SetPixels(screenshotTexture.GetPixels());
		newScreenshotTexture.Apply();

		screenshotTexture = newScreenshotTexture;

		yield return null;

		LoadScene("DrawingScene", true);
	}

	#region UI Manager

	public delegate void AnimalTaskComplete(string animalName);

	public static event AnimalTaskComplete OnFound;

	public void LoadDrawingUI(string selectedAnimal)
	{
		animalName = selectedAnimal;
		// Invoke Task completion event

		if (OnFound != null) OnFound(animalName);

		Player.GetComponent<PlayerControls>().DisablePlayerControls();
		POVManager.SetActive(false);

		FindObjectOfType<AudioManager>().PlayAudio("OpenJournal");
		StartCoroutine(TakeScreenshot());
		
	}

	private BrushManager brushManager;

	public static void LoadUI(string newMenu, string oldMenu)
	{
		GameManager.LoadScene(newMenu, true);
		GameManager.UnloadScene(oldMenu);
	}

	public void UnloadUI(string UI)
	{
		POVManager.SetActive(true);
		
		Player.GetComponent<PlayerControls>().EnablePlayerControls();

		switch (UI)
		{
			case "DrawingScene":
				brushManager = GameObject.Find("BrushManager").GetComponent<BrushManager>();
				brushManager.ClearLines();
				Player.GetComponentInChildren<PlayerInteract>().IsInteracting = false;
				break;
			default:
				UnloadScene(UI);
				break;
		}
		uiLoaded = false;
		UnloadScene(UI);
	}

	bool uiLoaded;

	private void Update()
	{
		if (!SceneManager.GetSceneByName("MainMenuScene").isLoaded)
		{

			if (!SceneManager.GetSceneByName("DrawingScene").isLoaded) 
			{
				// pulling up journal
				if (Input.GetButtonDown("Jump"))
				{
					if (!uiLoaded)
					{
						FindObjectOfType<AudioManager>().PlayAudio("OpenJournal");
						Player.GetComponent<PlayerControls>().DisablePlayerControls();

						POVManager.SetActive(false);
						GameManager.LoadScene("JournalScene", true);

						uiLoaded = true;
					}
				}
			}
		}

		if (POVManager == null)
		{
			POVManager = GameObject.Find("POVManager");
		}
		if (Player == null)
		{
			Player = GameObject.Find("Player");
		}
	}

	#endregion
}
