using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [Header("Right Thimb Stick Movement")]
    [SerializeField]
    private float rotationSpeed;
    [SerializeField]
    private Transform root;
    private float xAxis, yAxis;

    [SerializeField]
    private float stomachOffset;

    [SerializeField]
    private ConfigurableJoint hipJoint, stomachJoint;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CameraControl();
    }

    private void CameraControl()
    {
        xAxis += Input.GetAxis("RightStickHorizontal") * rotationSpeed;
        yAxis -= Input.GetAxis("RightStickVertical") * rotationSpeed;
        yAxis = Mathf.Clamp(yAxis, -35, 60);

        Debug.Log(Input.GetAxis("RightStickHorizontal") != 0);
        Debug.Log(Input.GetAxis("RightStickVertical") != 0);

        Quaternion rootRotation = Quaternion.Euler(yAxis, xAxis, 0);

        root.rotation = rootRotation;

        hipJoint.targetRotation = Quaternion.Euler(0, -xAxis, 0);
        stomachJoint.targetRotation = Quaternion.Euler(-yAxis + stomachOffset, 0, 0);
    }
}
