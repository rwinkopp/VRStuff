using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {

	 ParticleSystem hitParticles;
	 AudioSource boom; 
	 BoxCollider hammer; 



	// Use this for initialization
	void Start () {
		boom = GetComponent <AudioSource> ();
		hitParticles = GetComponentInChildren<ParticleSystem> ();
		hammer = GetComponent <BoxCollider> ();
	}
	
	// Update is called once per frame
	void Update () {


	}
		

	void OnCollisionEnter (Collision collision){

		ContactPoint contact = collision.contacts [0];
		Vector3 SmashPoint = contact.point; 
		hitParticles.transform.position = SmashPoint;
		hitParticles.Play();
		boom.Play (); 


	}



}//end 

