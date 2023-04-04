using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JournalPaintable : MonoBehaviour
{
	public GameObject Brush;
	public float BrushSize = 0.1f;
	public Camera Camera;
	public RenderTexture RTexture;
	JournalClose _journalClose;

	private void Start()
	{
		_journalClose = GameObject.Find("JournalCanvas").GetComponent<JournalClose>();
	}

	private void Update()
	{
		if (Input.GetMouseButton(0))
		{
			//cast a ray to the plane
			var Ray = Camera.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(Ray, out hit))
			{
				//instanciate a brush
				var go = Instantiate(Brush, hit.point + Vector3.forward * 0.1f, Quaternion.identity, transform);
				go.transform.localScale = Vector3.one * BrushSize;
			}
		}
	}

	public void Save()
	{
		StartCoroutine(CoSave());
	}	

	private IEnumerator CoSave()
	{
		// Waiting until end of frame to render
		yield return new WaitForEndOfFrame();
		// set active texture
		RenderTexture.active = RTexture;

		//convert rendering texture to texture2D
		var texture2D = new Texture2D(RTexture.width, RTexture.height);
		texture2D.ReadPixels(new Rect(0, 0, RTexture.width, RTexture.height), 0, 0);
		texture2D.Apply();

		//write data to file
		var data = texture2D.EncodeToPNG();
		File.WriteAllBytes(Application.dataPath + "/savedImage.png", data);

		// _journalClose.closeJournal();
	}

}
