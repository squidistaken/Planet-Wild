using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HideBackButton : MonoBehaviour
{
	private void OnEnable()
	{
		if (SceneManager.GetSceneByName("TutorialScene").isLoaded)
		{
			gameObject.SetActive(false);
		}
		else
		{
			gameObject.SetActive(true);
		}
	}
}
