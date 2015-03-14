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

	public float startingTorque = 1000f;
	public float acceleration = 10f;
	public float maxTorque = 50f;
	public float maxSteeringAngle = 50f;
	public float maxBreakTorque = 50f;

//	private float torque = 0;
//	private float lastSpeed = 0;

	// Use this for initialization
	void Start () {
		/*
		Vector3 temp = rigidbody.centerOfMass;
		temp.y = -0.9f;
		rigidbody.centerOfMass = temp;*/
		//torque = startingTorque;
	}

	void FixedUpdate(){
		float angle = Input.GetAxis ("Horizontal");
		//float speed = Input.GetAxis ("RightTrigger");
		//float breakSpeed = Input.GetAxis("LeftTrigger");
		float speed = Input.GetAxis ("Vertical");
		wheel_LB.motorTorque = maxTorque * -speed;
		wheel_RB.motorTorque = maxTorque * -speed;

		/*if (lastSpeed > speed) {
			if (torque > startingTorque) {
				torque = torque - (acceleration / 60);
			}
		} else if (lastSpeed < speed) {
			if (torque < maxTorque) {
				torque += (acceleration / 60);
			}
		} else {
			if (speed >= 1.0f) {
				if (torque < maxTorque) {
					torque += (acceleration / 60);
				}
			}
		}
		wheel_LB.motorTorque = torque * -speed;
		wheel_RB.motorTorque = torque * -speed;*/

		wheel_LF.steerAngle = maxSteeringAngle * angle;
		wheel_RF.steerAngle = maxSteeringAngle * angle;
		//wheel_LB.brakeTorque = maxBreakTorque * breakSpeed;
		//wheel_RB.brakeTorque = maxBreakTorque * breakSpeed;

		if (Input.GetButton("Submit")){
			transform.position = new Vector3(0.0f,5.0f,0.0f);
		}
//		lastSpeed = speed;
	}


	void Update(){
	/*	wheelModel_LF.Rotate (wheel_LF.rpm / 60 * 360 * Time.deltaTime, wheel_LF.steerAngle, 0);
		wheelModel_RF.Rotate (0, wheel_RF.rpm / 60 * 360 * Time.deltaTime, wheel_RF.steerAngle);
		wheelModel_RB.Rotate (0, wheel_RB.rpm / 60 * 360 * Time.deltaTime, 0);
		wheelModel_LB.Rotate (0, wheel_LB.rpm / 60 * 360 * Time.deltaTime, 0);*/


	}

	void OnGUI(){
		GUI.contentColor = Color.black;
		double speed = rigidbody.velocity.magnitude * 3.6;
		GUI.Label (new Rect (400, 400, 400, 400), "Speed:" + speed);
	}
}
