using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;

    private void LoadScene()
    {
        SceneManager.LoadSceneAsync("Tutorial");
    }

    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
             if(i == popUpIndex)
             {
                 popUps[i].SetActive(true);
             }
             else
             {
                 popUps[i].SetActive(false);
             }
        }

        if(popUpIndex == 0)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                popUpIndex++;
            }
        }
      
        
    }

    public void UnloadScene(string scene)
	{
		SceneManager.UnloadSceneAsync("Tutorial");
	}
}
