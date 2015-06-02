using UnityEngine;
using System.Collections;

public class controller : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>(); 
	}


    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float gas = Input.GetAxis("Triggers");

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
        if (rb.GetRelativePointVelocity(new Vector3(0f, 0f, 0f)).x < 5 && rb.GetRelativePointVelocity(new Vector3(0f, 0f, 0f)).x > -5)
        {
            GetComponent<Transform>().Rotate(new Vector3(0, moveHorizontal * 20 * Time.deltaTime * Mathf.Abs(rb.GetRelativePointVelocity(new Vector3(0f, 0f, 0f)).x), 0));

        }
        else
        {
            GetComponent<Transform>().Rotate(new Vector3(0, moveHorizontal * 100 * Time.deltaTime, 0));
        }
        // Disable sidewards movement
        if ((moveHorizontal * 20 * Time.deltaTime * Mathf.Abs(rb.GetRelativePointVelocity(new Vector3(0f, 0f, 0f)).x)) > 1)
        {

        }
        else
        {
            //disable sidewards movem@tent
            Debug.Log(rb.velocity);
            //Debug.Log(transform.TransformPoint(rb.velocity));
            rb.velocity.Set(rb.velocity.x, 0, 0);
            Debug.Log(rb.velocity);
        }

        //GetComponent<Transform>().Rotate(new Vector3(0, moveHorizontal * 100 * Time.deltaTime, 0));


        //GetComponent<Rigidbody>().AddForceAtPosition(steering * speed/10 *  Time.deltaTime, worldForcePosition);

    }
}
