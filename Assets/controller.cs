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
        //GetComponent<Transform>().RotateAroundLocal(new Vector3(0.0f, 0.0f, 0.0f), 90);
        /*if (rb.velocity.x > 1 || rb.velocity.y > 1 || rb.velocity.z > 1 || rb.velocity.x < -1 || rb.velocity.y < -1 || rb.velocity.z < -1)
        {
            GetComponent<Transform>().Rotate(new Vector3(0, moveHorizontal * 5, 0));
        }
        else
        {
            GetComponent<Transform>().Rotate(new Vector3(0, moveHorizontal * 5 * Mathf.Abs(rb.velocity.x), 0));
        }*/


        //Debug.Log(rb.GetRelativePointVelocity(new Vector3(0f,0f,0f)));


        // Steering but disabled when vehicle doesn't move forward or backwards 
        //Debug.Log(rb.GetRelativePointVelocity(new Vector3(0f, 0f, 0f)));
        Vector3 velocity = rb.GetRelativePointVelocity(new Vector3(0,0,0));
        if (velocity.x < rotateSpeedLimiter && velocity.x > -rotateSpeedLimiter && velocity.y < rotateSpeedLimiter && velocity.y > -rotateSpeedLimiter && velocity.z < rotateSpeedLimiter && velocity.z > -rotateSpeedLimiter)
        {
            //GetComponent<Transform>().Rotate(new Vector3(0, moveHorizontal * 20 * Time.deltaTime * Mathf.Abs(rb.GetRelativePointVelocity(new Vector3(0f, 0f, 0f)).x), 0));
            // when the velocity is very low (standing still or almost standing still) the car can't steer (rotate).
        }
        else
        {
            GetComponent<Transform>().Rotate(new Vector3(0, moveHorizontal * rotationSpeed * Time.deltaTime));
        }
        if (velocity.x >= 0 && velocity.y >= 0 && velocity.z >= 0)
        {

        }
        //GetComponent<Transform>().Rotate(new Vector3(0, moveHorizontal * 100 * Time.deltaTime, 0));


        //GetComponent<Rigidbody>().AddForceAtPosition(steering * speed/10 *  Time.deltaTime, worldForcePosition);

    }
}
