using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [SerializeField] float xAmount, yAmount;
    public List<GameObject> controlables = new List<GameObject>();

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.S))
        {
           foreach(var name in controlables)
            {
                //name.transform.Rotate(name.transform.rotation.x + 0.5f, name.transform.rotation.y, name.transform.rotation.z, Space.Self);

                float minRotation = -8;
                float maxRotation = 8;
                Vector3 currentRotation = transform.localRotation.eulerAngles;
                currentRotation.y = Mathf.Clamp(currentRotation.y, minRotation, maxRotation);
                name.transform.localRotation = Quaternion.Euler(currentRotation);
            }
        }
    }
}
