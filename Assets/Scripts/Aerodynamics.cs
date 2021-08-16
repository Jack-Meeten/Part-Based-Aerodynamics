using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aerodynamics : MonoBehaviour
{
    public AnimationCurve liftCoefficient;
    public AnimationCurve dragCoefficient;
    public float lCE;
    public float lift;
    public float density = 1;
    public float area;
    public float lCEMag;
    public Vector3 rVelocity;
    private new Rigidbody rigidbody;
    public float speed;
    public float drag;
    public float dCE;
    public float dArea = 2.78f;
    public GameObject plane;
    public float velocity;

    private Vector3 line;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        //rigidbody.AddForce(new Vector3(0, 0, 100), ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        velocity = rigidbody.velocity.magnitude;
        Drag();
        Lift();
        Debug.DrawLine(transform.position, line, Color.red);
        Debug.DrawLine(transform.position, line, Color.red);
        //Debug.DrawRay(transform.position, line * -lift, Color.red);
    }

    private void Lift()
    {
        //lift
        rVelocity = transform.InverseTransformDirection(rigidbody.velocity);
        lCE = liftCoefficient.Evaluate(lCEMag - transform.localRotation.z);
        lCEMag = Mathf.Sqrt((Mathf.Pow(rVelocity.x, 2)) + (Mathf.Pow(rVelocity.y, 2)) + (Mathf.Pow(rVelocity.z, 2)));
        lift = (lCE * (density * Mathf.Pow(velocity, 2f) / 2) * area) / 1000;
        rigidbody.AddForce(new Vector3(0, lift, 0));
        //line = transform.TransformPoint(new Vector3(rVelocity.x, rVelocity.y, -drag));
        line = transform.TransformPoint(new Vector3(rigidbody.velocity.x, rigidbody.velocity.x, -lift));
        //Debug.Log("Lift:" + lift);
        Debug.Log(line);
    }

    private void Drag()
    {
        //drag
        speed = rigidbody.velocity.magnitude;
        dCE = dragCoefficient.Evaluate(speed);
        drag = (dCE * (density * Mathf.Pow(velocity, 2f) / 2) * 2.78f) / 100000;
        plane.GetComponent<Rigidbody>().AddRelativeForce(transform.InverseTransformDirection(0, 0, drag));
        //Debug.Log(drag);
    }
}
