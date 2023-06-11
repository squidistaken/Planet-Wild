using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// Credit: Marcus
public class BrushInitialize : MonoBehaviour
{
    public LineRenderer lineRenderer;

    List<Vector2> points;

    [SerializeField]
    private Material eraserMaterial;

    public void UpdateLine(Vector2 position)
    {
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(position);
            return;
        }

        if (Vector2.Distance(points.Last(), position) > .1f)
        {
            SetPoint(position);
        }

        if (lineRenderer.material == eraserMaterial)
        {
			FindObjectOfType<AudioManager>().PlayAudio("DrawingErase");
		}
        else
        {
			FindObjectOfType<AudioManager>().PlayAudio("DrawingDraw");
		}
	}


    void SetPoint(Vector2 point)
    {
        points.Add(point);

		lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);
	}

    // Sets the line renderer's material - colour
    public void SetColour(Material brushMaterial)
    {
        lineRenderer.material = brushMaterial;
		FindObjectOfType<AudioManager>().PlayAudio("OptionSelect");
	}

    // Sets the line renderer's size
    public void SetSize(float size)
    {
        lineRenderer.widthMultiplier = size;
		FindObjectOfType<AudioManager>().PlayAudio("OptionSelect");
	}
}
