using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Credit: Stan
public class MouseLook : MonoBehaviour
{
    
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;

	private Camera cam;
	private float zoomMultiplier = 2;
	private float defaultFov = 60f;
	private float zoomDuration = 0.1f;

	// Start is called before the first frame update
	void Start()
    {
		cam = Camera.main;
		Cursor.lockState = CursorLockMode.Locked;   
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

		// Right click
		if (Input.GetMouseButton(1))
		{
			ZoomCamera(defaultFov / zoomMultiplier);
		}
		else if (cam.fieldOfView != defaultFov)
		{
			ZoomCamera(defaultFov);
		}
	}

	void ZoomCamera(float target)
	{
		float angle = Mathf.Abs((defaultFov / zoomMultiplier) - defaultFov);
		cam.fieldOfView = Mathf.MoveTowards(cam.fieldOfView, target, angle / zoomDuration * Time.deltaTime);
	}
}
