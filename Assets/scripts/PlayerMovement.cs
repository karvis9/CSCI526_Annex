using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public Rigidbody2D rb;
	//[SerializeField] Transform hand;

	public float runSpeed = 40f;

	float horizontalMove = 0f;
	bool jump = false;

	float verticalMove = 0f;
	
	// Update is called once per frame
	void Update () {
		Scene currentScene = SceneManager.GetActiveScene();
		string name = currentScene.name;
		Debug.Log(name);
		if(name.Equals("Level_0"))
        {
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

			if (Input.GetButtonDown("JumpPlayer"))
			{
				jump = true;
			}
		}
		else if(name.Equals("MainScene_Arjun"))
        {
			verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;
		}

		//RotateHand();
		//bow.bw.transform.RotateAround(transform.position, transform.up, 10 * Time.deltaTime);

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
