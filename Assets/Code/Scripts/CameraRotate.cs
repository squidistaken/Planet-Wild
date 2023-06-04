using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
	private void Update()
	{
		this.transform.Rotate(0, 0.1f, 0, Space.Self);
	}
}
