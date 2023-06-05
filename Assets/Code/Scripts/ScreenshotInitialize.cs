using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenshotInitialize : MonoBehaviour
{
	private void OnEnable()
	{
		gameObject.GetComponent<RawImage>().texture = GameManager.screenshotTexture;
	}
}
