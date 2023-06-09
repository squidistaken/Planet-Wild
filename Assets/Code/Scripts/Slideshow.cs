using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;

public class Slideshow : MonoBehaviour
{

    public Texture[] imageArray;
    private int currentImage;
    public float textPositionX = 1100f;
    public float textPositionY = 1000f;
    private GUIStyle guiStyle = new GUIStyle();
    public int fontSize = 75;

    void OnGUI()
    {

        int w = Screen.width, h = Screen.height;

        Rect imageRect = new Rect(0, 0, Screen.width, Screen.height);


        GUI.DrawTexture(imageRect, imageArray[currentImage]);
        guiStyle.fontSize = fontSize;
        guiStyle.normal.textColor = Color.white;
        GUI.Label(new Rect(Screen.width - textPositionX, Screen.height - textPositionY, 75, 75), "Klik om door te gaan >>", guiStyle);
    }

    // Start is called before the first frame update
    void Start()
    {
        currentImage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || (Input.GetKey(KeyCode.Space)))
        {
            currentImage++;

            if (currentImage >= imageArray.Length)
            {
                //Go to next scene
                SceneManager.LoadScene("TutorialScene");
            }
        }
    }
}