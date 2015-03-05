using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	//public float moveSpeed;
	public float rotateSpeed;
	public Transform mainObject;

	private float startingRotationX;
	private float startingRotationY;
	private float startingRotationZ;
	private float startingRotationW;

	// Use this for initialization
	void Start () {
		startingRotationX = transform.rotation.x;
		startingRotationY = transform.rotation.y;
		startingRotationZ = transform.rotation.z;
		startingRotationW = transform.rotation.w;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//float moveHorizontal = Input.GetAxis("Horizontal");
		//float moveVertical = Input.GetAxis("Vertical");
		//Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		//transform.Translate (movement * moveSpeed * Time.deltaTime, Space.World );

		float rotateHorizontal = Input.GetAxis("RightStick X");
		float rotateVertical = Input.GetAxis("RightStick Y");

		//float zoom = Input.GetAxis ("Triggers");
		//transform.Translate (0.0f,  0.0f, zoom * Time.deltaTime * 10);		                                     

		Vector3 rotate = new Vector3 (rotateVertical, rotateHorizontal, 0.0f);
		
		Quaternion rotateBase = new Quaternion(startingRotationX + mainObject.rotation.x, startingRotationY + mainObject.rotation.y, startingRotationZ + mainObject.rotation.z, startingRotationW + mainObject.rotation.w);
		/*if (mainObject.rotation.x > 0.5) {
			rotateBase.x = mainObject.rotation.x;
			rotateBase.y = mainObject.rotation.y;
			rotateBase.z = mainObject.rotation.z;
		}*/
		//transform.rotation = rotateBase;

		//transform.RotateAround (mainObject.position, rotate, rotateSpeed * Time.deltaTime);

		/*print ("main" + mainObject.rotation);
		print ("camera" + transform.rotation);
		print (startingRotationX + mainObject.rotation.x);
		print (startingRotationY + mainObject.rotation.y);
		print (startingRotationZ + mainObject.rotation.z);
		print(startingRotationW + mainObject.rotation.w);*/
	}
}
