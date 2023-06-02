using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.IO;

public class JournalManager : MonoBehaviour
{
	private GameManager gameManager;

	public void OpenDrawings()
	{
		string filepath = Application.dataPath + "/MyDrawings";

		if (Directory.Exists(filepath))
		{
			Process.Start(filepath);

			/* ProcessStartInfo startInfo = new ProcessStartInfo
			{
				Arguments = filepath,
				FileName = "explorer.exe"
			};
			Process.Start(startInfo);*/
		}
		else
		{
			Directory.CreateDirectory(filepath);
			Process.Start(filepath);
		}

	}


	public void ChangeRegion()
	{

	}

	public void LoadSettings()
	{

	}

	public void ResumeGame()
	{
		gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
		gameManager.UnloadUI("JournalScene");
	}

	public void CloseGame()
	{

	}
}
