using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class ScreenshotInitialize : MonoBehaviour
{
	public Sprite placeholder;
	public Sprite screenshot;

	// string relativePath = Application.dataPath + "/TemporaryScreenshot.png";

	private void Start()
	{
		
	}

	private void Update()
	{
		if (GameManager.loadScreenshot)
		{
			// AssetDatabase.Refresh();
			this.GetComponent<Image>().sprite = screenshot;
		}
		else
		{
			this.GetComponent<Image>().sprite = placeholder;
		}
	}

}
