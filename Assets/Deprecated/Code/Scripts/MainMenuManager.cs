using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
	public void PlayGame()
	{
		GameManager.LoadScene("TutorialScene", false);

		GameManager.LoadScene("ManagerScene", true);
		GameManager.LoadScene("POVScene", true);
		GameManager.UnloadScene("MainMenuScene");
	}
}
