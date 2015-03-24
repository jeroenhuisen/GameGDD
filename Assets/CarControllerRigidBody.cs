using UnityEngine;
using System.Collections;

public class CarControllerRigidBody : MonoBehaviour {
	public Vector3 oldAngle;

	public float maxSpeed = 100;
	public float maxSteeringAngle = 1;

	//public Transform leftWheel;
	//public Transform rightWheel;

	// Use this for initialization
	void Start () {
		rigidbody.maxAngularVelocity = maxSpeed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		float steering = Input.GetAxis ("Horizontal");
		float gas = Input.GetAxis ("Vertical");
		//rigidbody.AddForce((Quaternion.Euler(transform.InverseTransformDirection(0,oldAngle.y + steering * maxSteeringAngle,0)) *Vector3.back) * 50000*gas);
/*		if (gas > 0) {
			rigidbody.AddRelativeForce ((Quaternion.Euler (transform.InverseTransformDirection (0, steering * maxSteeringAngle, 0)) * Vector3.left) * 50000 * gas);
		}
		else if(gas < 0){
			rigidbody.AddRelativeForce ((Quaternion.Euler (transform.InverseTransformDirection (0, steering * maxSteeringAngle, 0)) * Vector3.left) * 50000 * -gas);
		}*/

		rigidbody.AddRelativeForce (Vector3.back * gas * 100000, ForceMode.Force);
//		Vector3 speed = rigidbody.velocity;
		//if (speed.x > 0 || speed.y > 0 || speed.z > 0) {
		//GetComponent<Rigidbody>().rotation = Quaternion.Euler (transform.InverseTransformDirection (0, oldAngle.y + steering * maxSteeringAngle, 0));
		transform.rotation = Quaternion.Euler (transform.InverseTransformDirection (0, oldAngle.y + steering * maxSteeringAngle, 0));
		//rigidbody.AddRelativeTorque (transform.up * steering * maxSteeringAngle * 1000);
		//rigidbody.AddTorque (transform.up * gas);
		//}
		//leftWheel.rotation = Quaternion.Euler (transform.InverseTransformDirection (90, steering * maxSteeringAngle, 0));
		//rightWheel.rotation = Quaternion.Euler (transform.InverseTransformDirection (90, steering * maxSteeringAngle, 0));
		oldAngle = transform.eulerAngles;
	}
}
