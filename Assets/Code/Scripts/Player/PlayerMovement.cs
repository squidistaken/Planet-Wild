using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Credit: Stan
public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float playerSpeed = 12f;
    public float gravity = -9.81f;
    //public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    GameObject POVManager;

	private void Start()
	{
		POVManager = GameObject.Find("POVManager");
	}

	void Update()
    {        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * playerSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
	}
}
