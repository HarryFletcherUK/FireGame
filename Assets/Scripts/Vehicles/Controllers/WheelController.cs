using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController
{
    private List<AxleInfo> axleInfos; // the information about each individual axle
    private float maxMotorTorque; // maximum torque the motor can apply to wheel
    private float maxSteeringAngle; // maximum steer angle the wheel can have

    private float steer;
    private float acceleration;
    private float braking;
    public WheelController(float maxMotorTorque, float maxSteeringAngle, List<AxleInfo> axleInfos)
    {
        this.maxMotorTorque = maxMotorTorque;
        this.maxSteeringAngle = maxSteeringAngle;
        this.axleInfos = axleInfos;
    }

    public void Update()
    {
        WheelCalculations();
    }

    public void UpdateInputs(float steer, float acceleration, float braking)
    {
        this.steer = steer;
        this.acceleration = acceleration;
        this.braking = braking;
    }
    
    private void WheelCalculations()
    {
        float motor = maxMotorTorque * MotorForce();
        float steering = maxSteeringAngle * steer;
            
        foreach (AxleInfo axleInfo in axleInfos) {
            if (axleInfo.steering) {
                axleInfo.leftWheel.steerAngle = steering;
                axleInfo.rightWheel.steerAngle = steering;
            }
            if (axleInfo.motor) {
                axleInfo.leftWheel.motorTorque = motor;
                axleInfo.rightWheel.motorTorque = motor;
            }
            ApplyLocalPositionToVisuals(axleInfo.leftWheel);
            ApplyLocalPositionToVisuals(axleInfo.rightWheel);
        }
    }
    
    // finds the corresponding visual wheel
    // correctly applies the transform
    public void ApplyLocalPositionToVisuals(WheelCollider collider)
    {
        bool isVisualWheel = collider.transform.childCount >= 1;
        if (!isVisualWheel)
            return;
     
        Transform visualWheel = collider.transform.GetChild(0);
     
        Vector3 position;
        Quaternion rotation;
        collider.GetWorldPose(out position, out rotation);
     
        visualWheel.transform.position = position;
        visualWheel.transform.rotation = rotation;
    }
    
    private float MotorForce()
    {
        return acceleration - braking;
    }
}
