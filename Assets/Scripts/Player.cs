using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 10f;

    [SerializeField]
    private float rotatingSpeed = 20f;

    [SerializeField]
    private float jumpForce = 20f;

    [SerializeField]
    private Transform pistol;

    [SerializeField]
    private CoolCamera mainCamera;

    private Rigidbody myRigidBody;

    [SerializeField]
    private Animator myAnimator;

    private bool isGrounded;

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
        bool isAttackButton = Input.GetButton("Attack");
        bool isJumpButton = Input.GetButton("Jump");

        Movement(axisHorizontal, axisVertical);
        Shoot(isAttackButton);
        Jump(isJumpButton);
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

        myAnimator.SetBool("IsRunning", axisHorizontal != 0f || axisVertical != 0f);
    }

    private void Shoot(bool attack)
    {
        if (attack)
        {
            GameObject bullet = pistol.GetComponent<Pistol>().Bullet;

            GameObject newBullet = Instantiate(bullet, pistol.position, Quaternion.identity) as GameObject;
            Bullet bulletObj = newBullet.GetComponent<Bullet>();


            newBullet.GetComponent<Rigidbody>().AddForce(transform.forward * bulletObj.MovementSpeed);
        }
    }

    private void Jump(bool jump)
    {
        if (jump)
        {
            myRigidBody.AddForce(transform.up * jumpForce);
        }
    }
}
