using UnityEngine;
using System.Collections;

public class CarControllerRigidBody : MonoBehaviour {
	public Vector3 oldAngle;

	public float maxSpeed = 100;
	public float maxSteeringAngle = 1;

	// Use this for initialization
	void Start () {
		rigidbody.maxAngularVelocity = maxSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		float steering = Input.GetAxis ("Horizontal");
		float speed = Input.GetAxis ("Vertical");
		//rigidbody.AddForce (Vector3.left * 50000 * speed);
		rigidbody.AddForce((Quaternion.Euler(transform.InverseTransformDirection(0,oldAngle.y + steering * maxSteeringAngle,0)) *Vector3.left) * 50000*speed);
		transform.rotation = Quaternion.Euler (transform.InverseTransformDirection (0, oldAngle.y + steering * maxSteeringAngle, 0));
		oldAngle = transform.eulerAngles;
	}
}
