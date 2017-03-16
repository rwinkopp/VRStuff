using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekAndDestroy : MonoBehaviour {



	public float speed; 
	public float SeekRange; 
	public float Power; 
	public Transform target; 
	public AudioClip Seeking; 
	public AudioClip Zapped;
	public float Dampening; 
	private bool IsAttacking = false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		float distance = Vector3.Distance (target.position, transform.position); 

		if (distance < SeekRange) {

			IsAttacking = true; 
			AudioSource.PlayClipAtPoint (Seeking, transform.position); 
		    Quaternion LookHere = Quaternion.LookRotation (target.position - transform.position); 
			transform.rotation = Quaternion.Slerp (transform.rotation, LookHere, Time.fixedDeltaTime * Dampening); 

		}

		if (IsAttacking = true && distance < SeekRange) {
			transform.Translate (Vector3.forward * speed * Time.deltaTime); 

			
		
		}
	}

	void OnCollisionEnter ( Collision other){
		if (other.gameObject.CompareTag ("Projectile")) {
			IsAttacking = false; 
			AudioSource.PlayClipAtPoint (Zapped, transform.position); 
			Destroy (gameObject); 

		}
	}


}
