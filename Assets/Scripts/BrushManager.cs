using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrushManager : MonoBehaviour
{
	public GameObject brushPrefab;
	BrushInitialize activeBrush;
	public Camera drawingCamera;

	void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			GameObject newLine = Instantiate(brushPrefab, transform);
			activeBrush = newLine.GetComponent<BrushInitialize>();
		}

		if (Input.GetMouseButtonUp(0))
		{
			activeBrush = null;
		}

		if (activeBrush != null)
		{
			Vector2 mousePos = drawingCamera.ScreenToWorldPoint(Input.mousePosition);
			activeBrush.UpdateLine(mousePos);
		}
	}
}
