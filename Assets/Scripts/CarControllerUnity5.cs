using UnityEngine;
using System.Collections;

//Used the carcontroller from exampleassets and edited a bit.

public class CarControllerUnity5 : MonoBehaviour {
	[SerializeField] private WheelCollider[] m_WheelColliders = new WheelCollider[4];
	[SerializeField] private GameObject[] m_WheelMeshes = new GameObject[4];
/*	[SerializeField] private WheelCollider leftFront;
	[SerializeField] private WheelCollider rightFront;
	[SerializeField] private WheelCollider leftBack;
	[SerializeField] private WheelCollider righBack;

	[SerializeField] private GameObject leftFrontMesh;
	[SerializeField] private GameObject rightFrontMesh;
	[SerializeField] private GameObject leftBackMesh;
	[SerializeField] private GameObject righBackMesh;*/

	[SerializeField] private Vector3 m_CentreOfMassOffset;

	[SerializeField] private float m_Topspeed = 200;
	[SerializeField] private float m_SlipLimit;

	[SerializeField] private float m_FullTorqueOverAllWheels;

	[SerializeField] private float m_ReverseTorque;
	[SerializeField] private float m_BrakeTorque;
	[SerializeField] private float m_MaxHandbrakeTorque;
	[SerializeField] private float m_MaximumSteerAngle;
	
	private Quaternion[] m_WheelMeshLocalRotations;
	private Rigidbody m_Rigidbody;

	private float m_OldRotation; //used for steering
	private float m_SteerAngle;
	private float m_CurrentTorque;

	[SerializeField] private float m_Downforce = 100f;

	[Range(0, 1)] [SerializeField] private float m_SteerHelper; // 0 is raw physics , 1 the car will grip in the direction it is facing


	//public bool Skidding { get; private set; }
	public float BrakeInput { get; private set; }
	public float CurrentSteerAngle{ get { return m_SteerAngle; }}
	public float CurrentSpeed{ get { return m_Rigidbody.velocity.magnitude*2.23693629f; }}
	public float MaxSpeed{get { return m_Topspeed; }}
	public float AccelInput { get; private set; }

	private void Start()
	{
		m_WheelMeshLocalRotations = new Quaternion[4];
		for (int i = 0; i < 4; i++)
		{
			m_WheelMeshLocalRotations[i] = m_WheelMeshes[i].transform.localRotation;
		}
		m_WheelColliders[0].attachedRigidbody.centerOfMass = m_CentreOfMassOffset;
		
		m_MaxHandbrakeTorque = float.MaxValue;
		
		m_Rigidbody = GetComponent<Rigidbody>();
		m_CurrentTorque = m_FullTorqueOverAllWheels;
	}

	public void Move(float steering, float accel, float footbrake, float handbrake)
	{
		for (int i = 0; i < 4; i++) {
			Quaternion quat;
			Vector3 position;
			m_WheelColliders [i].GetWorldPose (out position, out quat);
			m_WheelMeshes [i].transform.position = position;

			//rotate wheel 90 so it looks normal :)
			Vector3 angles = quat.eulerAngles;
			angles.y += 90;
			quat.eulerAngles = angles;

			m_WheelMeshes [i].transform.rotation = quat;
		}
		
		//clamp input values
		steering = Mathf.Clamp (steering, -1, 1);
		AccelInput = accel = Mathf.Clamp (accel, 0, 1);
		BrakeInput = footbrake = -1 * Mathf.Clamp (footbrake, -1, 0);
		handbrake = Mathf.Clamp (handbrake, 0, 1);
		
		//Set the steer on the front wheels.
		//Assuming that wheels 0 and 1 are the front wheels.
		m_SteerAngle = steering * m_MaximumSteerAngle;
		m_WheelColliders [0].steerAngle = m_SteerAngle;
		m_WheelColliders [1].steerAngle = m_SteerAngle;
		
		SteerHelper ();
		ApplyDrive (accel, footbrake);
		CapSpeed ();
		
		//Set the handbrake.
		//Assuming that wheels 2 and 3 are the rear wheels.
		if (handbrake > 0f) {
			var hbTorque = handbrake * m_MaxHandbrakeTorque;
			m_WheelColliders [2].brakeTorque = hbTorque;
			m_WheelColliders [3].brakeTorque = hbTorque;
		}
		
		AddDownForce ();
		//CheckForWheelSpin();
	}

		private void CapSpeed()
		{
			float speed = m_Rigidbody.velocity.magnitude;

			//KMH
			speed *= 3.6f;
			if (speed > m_Topspeed)
				m_Rigidbody.velocity = (m_Topspeed/3.6f) * m_Rigidbody.velocity.normalized;
		}
		
		
		private void ApplyDrive(float accel, float footbrake)
		{
			//backwheel drive
			float thrustTorque = accel * (m_CurrentTorque / 2f);
			m_WheelColliders[2].motorTorque = m_WheelColliders[3].motorTorque = thrustTorque;
			
			for (int i = 0; i < 4; i++)
			{
				if (CurrentSpeed > 5 && Vector3.Angle(transform.forward, m_Rigidbody.velocity) < 50f)
				{
					m_WheelColliders[i].brakeTorque = m_BrakeTorque*footbrake;
				}
				else if (footbrake > 0)
				{
					m_WheelColliders[i].brakeTorque = 0f;
					m_WheelColliders[i].motorTorque = -m_ReverseTorque*footbrake;
				}
			}
		}
		
		
		private void SteerHelper()
		{
			for (int i = 0; i < 4; i++)
			{
				WheelHit wheelhit;
				m_WheelColliders[i].GetGroundHit(out wheelhit);
				if (wheelhit.normal == Vector3.zero)
					return; // wheels arent on the ground so dont realign the rigidbody velocity
			}
			
			// this if is needed to avoid gimbal lock problems that will make the car suddenly shift direction
			if (Mathf.Abs(m_OldRotation - transform.eulerAngles.y) < 10f)
			{
				var turnadjust = (transform.eulerAngles.y - m_OldRotation) * m_SteerHelper;
				Quaternion velRotation = Quaternion.AngleAxis(turnadjust, Vector3.up);
				m_Rigidbody.velocity = velRotation * m_Rigidbody.velocity;
			}
			m_OldRotation = transform.eulerAngles.y;
		}
		
		
		// this is used to add more grip in relation to speed
		private void AddDownForce()
		{
			m_WheelColliders[0].attachedRigidbody.AddForce(-transform.up*m_Downforce*
			                                               m_WheelColliders[0].attachedRigidbody.velocity.magnitude);
		}
		
	/*	
		// checks if the wheels are spinning and is so does three things
		// 1) emits particles
		// 2) plays tiure skidding sounds
		// 3) leaves skidmarks on the ground
		// these effects are controlled through the WheelEffects class
		private void CheckForWheelSpin()
		{
			// loop through all wheels
			for (int i = 0; i < 4; i++)
			{
				WheelHit wheelHit;
				m_WheelColliders[i].GetGroundHit(out wheelHit);
				
				// is the tire slipping above the given threshhold
				if (Mathf.Abs(wheelHit.forwardSlip) >= m_SlipLimit || Mathf.Abs(wheelHit.sidewaysSlip) >= m_SlipLimit)
				{
					m_WheelEffects[i].EmitTyreSmoke();
					
					// avoiding all four tires screeching at the same time
					// if they do it can lead to some strange audio artefacts
					if (!AnySkidSoundPlaying())
					{
						m_WheelEffects[i].PlayAudio();
					}
					continue;
				}
				
				// if it wasnt slipping stop all the audio
				if (m_WheelEffects[i].PlayingAudio)
				{
					m_WheelEffects[i].StopAudio();
				}
				// end the trail generation
				m_WheelEffects[i].EndSkidTrail();
			}
		}
	}*/
	

}