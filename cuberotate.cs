using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuberotate : MonoBehaviour {



	public float SpinSpeed;
	//public AudioClip IdleNoise; 
	public AudioClip Pickup; 
	//private bool IsAlive=true; 
	//public Transform transform; 
	// Use this for initialization
	void Start () {
	//	AudioSource.PlayClipAtPoint (IdleNoise, transform.position); 
	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (Vector3.right * SpinSpeed); 
		 }

	void OnCollisionEnter ( Collision other){
		if (other.gameObject.CompareTag ("Hand")) {
			//IsAlive = false; 
		AudioSource.PlayClipAtPoint(Pickup, transform.position); 
		Destroy(gameObject); 

		}
	}
}