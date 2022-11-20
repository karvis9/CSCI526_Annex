using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour{

	public float moveSpeed;
	public bool rushing = false;
	private float speedMod = 0;

	float timeLeft = 2f;

	private Rigidbody2D myRigidBody;

	private Animator myAnim;

	public GameObject bubbles;

	// Use this for initialization
	void Start (){
		myRigidBody = GetComponent<Rigidbody2D> ();	
		myAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update (){

		resetBoostTime ();
		controllerManager ();



		myAnim.SetFloat ("Speed", Mathf.Abs(myRigidBody.velocity.x));

	 
		
	}

	void controllerManager (){
		if (Input.GetAxisRaw ("Horizontal") > 0f) {
			transform.localScale = new Vector3(1f,1f,1f);
			movePlayer ();
		} else if (Input.GetAxisRaw ("Horizontal") < 0f) {			
			transform.localScale = new Vector3(-1f,1f,1f);
			movePlayer ();
		} else if (Input.GetAxisRaw ("Vertical") > 0f) {
			myRigidBody.velocity = new Vector3 (myRigidBody.velocity.x, moveSpeed, 0f);
		} else if (Input.GetAxis ("Vertical") < 0f) {
			myRigidBody.velocity = new Vector3 (myRigidBody.velocity.x, -moveSpeed, 0f);
		}

		if(Input.GetButtonDown("Jump") && !rushing ){
			rushing = true;
			speedMod = 2;
			Instantiate (bubbles, gameObject.transform.position, gameObject.transform.rotation);
			movePlayer ();
		}	
	}

	void movePlayer(){
		if (transform.localScale.x == 1) {
			myRigidBody.velocity = new Vector3 (moveSpeed + speedMod, myRigidBody.velocity.y, 0f);	
		} else {
			myRigidBody.velocity = new Vector3 (- (moveSpeed + speedMod), myRigidBody.velocity.y, 0f);
		}	
	}

	void resetBoostTime(){
		if (timeLeft <= 0) {
			timeLeft = 2f;
			rushing = false;
			speedMod = 0;
		} else if(rushing) {
			timeLeft -= Time.deltaTime;
		}	
	}

	public void hurt(){
		if(!rushing){
			gameObject.GetComponent<Animator> ().Play ("PlayerHurt");		
		}

	}


}
