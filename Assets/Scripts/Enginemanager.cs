using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enginemanager : MonoBehaviour
{
    public EngineTemplate preset;

    private float thrust, gimbleRange, ISP;
    private Rigidbody rB;
    [SerializeField] GameObject thrustPoint;
    private GameObject vC;
    public Vector3 stopPos;

    void Start()
    {
        thrust = preset.thrust;
        rB = GetComponent<Rigidbody>();
        vC = GameObject.Find("MainCamera");
        vC.GetComponent<VehicleController>().controlables.Add(gameObject);
        stopPos = new Vector3(90, 0, 0);
    }


    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            rB.AddForceAtPosition(new Vector3(0, 1000, 0),thrustPoint.transform.position);
        }
        if (transform.rotation.x < stopPos.x - gimbleRange)
        {
            //transform.Rotate(stopPos.x - gimbleRange, transform.rotation.y, transform.rotation.z);
        }
    }
}
