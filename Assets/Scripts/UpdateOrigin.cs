using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateOrigin : MonoBehaviour
{
    public float distanceThreshold = 1000;
    List<Transform> physicsObjects;
    GameObject ship;
    GameObject playerCamera;

    public event System.Action PostFloatingOriginUpdate;

    void Awake()
    {
        var ship = GameObject.FindGameObjectWithTag("CraftParent");
        var bodies = GameObject.FindGameObjectsWithTag("CelestialBody");

        physicsObjects = new List<Transform>();
        physicsObjects.Add(ship.transform);
        foreach (var c in bodies)
        {
            physicsObjects.Add(c.transform);
        }

        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void LateUpdate()
    {
        UpdateFloatingOrigin();
        if (PostFloatingOriginUpdate != null)
        {
            PostFloatingOriginUpdate();
        }
    }

    void UpdateFloatingOrigin()
    {
        Vector3 originOffset = playerCamera.transform.position;
        float dstFromOrigin = originOffset.magnitude;

        if (dstFromOrigin > distanceThreshold)
        {
            foreach (Transform t in physicsObjects)
            {
                t.position -= originOffset;
            }
        }
    }
}
