using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {
	public WheelCollider wheel_LF;
	public WheelCollider wheel_RF;
	public WheelCollider wheel_LB;
	public WheelCollider wheel_RB;

	public Transform wheelModel_LF;
	public Transform wheelModel_RF;
	public Transform wheelModel_LB;
	public Transform wheelModel_RB;

	public float maxTorque = 50f;
	public float maxSteeringAngle = 50f;
	public float maxBreakTorque = 50f;

	// Use this for initialization
	void Start () {
		Vector3 temp = rigidbody.centerOfMass;
		temp.y = -0.9f; //the f indicates that this is a floating point variable.
		rigidbody.centerOfMass = temp;
	}

	void FixedUpdate(){
		float angle = Input.GetAxis ("Horizontal");
		float speed = Input.GetAxis ("RightTrigger");
		float breakSpeed = Input.GetAxis("LeftTrigger");
		//float speed = Input.GetAxis ("Vertical");
		wheel_LB.motorTorque = maxTorque * -speed;
		wheel_RB.motorTorque = maxTorque * -speed;
		wheel_LF.steerAngle = maxSteeringAngle * angle;
		wheel_RF.steerAngle = maxSteeringAngle * angle;
		wheel_LB.brakeTorque = maxBreakTorque * breakSpeed;
		wheel_RB.brakeTorque = maxBreakTorque * breakSpeed;

		if (Input.GetButton("Submit")){
			transform.position = new Vector3(0.0f,5.0f,0.0f);
		}
	}


	void Update(){
	/*	wheelModel_LF.Rotate (wheel_LF.rpm / 60 * 360 * Time.deltaTime, wheel_LF.steerAngle, 0);
		wheelModel_RF.Rotate (0, wheel_RF.rpm / 60 * 360 * Time.deltaTime, wheel_RF.steerAngle);
		wheelModel_RB.Rotate (0, wheel_RB.rpm / 60 * 360 * Time.deltaTime, 0);
		wheelModel_LB.Rotate (0, wheel_LB.rpm / 60 * 360 * Time.deltaTime, 0);*/


	}
}
