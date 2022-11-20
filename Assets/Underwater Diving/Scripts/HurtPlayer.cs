using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour {

	private PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();	
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){
			CountDownTimer.countDownTimerObj.reduceTime(10);
			Message.msg.SendMessage("-10 Seconds!", Color.red, 2f);
            AnalyticsManager.analyticsManager.SendEvent("Mine Touched");
			//thePlayer.hurt ();	 
		}

	}
}
