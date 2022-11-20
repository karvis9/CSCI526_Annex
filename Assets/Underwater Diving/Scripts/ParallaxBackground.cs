 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour {

	public float backgroundSize;
	public float parallaxSpeed;

	private Transform cameraTransform;
	private Transform[] layers;
	private float viewZone = 10;
	private int leftIndex;
	private int rightIndex;
	private float lastCameraX;
	private float lastCameraY;

	// Use this for initialization
	void Start () {
		cameraTransform = Camera.main.transform;
		lastCameraX = cameraTransform.position.x;
		layers = new Transform[transform.childCount];

		for(int i = 0; i < transform.childCount; i++){
			layers [i] = transform.GetChild (i);
		}

		leftIndex = 0;
		rightIndex = layers.Length - 1;
	}
	
	// Update is called once per frame
	void Update () {
		
		parallaxHor ();
		parallaxVer ();


		if(cameraTransform.position.x < (layers[leftIndex].transform.position.x + viewZone) ){
			ScrollLeft ();			
		}

		if(cameraTransform.position.x > (layers[rightIndex].transform.position.x - viewZone) ){
			ScrollRight ();			
		}

	}

	private void parallaxHor(){
		float deltaX = cameraTransform.position.x - lastCameraX;
		transform.position += Vector3.right * (deltaX * parallaxSpeed);
		lastCameraX = cameraTransform.position.x;
	}

	private void parallaxVer(){
		float deltaY = cameraTransform.position.y - lastCameraY;
		transform.position += Vector3.up * (deltaY * parallaxSpeed);
		lastCameraY = cameraTransform.position.y;	
	}

	private void ScrollLeft(){
 
		layers [rightIndex].position = new Vector3(layers[leftIndex].position.x - backgroundSize, layers[leftIndex].position.y, 0f );
		leftIndex = rightIndex;
		rightIndex--;
		if(rightIndex < 0){
			rightIndex = layers.Length - 1;
		}
	}

	private void ScrollRight(){
 
		layers [leftIndex].position = new Vector3(layers[rightIndex].position.x + backgroundSize, layers[leftIndex].position.y, 0f );
		rightIndex = leftIndex;
		leftIndex++;
		if(leftIndex == layers.Length){
			leftIndex = 0;	
		}
	}


}
