using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public Rigidbody2D rb;
	[SerializeField] Transform hand;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;
	
	// Update is called once per frame
	void Update () {

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

		if (Input.GetButtonDown("JumpPlayer"))
		{
			jump = true;
		}
		RotateHand();


	}
	void RotateHand()
	{
		float angle = Utility.AngleTowardsMouse(hand.position);
		hand.rotation = Quaternion.Euler(new Vector3(-180f, 0f, angle));
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;
	}
}
