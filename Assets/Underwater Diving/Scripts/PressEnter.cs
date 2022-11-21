using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressEnter : MonoBehaviour {

	public SpriteRenderer mySprite;

	// Use this for initialization
	void Start () {
		mySprite = GetComponent<SpriteRenderer> ();
		StartCoroutine ("blinkText");		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator blinkText(){

		while(enabled){
	
			mySprite.color = new Color (0f,0f,0f,0f);

			yield return new WaitForSeconds (1f);

		
			mySprite.color = new Color (1f,1f,1f,1f); 

			yield return new WaitForSeconds (1f);	
		}



	}
}
