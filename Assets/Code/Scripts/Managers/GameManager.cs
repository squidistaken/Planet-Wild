using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;
using UnityEngine.SceneManagement;

// Credit: Marcus
public class GameManager : MonoBehaviour
{
	private GameObject Player;

	[System.NonSerialized]
	public string animalName;

	private static bool gameStarted = false;

	private void Awake()
	{
		if (!gameStarted)
		{
			LoadScene("MainMenuScene", true);
			gameStarted = true;
		}
	}

	// super temporary - just for debugging
	/* private void Update()
	{
		if (Input.GetKeyDown("1"))
		{
			LoadScene("ManagerScene", false);
			LoadScene("ForestScene", true);
			LoadScene("POVScene", true);
		}
		if (Input.GetKeyDown("2"))
		{
			LoadScene("ManagerScene", false);
			LoadScene("HeatherScene", true);
			LoadScene("POVScene", true);
		}
		if (Input.GetKeyDown("3"))
		{
			LoadScene("ManagerScene", false);
			LoadScene("CoastScene", true);
			LoadScene("POVScene", true);
		}
	}*/

	#region Scene Manager

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
		yield return new WaitForEndOfFrame();

		screenshotTexture = ScreenCapture.CaptureScreenshotAsTexture();

		// All the following is necessary due to a Unity bug when working in Linear color space
		// See forum post: https://answers.unity.com/questions/1655518/screencapturecapturescreenshotastexture-is-making.html

		Texture2D newScreenshotTexture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
		newScreenshotTexture.SetPixels(screenshotTexture.GetPixels());
		newScreenshotTexture.Apply();

		screenshotTexture = newScreenshotTexture;
	}

	#region UI Manager

	public void LoadDrawingUI(string selectedAnimal)
	{
		Player = GameObject.Find("Player");
		animalName = selectedAnimal;
		UnloadScene("POVScene");
		Player.GetComponent<PlayerControls>().DisablePlayerControls();
		StartCoroutine(TakeScreenshot());
		LoadScene("DrawingScene", true);
	}

	private BrushManager brushManager;

	public static void LoadUI(string newMenu, string oldMenu)
	{
		GameManager.LoadScene(newMenu, true);
		GameManager.UnloadScene(oldMenu);
	}

	public void UnloadUI(string UI)
	{
		// move finding gameobject to own method?
		Player = GameObject.Find("Player");
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
		UnloadScene(UI);

		LoadScene("POVScene", true);
	}

	#endregion
}
