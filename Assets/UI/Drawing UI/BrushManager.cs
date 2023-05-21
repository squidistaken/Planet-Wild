using System.Collections;
using System.IO;
using UnityEngine;

// Credit: Marcus
public class BrushManager : MonoBehaviour
{
	BrushInitialize activeBrush;

	public GameObject brushPrefab;
	public Camera drawingCamera;
	private GameObject[] clonedBrushes;

	public Camera renderCamera;
	public RenderTexture RTexture;

	private int layerCount;

	void Update()
	{
		// Casting a ray to the plane (one with brush manager)
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
		clonedBrushes = GameObject.FindGameObjectsWithTag("Drawing");

		foreach (GameObject brush in clonedBrushes)
		{
			Destroy(brush);
			layerCount = 0;
		}
	}

	public string animalName = "InsertName";

	public void Save()
	{
		StartCoroutine(SaveDrawing(animalName));
	}

	// TODO: Save images in their own dedicated folder (or downloads?), and also make sure they can be referenced...
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
		fileName = "/" + fileName + ".png";

		// Creating the folder if it doesn't already exist.
		if (!Directory.Exists(filepath))
		{
			Directory.CreateDirectory(Application.dataPath + "/MyDrawings");
			File.WriteAllBytes(filepath + fileName, byteArray);
		}
		else
		{
			File.WriteAllBytes(filepath + fileName, byteArray);
		}
		
	}

	private GameManager gameManager;

	public void UnloadDrawingUI()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gameManager.UnloadDrawing();
	}
}
