using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {
    public float speed;
    public float rotationSpeed;
    public float rotateSpeedLimiter = 0.1f;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>(); 
	}


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //float gas = Input.GetAxis("Triggers");
        float gas = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(gas, 0.0f, 0.0f);
        Vector3 steering = new Vector3(0.0f, 0.0f, moveHorizontal);

        rb.AddRelativeForce(movement * speed * Time.deltaTime);
        Vector3 worldForcePosition = transform.TransformPoint(new Vector3(1.0f, 0.0f, 0.0f));
        
        //Debug.Log(rb.GetRelativePointVelocity(new Vector3(0f, 0f, 0f)));
        Vector3 velocity = rb.GetRelativePointVelocity(new Vector3(0,0,0));
        if (velocity.x < rotateSpeedLimiter && velocity.x > -rotateSpeedLimiter && velocity.y < rotateSpeedLimiter && velocity.y > -rotateSpeedLimiter && velocity.z < rotateSpeedLimiter && velocity.z > -rotateSpeedLimiter)
        {
            //GetComponent<Transform>().Rotate(new Vector3(0, moveHorizontal * 20 * Time.deltaTime * Mathf.Abs(rb.GetRelativePointVelocity(new Vector3(0f, 0f, 0f)).x), 0));
            // when the velocity is very low (standing still or almost standing still) the car can't steer (rotate).
        }
        else
        {
            //GetComponent<Transform>().Rotate(new Vector3(0, moveHorizontal * rotationSpeed * Time.deltaTime));
        }
        Debug.Log(rb.transform.InverseTransformDirection(rb.velocity));
       /* if (transform.InverseTransformDirection(rb.velocity).x >= 0)
        {
            GetComponent<Transform>().Rotate(new Vector3(0, moveHorizontal * rotationSpeed * Time.deltaTime));
        }
        else
        {
            GetComponent<Transform>().Rotate(new Vector3(0, moveHorizontal * rotationSpeed * Time.deltaTime * -1));
        }*/
        //GetComponent<Transform>().Rotate(new Vector3(0, moveHorizontal * 100 * Time.deltaTime, 0));


        //GetComponent<Rigidbody>().AddForceAtPosition(steering * speed *2 *  Time.deltaTime, worldForcePosition);
        GetComponent<Rigidbody>().AddForceAtPosition(steering * rotationSpeed *20* Time.deltaTime, new Vector3(1.0f, 0.0f, 0.0f));

    }

    public float CurrentSpeed { get { return rb.velocity.magnitude * 2.23693629f; } }
}
