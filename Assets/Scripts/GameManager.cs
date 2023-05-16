using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private void Start()
	{
		LoadScene("POVScene", true);
	}

	public void LoadScene(string scene, bool isAdditive)
	{
		switch (isAdditive)
		{
			case true:
				SceneManager.LoadScene(scene, LoadSceneMode.Additive);
				break;
			case false:
				SceneManager.LoadScene(scene, LoadSceneMode.Single);
				break;
		}
	}

	public void UnloadScene(string scene)
	{
		SceneManager.UnloadSceneAsync(scene);
	}
}
