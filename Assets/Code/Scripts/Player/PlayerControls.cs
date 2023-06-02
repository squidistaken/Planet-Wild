using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
	public GameObject MainCamera;

	public void EnablePlayerControls()
	{
		MainCamera.GetComponent<MouseLook>().enabled = true;
		MainCamera.GetComponent<PlayerInteract>().enabled = true;
		this.GetComponent<PlayerMovement>().enabled = true;
		MainCamera.GetComponent<HeadBob>().enabled = true;

		Cursor.visible = false; //hides cursor
		Cursor.lockState = CursorLockMode.Locked; //locks Cursor
	}

	public void DisablePlayerControls()
	{
		MainCamera.GetComponent<MouseLook>().enabled = false;
		MainCamera.GetComponent<PlayerInteract>().enabled = false;
		this.GetComponent<PlayerMovement>().enabled = false;
		MainCamera.GetComponent<HeadBob>().enabled = false;

		Cursor.visible = true; //show cursor
		Cursor.lockState = CursorLockMode.None;
	}
}
