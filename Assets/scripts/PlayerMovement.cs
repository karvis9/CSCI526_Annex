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
		
		if(sceneName.Equals("Level_0") || sceneName.Equals("Level_2") || sceneName.Equals("Level_0_1"))
        {
			horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

			if (Input.GetButtonDown("JumpPlayer"))
			{
				jump = true;
			}
		}
		else if(sceneName.Equals("Level_1"))
        {
			movement.y = Input.GetAxisRaw("Vertical");
			movement.x = Input.GetAxisRaw("Horizontal");
		}

		//bow.bw.transform.RotateAround(transform.position, transform.up, 10 * Time.deltaTime);

    }

	void FixedUpdate ()
	{
		// Move our character
		if(sceneName.Equals("Level_0")  || sceneName.Equals("Level_2") || sceneName.Equals("Level_0_1"))
        {
			controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
			jump = false;
		}
		else if(sceneName.Equals("Level_1"))
        {
			Vector3 pos = rb.position + movement * verticalSpeed * Time.fixedDeltaTime;
			if (pos.x > 7f)
			{
				pos.x = 7f;
			}
			else if (pos.x < -7f)
			{
				pos.x = -7f;
			}

			if (pos.y > 4f)
			{
				pos.y = 4f;
			}
			else if (pos.y < -4f)
			{
				pos.y = -4f;
			}

			rb.MovePosition(pos);

		}
	}
}
