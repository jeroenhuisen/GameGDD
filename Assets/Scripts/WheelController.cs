using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WheelController : MonoBehaviour {

	public float speed;
	public Text text;
	
	void Start()
	{
	}
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		//float moveVertical = Input.GetAxis("Vertical");
		float gas = Input.GetAxis ("Triggers");
		
		Vector3 movement = new Vector3 (gas, 0.0f, 0.0f);
		rigidbody.AddForce (movement * speed * Time.deltaTime);
		Vector3 rotate = new Vector3 (moveHorizontal , 0.0f, 0.0f);
		transform.Rotate (rotate);
		text.text = gas.ToString ();
	}
}
