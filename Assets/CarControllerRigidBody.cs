using UnityEngine;
using System.Collections;

public class CarControllerRigidBody : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		float steering = Input.GetAxis ("Horizontal");
		float speed = Input.GetAxis ("Vertical");
		print (speed);
		//rigidbody.AddForce (Vector3.left * 50000 * speed);
		rigidbody.AddForce((Quaternion.Euler(transform.InverseTransformDirection(0,steering*90,0)) *Vector3.left) * 50000*speed);
		//rigidbody.rotation = new  (0.0f, steering, 0.0f);
	}
}
