using UnityEngine;
using System.Collections;

public class CarRotatingForce : MonoBehaviour {
    public float speed;
    public float rotationSpeed;
    public float rotateSpeedLimiter = 0.1f;
    private Rigidbody rb;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        //transform.forward = new Vector3(0.0f, 0.0f, 0.0f);
        Debug.Log(transform.forward);
	}

	
void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //float gas = Input.GetAxis("Triggers");
        float gas = Input.GetAxis("Vertical");

        Vector3 gasVector = new Vector3(gas, 0.0f, 0.0f);
        Vector3 movement = new Vector3(gas, 0.0f, moveHorizontal);
        Vector3 steering = new Vector3(0.0f, 0.0f, moveHorizontal * gas);

        Vector3 worldForcePosition = transform.TransformPoint(new Vector3(1.0f, 0.0f, 0.0f));
        rb.AddForceAtPosition(gasVector * speed * Time.deltaTime * 60, worldForcePosition);

        //Vector3 force = steering;
        //force.Normalize(); // normalize horizontal direction
        //force.y = Mathf.Sin(moveHorizontal * Mathf.Deg2Rad); // set elevation
        // vector force now points to the target at _angle degrees from the ground
        float speedBeFor = rb.velocity.magnitude;
//        rb.AddForceAtPosition((force.normalized + gasVector) * speed, transform.forward + transform.position + new Vector3(1.0f, 0.0f, 0.0f));
        rb.AddForceAtPosition((steering + transform.right) * rotationSpeed * speedBeFor* Time.deltaTime, transform.forward + transform.position + new Vector3(1.0f, 0.0f, 0.0f));
    //    Debug.Log(transform.forward);
    //    rb.AddForceAtPosition((gasVector + transform.forward) * speed * Time.deltaTime, transform.forward + transform.position + new Vector3(1.0f, 0.0f, 0.0f));
        //rb.velocity = Mathf.Clamp(rb.velocity.magnitude, 0, speedBeFor) * rb.velocity.normalized;
      

    }
void OnDrawGizmos()
{
    Gizmos.color = new Color(1, 0, 0, 1);
    Vector3 offset = transform.position - new Vector3(1.0f, 0.0f, 0.0f);
    float moveHorizontal = Input.GetAxis("Horizontal");
    Vector3 steering = new Vector3(1.0f, 0.0f, moveHorizontal);
    Gizmos.DrawLine(transform.position, transform.position + steering);
    Gizmos.color = new Color(0, 1, 0, 1);
    Gizmos.DrawLine(transform.position, transform.position + transform.forward);
    //Gizmos.DrawCube(offset, new Vector3(1, 1, 1));
}

    public float CurrentSpeed { get { return rb.velocity.magnitude * 2.23693629f; } }
}
