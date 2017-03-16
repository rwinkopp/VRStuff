using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonOrbit : MonoBehaviour {

	public float MoonOrbitSpeed;
	public GameObject Moon; 
	public GameObject Core; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		Moon.transform.RotateAround ( Vector3.zero , Vector3.left, MoonOrbitSpeed * Time.deltaTime);
		 	
		
	}
}
