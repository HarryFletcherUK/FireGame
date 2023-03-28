using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollPlayerMovement : MonoBehaviour
{

    [Header("Left Thumb Stick Movement")]
    [SerializeField]
    private float speed;
    [SerializeField]
    private float strafeSpeed;
    //[SerializeField]
    //private float jumpForce;

    [Header("Right Thiub Stick Movement")]
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private Transform root;
    private float xAxis, yAxis;

    [SerializeField]
    private float stomachOffset;

    [SerializeField]
    private ConfigurableJoint hipJoint, stomachJoint;


    [SerializeField]
    private Rigidbody hips;
    private bool isGrounded;
    [SerializeField]
    private float jumpForce;

    private Vector3 movement;

    Quaternion rootRotation;

    [SerializeField]
    private float maxLookUp;
    [SerializeField]
    private float maxLookDown;

    void Start()
    {
        hips = GetComponent<Rigidbody>();
        rootRotation = new Quaternion();
    }

    private void FixedUpdate()
    {
        CameraControl();

        hips.AddForce(hips.transform.forward * Input.GetAxis("LeftStickVertical") * speed, ForceMode.Acceleration);
        Jump();
    }

    private void CameraControl()
    {
        xAxis += Input.GetAxis("RightStickHorizontal") * rotationSpeed;
        yAxis -= Input.GetAxis("RightStickVertical") * rotationSpeed;
        yAxis = Mathf.Clamp(yAxis, -35, 60);

        rootRotation = Quaternion.Euler(yAxis, xAxis, 0);
        root.rotation = rootRotation;

        hipJoint.targetRotation = Quaternion.Euler(0, -xAxis, 0);
        stomachJoint.targetRotation = Quaternion.Euler(-yAxis + stomachOffset, 0, 0);
    }

    private void Jump()
    {
        if(Input.GetAxis("Jump") > 0 && isGrounded)
        {
            hips.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
        }
    }

    public void IsGrounded(bool isGrounded)
    {
        this.isGrounded = isGrounded;
    }

}
