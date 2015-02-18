using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public float moveSpeed;
	public float rotateSpeed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		float rotateHorizontal = Input.GetAxis("RightStick X");
		float rotateVertical = Input.GetAxis("RightStick Y");

		float zoom = Input.GetAxis ("Triggers");
		                                     
		
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		Vector3 rotate = new Vector3 (rotateVertical, rotateHorizontal, 0.0f);
		transform.Translate (movement * moveSpeed * Time.deltaTime, Space.World );
		transform.Rotate (rotate * rotateSpeed * Time.deltaTime, Space.World);
		transform.Translate (0.0f,  0.0f, zoom * Time.deltaTime * 10);
	}
}
