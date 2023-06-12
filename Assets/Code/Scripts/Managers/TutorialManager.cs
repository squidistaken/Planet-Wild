using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    public int popUpIndex;
	[SerializeField] private Image drawingPopUp;

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
    }
}
