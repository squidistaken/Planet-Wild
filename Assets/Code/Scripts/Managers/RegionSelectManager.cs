using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegionSelectManager : MonoBehaviour
{
	public void LoadRegion(string regionName)
	{
		GameManager.LoadScene(regionName, true);
		GameManager.LoadScene("POVScene", true);
		GameManager.UnloadScene("RegionSelectScene");
	}

	public void GoBackToMenu()
	{
		GameManager.LoadUI("JournalScene", "RegionSelectScene");
	}
}
