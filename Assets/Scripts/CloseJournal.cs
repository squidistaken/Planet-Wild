using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseJournal : MonoBehaviour
{
    public GameObject Crossair;
    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public PlayerInteract playerInteract;

    void Update()
    {
       if(Input.GetKey("q")) //close journal
        {
            closeJournal();
        }
    }

    public void closeJournal()
    {
        this.gameObject.SetActive(false);
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
