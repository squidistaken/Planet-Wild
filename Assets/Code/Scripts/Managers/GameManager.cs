using System.Collections;
using System.Collections.Generic;
using System.Xml.XPath;
using UnityEngine;
using UnityEngine.SceneManagement;

// Credit: Marcus
public class GameManager : MonoBehaviour
{
	private GameObject Player;
	public string animalName;

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


	public static Texture2D screenshotTexture;

	public void LoadDrawing(string selectedAnimal)
	{
		StartCoroutine(TakeScreenshot());
		animalName = selectedAnimal;
		Player.GetComponent<PlayerControls>().DisablePlayerControls();
		UnloadScene("POVScene");
		LoadScene("DrawingScene", true);
	}

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
