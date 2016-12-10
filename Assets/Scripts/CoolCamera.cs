using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolCamera : MonoBehaviour
{
    [SerializeField]
    private float dampTime = 0.25f;

    [SerializeField]
    private float distanceFromTarget = 20f;

    [SerializeField]
    private float maxDistance = 50f;

    [SerializeField]
    private float minDistance = 5f;

    [SerializeField]
    private Transform target;

    private UnityEngine.Camera myCamera;

    private Vector3 velocity = Vector3.zero;

    public float DistanceFromTarget
    {
        get
        {
            return distanceFromTarget;
        }

        set
        {
            distanceFromTarget = value;
        }
    }

    void Start()
    {
        myCamera = GetComponent<UnityEngine.Camera>();
    }

    void Update()
    {
        Vector3 delta = target.position - myCamera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, distanceFromTarget));

        Vector3 destination = transform.position + delta;

        transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
    }

    public void UpdateCameraPosition(float horizontal, float vertical)
    {
        Vector3 newPosition = myCamera.transform.position;
        newPosition += new Vector3(horizontal, 0, vertical);
        myCamera.transform.position = newPosition;
    }

    public void UpdateCameraDistance(float cameraDistanceDelta)
    {
        float newValue = distanceFromTarget + cameraDistanceDelta;

        if (newValue < maxDistance && newValue > minDistance)
        {
            distanceFromTarget = newValue;
        }
    }
}
