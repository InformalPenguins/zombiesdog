using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 10;

    [SerializeField]
    private float rotatingSpeed = 20;

    [SerializeField]
    private Transform pistol;

    [SerializeField]
    private CoolCamera mainCamera;

    private Rigidbody myRigidBody;

    private void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float axisHorizontal = Input.GetAxis("Horizontal");
        float axisVertical = Input.GetAxis("Vertical");
        float axisCameraZoom = Input.GetAxis("CameraZoom");
        float axisCameraHorizontal = Input.GetAxis("CameraHorizontal");
        float axisCameraVertical = Input.GetAxis("CameraVertical");

        Movement(axisHorizontal, axisVertical);
        Shoot(axisHorizontal, axisVertical);
        UpdateCamera(axisCameraZoom, axisCameraHorizontal, axisCameraVertical);
    }

    private void UpdateCamera(float axisCameraZoom, float axisCameraHorizontal, float axisCameraVertical)
    {
        mainCamera.UpdateCameraDistance(axisCameraZoom / 2);
        mainCamera.UpdateCameraPosition(axisCameraHorizontal / 2, axisCameraVertical / 2);
    }

    private void Movement(float axisHorizontal, float axisVertical)
    {
        Vector3 newDir = Vector3.RotateTowards(transform.forward, new Vector3(axisHorizontal, 0f, axisVertical), rotatingSpeed * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);

        if (axisHorizontal != 0f)
        {
            myRigidBody.velocity = new Vector3(
                axisHorizontal * movementSpeed,
                myRigidBody.velocity.y,
                myRigidBody.velocity.z
            );
        }

        if (axisVertical != 0f)
        {
            myRigidBody.velocity = new Vector3(
                myRigidBody.velocity.x,
                myRigidBody.velocity.y,
                axisVertical * movementSpeed
            );
        }
    }

    private void Shoot(float axisHorizontal, float axisVertical)
    {
        if (Input.GetButton("Jump"))
        {
            GameObject bullet = pistol.GetComponent<Pistol>().Bullet;

            GameObject newBullet = Instantiate(bullet, pistol.position, Quaternion.identity) as GameObject;
            Bullet bulletObj = newBullet.GetComponent<Bullet>();


            newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletObj.MovementSpeed);
        }
    }
}
