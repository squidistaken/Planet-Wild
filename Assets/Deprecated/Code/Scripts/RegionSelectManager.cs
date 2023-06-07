using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RegionSelectManager : MonoBehaviour
{
	public void LoadRegion(string regionName)
	{
		GameManager.LoadScene(regionName, false);

		GameManager.LoadScene("ManagerScene", true);
		GameManager.LoadScene("POVScene", true);
		GameManager.UnloadScene("RegionSelectScene");
	}

	public void GoBackToMenu()
	{
		GameManager.LoadUI("JournalScene", "RegionSelectScene");
	}
}
