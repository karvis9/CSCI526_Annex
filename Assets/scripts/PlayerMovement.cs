using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public CharacterController2D controller;

	public Rigidbody2D rb;
	//[SerializeField] Transform hand;

	public float runSpeed = 40f;
	public float verticalSpeed = 5f;
	float horizontalMove = 0f;
	bool jump = false;

	string sceneName;
	Vector2 movement;

    // Update is called once per frame

    private void Start()
    {
		Scene currentScene = SceneManager.GetActiveScene();
		sceneName = currentScene.name;
    }
    void Update () {
		
		if(sceneName.Equals("Level_0"))
        {
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

			if (Input.GetButtonDown("JumpPlayer"))
			{
				jump = true;
			}
		}
		else if(sceneName.Equals("MainScene_Arjun"))
        {
			movement.y = Input.GetAxisRaw("Vertical");
		}

		//bow.bw.transform.RotateAround(transform.position, transform.up, 10 * Time.deltaTime);

    }

	void FixedUpdate ()
	{
		// Move our character
		if(sceneName.Equals("Level_0"))
        {
			controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
			jump = false;
		}
		else if(sceneName.Equals("MainScene_Arjun"))
        {
			rb.MovePosition(rb.position + movement * verticalSpeed * Time.fixedDeltaTime);
        }
	}
}
