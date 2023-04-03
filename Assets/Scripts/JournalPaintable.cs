using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JournalPaintable : MonoBehaviour
{
	public GameObject Brush;
	public float BrushSize = 0.1f;
	public Camera Camera;
	private bool _isInteracting;

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
				var go = Instantiate(Brush, hit.point + Vector3.forward * 0.1f, Quaternion.Euler(-90, 0, 0), transform);
				
				// TODO: Set Z angle to be zero always.

				go.transform.localScale = Vector3.one * BrushSize;
			}
		}
	}
}
