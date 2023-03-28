using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    //The arm joint
    [SerializeField]
    private ConfigurableJoint armJoint;
    //The grabbing script attached to this arm
    [SerializeField]
    private HandGrabController handGrab;

    //The target Y rotation for the joint
    [SerializeField]
    private float extendedJointRotation;

    //Joint roatation variables
    private int maxJointRotation;
    private float rotationFalloff;

    //Should the avatar grab stuff
    private bool grabActive;

    //The name in the Input Manager (left/right bumper)
    [SerializeField]
    private string inputName;

    // Start is called before the first frame update
    void Start()
    {
        maxJointRotation = 80;
        rotationFalloff = 5f;
        grabActive = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckMaxJointRotation();

        //Check the axis value and activate the grab
        if (Input.GetAxis(inputName) > 0.8f)
        {
            extendedJointRotation = maxJointRotation;
            grabActive = true;
        } else if (Input.GetAxis(inputName) < 0.5f)
        {
            grabActive = false;
        }

        handGrab.ToggleGrab(grabActive);

        armJoint.targetRotation = Quaternion.Euler(new Vector3(0, extendedJointRotation, 0));
        extendedJointRotation -= rotationFalloff;
    }

    /// <summary>
    /// Clamp the rotation of the shoulder joint
    /// Mathf.Clamp didnt work
    /// </summary>
    private void CheckMaxJointRotation()
    {
        if (extendedJointRotation > maxJointRotation)
            extendedJointRotation = maxJointRotation;
        else if (extendedJointRotation <= 0)
            extendedJointRotation = 0;
    }
}
