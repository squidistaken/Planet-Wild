using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;

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

        // Very temporary solution, reserved just for unicorn's lair
        switch (popUpIndex) {
            case 0:
				if (Input.GetKeyDown(KeyCode.W))
				{
					popUpIndex++;
				}
				break;
			case 1:
				if (Input.GetKeyDown(KeyCode.A))
				{
					popUpIndex++;
				}
				break;
			case 2:
				if (Input.GetKeyDown(KeyCode.D))
				{
					popUpIndex++;
				}
				break;
			case 3:
				if (Input.GetKeyDown(KeyCode.Space))
				{
					popUpIndex++;
				}
				break;
            default:
                break;
		}
       
      
        
    }
}
