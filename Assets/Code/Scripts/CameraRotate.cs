using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
	[SerializeField]
	private float rotateY = 0.05f;

	private void Update()
	{
		this.transform.Rotate(0, rotateY, 0, Space.Self);
	}
}
