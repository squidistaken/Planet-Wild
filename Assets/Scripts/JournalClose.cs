using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Credit: Stan
public class JournalClose : MonoBehaviour
{
    private BrushManager brushManager;
    private GameManager gameManager;
    
    public GameObject Crossair;
    private void Start()
    {
        brushManager = GameObject.Find("BrushManager").GetComponent<BrushManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    public PlayerInteract playerInteract;

    public void closeJournal()
    {
        brushManager.ClearLines();

        gameManager.UnloadScene("DrawingScene");
        gameManager.LoadScene("POVScene", true);


        Crossair.SetActive(true); //shows cusor
        EnablePlayerControls(); //enables player controls
        Cursor.visible = false; //hides cursor
        Cursor.lockState = CursorLockMode.Locked; //locks Cursor
        playerInteract.IsInteracting = false;
    }

    public GameObject Player;
    public GameObject MainCamera;
    void EnablePlayerControls()
    { 
        MainCamera.GetComponent<MouseLook>().enabled = true;
        Player.GetComponent<PlayerMovement>().enabled = true;
    }
}
