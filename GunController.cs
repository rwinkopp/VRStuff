using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZEffects;
public class GunController : MonoBehaviour {


	public GameObject Hand1;


	private SteamVR_TrackedObject trackedObj; 
	private SteamVR_Controller.Device device; 
	private SteamVR_TrackedController controller; 

	public EffectTracer TracerEffect; 
	public Transform muzzleTransform; 
	public AudioSource shotSound; 
	public AudioSource reloadSound; 
	public GameObject Bullet; 
	public float BulletSpeed;


	// Use this for initialization
	void Start () {

		controller = Hand1.GetComponent<SteamVR_TrackedController> (); 
		controller.TriggerClicked += TriggerPressed; 
		trackedObj = Hand1.GetComponent<SteamVR_TrackedObject> (); 

		
	}
	private void TriggerPressed(object sender, ClickedEventArgs e){

		ShootWeapon();
		}

	public void ShootWeapon(){

		RaycastHit hit = new RaycastHit();
		Ray ray = new Ray (muzzleTransform.position, muzzleTransform.forward); 

		device = SteamVR_Controller.Input ((int)trackedObj.index); 
		device.TriggerHapticPulse (600); 
		TracerEffect.ShowTracerEffect (muzzleTransform.position, muzzleTransform.forward, 250f); 

		shotSound.Play ();

		//creates a bullet 
		GameObject TempBullet; 
		TempBullet = Instantiate (Bullet, muzzleTransform.transform.position, muzzleTransform.transform.rotation) as GameObject; 
		Rigidbody TempRigidbody = TempBullet.GetComponent<Rigidbody> ();
		TempRigidbody.AddForce (transform.forward * BulletSpeed); 


		if (Physics.Raycast (ray, out hit, 5000f)) {

			if (hit.collider.attachedRigidbody) {


				Debug.Log ("hit" + hit.collider.gameObject.name);
			}
		}

	}








	// Update is called once per frame
	void Update () {
		
	}
}
