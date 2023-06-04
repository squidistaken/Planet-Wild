using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
	public void PlayGame()
	{
		GameManager.LoadScene("TutorialScene", true);
		GameManager.LoadScene("POVScene", true);
		GameManager.UnloadScene("MainMenuScene");
	}
}
