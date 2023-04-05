using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using UnityEngine;
using static UnityEngine.UI.Image;

public class JournalPaintable : MonoBehaviour
{
	public GameObject Brush;
	public float BrushSize = 0.1f;
	public Camera Camera;
	public RenderTexture RTexture;
	private bool resetDrawing;

	// TODO: Delete the cloned objects when saving image or closing journal.

	private void Update()
	{
		if (Input.GetMouseButton(0))
		{
			var Ray = Camera.ScreenPointToRay(Input.mousePosition); //cast a ray to the plane
			RaycastHit hit;
			if (Physics.Raycast(Ray, out hit))
			{
				var go = Instantiate(Brush, hit.point + Vector3.forward * 0.1f, Quaternion.identity, transform); // Instantiate object
				go.transform.localScale = Vector3.one * BrushSize; // Creating objects
			}
		}

	}

	public void Save()
	{
		StartCoroutine(CoSave());
	}	

	private IEnumerator CoSave()
	{
		yield return new WaitForEndOfFrame(); // Waiting until end of frame to render
		RenderTexture.active = RTexture; // set Active texture to RTexture

		// convert rendering texture to texture2D
		var texture2D = new Texture2D(RTexture.width, RTexture.height);
		texture2D.ReadPixels(new Rect(0, 0, RTexture.width, RTexture.height), 0, 0);
		texture2D.Apply();

		//write data to file
		var data = texture2D.EncodeToPNG();
		File.WriteAllBytes(Application.dataPath + "/savedImage.png", data);

		resetDrawing = true;
	}

}
