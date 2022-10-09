using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public Rigidbody2D rb;
	//[SerializeField] Transform hand;

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
		//RotateHand();


    }
	void RotateHand()
	{
        //float angle = Utility.AngleTowardsMouse(bow.bw.transform.position);
        //      bow.bw.transform.rotation = Quaternion.Euler(new Vector3(0f, 180f, angle));
        Vector2 dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;
	}

	void FixedUpdate ()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
		jump = false;
	}
}
