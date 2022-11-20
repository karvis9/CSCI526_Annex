using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
	public GameObject death;

	public float speed = 0.3f;

	private float turnTimer;
	public float timeTrigger;

	private Rigidbody2D myRigidbody;



 

	// Use this for initialization
	void Start () {
		myRigidbody = GetComponent<Rigidbody2D> ();

		turnTimer = 0;
		timeTrigger = 3f;
		 
	}

	// Update is called once per frame
	void Update (){
		myRigidbody.velocity = new Vector3 (myRigidbody.transform.localScale.x * speed, myRigidbody.velocity.y, 0f);

		turnTimer += Time.deltaTime;
		if(turnTimer >= timeTrigger){
			turnAround ();
			turnTimer = 0;
		}



	}


	void OnTriggerEnter2D(Collider2D other){

		if(other.tag == "Player"){
			CountDownTimer.countDownTimerObj.reduceTime(10);
			Message.msg.SendMessage("-5 Seconds!", Color.red, 2f);
            AnalyticsManager.analyticsManager.SendEvent("Fish Touched");
		}

	}

	void turnAround(){
		if (transform.localScale.x == 1) {
			transform.localScale = new Vector3 (-1f, 1f, 1f);
		} else {
			transform.localScale = new Vector3 (1f,1f,1f);
		}
	}
}
