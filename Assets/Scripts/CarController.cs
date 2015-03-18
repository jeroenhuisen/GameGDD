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
	public float antiRoll = 10f;

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
		float travelL = 0.0f;
		float travelR = 0.0f;
		float travelLB = 0.0f;
		float travelRB = 0.0f;

		WheelHit hit;

		bool groundedL = wheel_LF.GetGroundHit(out hit);
		if(groundedL)
			travelL = (-wheel_LF.transform.InverseTransformPoint(hit.point).y - wheel_LF.radius) / wheel_LF.suspensionDistance;
		else
			travelL = 1.0f;

		bool groundedR = wheel_RF.GetGroundHit(out hit);
		if(groundedR)
			travelR = (-wheel_RF.transform.InverseTransformPoint(hit.point).y - wheel_RF.radius) / wheel_RF.suspensionDistance;
		else
			travelR = 1.0f;
	
		bool groundedLB = wheel_LF.GetGroundHit(out hit);
		if(groundedLB)
			travelLB = (-wheel_LB.transform.InverseTransformPoint(hit.point).y - wheel_LB.radius) / wheel_LB.suspensionDistance;
		else
			travelLB = 1.0f;
		
		bool groundedRB = wheel_RB.GetGroundHit(out hit);
		if(groundedRB)
			travelRB = (-wheel_RB.transform.InverseTransformPoint(hit.point).y - wheel_RB.radius) / wheel_RB.suspensionDistance;
		else
			travelRB = 1.0f;

		float antiRollForce = (travelL - travelR) * antiRoll;
		if (groundedL)
			rigidbody.AddForceAtPosition(wheel_LF.transform.up * -antiRollForce, wheel_LF.transform.position); 
		if (groundedR)
			rigidbody.AddForceAtPosition(wheel_RF.transform.up * antiRollForce, wheel_RF.transform.position);

		float antiRollForceB = (travelLB - travelRB) * antiRoll;
		if (groundedLB)
			rigidbody.AddForceAtPosition(wheel_LB.transform.up * -antiRollForceB, wheel_LB.transform.position); 
		if (groundedRB)
			rigidbody.AddForceAtPosition(wheel_RB.transform.up * antiRollForceB, wheel_RB.transform.position);
		/*
		if(wheel_RF.GetGroundHit(out hit)) {
			WheelFrictionCurve forwardFriction = wheel_RF.forwardFriction;
			forwardFriction.stiffness = hit.collider.material.staticFriction;
			WheelFrictionCurve sidewaysFriction = wheel_RF.sidewaysFriction;
			sidewaysFriction.stiffness = hit.collider.material.staticFriction;
		}
		if(wheel_RB.GetGroundHit(out hit)) {
			WheelFrictionCurve forwardFriction = wheel_RB.forwardFriction;
			forwardFriction.stiffness = hit.collider.material.staticFriction;
			WheelFrictionCurve sidewaysFriction = wheel_RB.sidewaysFriction;
			sidewaysFriction.stiffness = hit.collider.material.staticFriction;
		}
		if(wheel_LF.GetGroundHit(out hit)) {
			WheelFrictionCurve forwardFriction = wheel_LF.forwardFriction;
			forwardFriction.stiffness = hit.collider.material.staticFriction;
			WheelFrictionCurve sidewaysFriction = wheel_LF.sidewaysFriction;
			sidewaysFriction.stiffness = hit.collider.material.staticFriction;
		}
		if(wheel_LB.GetGroundHit(out hit)) {
			WheelFrictionCurve forwardFriction = wheel_LB.forwardFriction;
			forwardFriction.stiffness = hit.collider.material.staticFriction;
			WheelFrictionCurve sidewaysFriction = wheel_LB.sidewaysFriction;
			sidewaysFriction.stiffness = hit.collider.material.staticFriction;
		}*/
		
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

	public void setColor(Color color){
		ChangeColorTo(new Vector3(color.r, color.g, color.b));
	}

	[RPC] void ChangeColorTo(Vector3 color)
	{
		Transform body = transform.FindChild ("Body");
		body.renderer.material.color = new Color(color.x, color.y, color.z, 1f);
		
		if (networkView.isMine)
			networkView.RPC("ChangeColorTo", RPCMode.OthersBuffered, color);
	}
}
