using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

// Credit: Marcus
public class BrushManager : MonoBehaviour
{
	BrushInitialize activeBrush;

	[SerializeField]
	private GameObject brushPrefab;

	[SerializeField]
	private Camera drawingCamera;

	private GameObject[] clonedBrushes;

	[SerializeField]
	private Camera renderCamera;
	[SerializeField]
	private RenderTexture RTexture;

	[SerializeField]
	private int layerCount;

	[SerializeField]
	private string selectedAnimal;

	private GameManager gameManager;

	private void OnEnable()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		selectedAnimal = gameManager.animalName;
	}

	void Update()
	{
		var Ray = drawingCamera.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Input.GetMouseButtonDown(0))
		{
			if (Physics.Raycast(Ray, out hit))
			{
				GameObject newLine = Instantiate(brushPrefab, hit.transform);
				activeBrush = newLine.GetComponent<BrushInitialize>();

				layerCount++;
			}	
		}

		// or statement is for if the brushes leaves the plane
		if (Input.GetMouseButtonUp(0) || !Physics.Raycast(Ray, out hit))
		{
			activeBrush = null;
			
		}

		if (activeBrush != null)
		{
			Vector2 mousePos = drawingCamera.ScreenToWorldPoint(Input.mousePosition);
			activeBrush.UpdateLine(mousePos);
			activeBrush.lineRenderer.sortingOrder = layerCount;
		}
	}

	public void ClearLines()
	{
		FindObjectOfType<AudioManager>().PlayAudio("OptionSelect");
		clonedBrushes = GameObject.FindGameObjectsWithTag("Drawing");

		foreach (GameObject brush in clonedBrushes)
		{
			Destroy(brush);
			layerCount = 0;
		}
	}

	public void Save()
	{
		StartCoroutine(SaveDrawing(selectedAnimal));
	}

	private IEnumerator SaveDrawing(string fileName)
	{
		yield return new WaitForEndOfFrame(); // Waiting until end of frame to render

		RenderTexture.active = RTexture; // set Active texture to RTexture

		// convert rendering texture to texture2D
		var screenshotTexture = new Texture2D(RTexture.width, RTexture.height);
		Rect rect = new Rect(0, 0, RTexture.width, RTexture.height);

		screenshotTexture.ReadPixels(rect, 0, 0);
		screenshotTexture.Apply();

		//write data to file
		byte[] byteArray = screenshotTexture.EncodeToPNG();

		string filepath = Application.dataPath + "/MyDrawings";
		fileName = "/" + fileName + " Drawing" + DateTime.Now.ToString(" dd-MM-yyyy HH-mm-ss") + ".png";

		// Creating the folder if it doesn't already exist.
		if (!Directory.Exists(filepath))
		{
			Directory.CreateDirectory(Application.dataPath + "/MyDrawings");
		}

		File.WriteAllBytes(filepath + fileName, byteArray);

		UnloadDrawingUI();
	}

	public void UnloadDrawingUI()
	{
		FindObjectOfType<AudioManager>().PlayAudio("CloseJournal");
		gameManager.UnloadUI("DrawingScene");

		selectedAnimal = null;
	}
}
