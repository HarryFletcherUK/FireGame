using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Printing;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Rigidbody))]
public class VehicleMovementController : MonoBehaviour
{
    [Header("Wheel Setup Options")]
    public List<AxleInfo> axleInfos; // the information about each individual axle
    public float maxMotorTorque; // maximum torque the motor can apply to wheel
    public float maxSteeringAngle; // maximum steer angle the wheel can have

    [Header("Drag Options")]
    [SerializeField] private bool enableDrag;

    private LerpTable dragTable;
    [SerializeField] private DebugText dragDebugText;
    
    private Rigidbody rb;
    private VehicleInputManager input;
    private WheelController wheelController; 
    private Vector3 positionLastFrame;

    private float accelerationInput;
    
    private void Start()
    {
        input = VehicleInputManager.Instance;
        rb = GetComponent<Rigidbody>();
        wheelController = new WheelController(maxMotorTorque, maxSteeringAngle, axleInfos);

        dragTable = CreateDragTable();
    }
    private void Update()
    {
        GetInput();
    }
    
    public void FixedUpdate()
    {
        float currentSpeed = CalculateSpeed();

        if (enableDrag)
            ApplyDrag(currentSpeed);
        wheelController.Update();

        // Used for calculating the speed next fixed update
        positionLastFrame = transform.position;
    }

    private float CalculateSpeed()
    {
        var distance = (transform.position - positionLastFrame).magnitude;
        var speed = (distance / Time.fixedDeltaTime);
        
        SpeedThings(speed);
        return speed;
    }

    private void SpeedThings(float speed)
    {
        // Update speedo in HUD
        Speedo.Instance.UpdateSpeed(speed);
        
        // Update engine audio
        if (TruckAudio.Instance)
            TruckAudio.Instance.SetSpeedPercent(speed/30f);
    }

    private void ApplyDrag(float currentSpeed)
    {
        // float maxSpeed = 15f;
        // float dragModifier = 4f;

        var dragAmount = NewDrag(currentSpeed, accelerationInput); // currentSpeed/(maxSpeed * dragModifier);
        // print(NewDrag(currentSpeed, accelerationInput));
        
        rb.drag = dragAmount;
        if (dragDebugText)
            dragDebugText.updateText.Invoke(dragAmount.ToString());
    }

    private float NewDrag(float speed, float acceleration)
    {
        var dragAmount = 0f;

        dragAmount = dragTable.GetWeight(speed, acceleration);

        return dragAmount;
    }
    
    private void GetInput()
    {
        float steer = input.SteeringAxisInput.GetValue;
        float acceleration = input.AccelerateButtonInput.GetValue;
        float braking = input.BrakeButtonInput.GetValue;

        accelerationInput = acceleration - braking;
        wheelController.UpdateInputs(steer, acceleration, braking);
    }

    private LerpTable CreateDragTable()
    {
        // Example instantiation
        float[] xValues = new float[] {0f, 5f, 10f, 15f, 20f, 25f, 30f};
        float[] yValues = new float[] {1f, 0.7f, 0.3f, 0f, -0.3f, -0.7f, -1f};
        float[,] weights = new float[,] {
            {0f, 0.06f, 0.08f, 0.1f, 0.12f, 0.15f, 0.2f},
            {0f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.2f},
            {0f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.2f},
            {1f, 0.5f, 0.2f, 0.15f, 0.1f, 0.07f, 0.05f},
            {1f, 0.1f, 0.1f, 0.1f, 0.65f, 0.1f, 0.2f},
            {1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.2f},
            {1f, 0.7f, 0.5f, 0.5f, 0.5f, 0.5f, 0.4f},
        };
        return new LerpTable(xValues, yValues, weights);
        
        // {0f, 0f, 0.1f, 0.12f, 0.3f, 0.4f, 0.38f},
        // {0f, 0.1f, 0.2f, 0.3f, 0.3f, 0.4f, 0.5f},
        // {0f, 0.2f, 0.3f, 0.3f, 0.4f, 0.5f, 0.65f},
        // {0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.65f, 0.8f},
        // {0.2f, 0.3f, 0.4f, 0.5f, 0.65f, 0.8f, 0.8f},
        // {0.3f, 0.4f, 0.5f, 0.65f, 0.8f, 0.8f, 0.9f},
        // {0.39f, 0.5f, 0.65f, 0.8f, 0.8f, 0.9f, 1f},
    }
}

public class LerpTable {
    private float[,] weights;
    private float[] xValues;
    private float[] yValues;
    
    public LerpTable(float[] xValues, float[] yValues, float[,] weights) {
        this.xValues = xValues;
        this.yValues = yValues;
        this.weights = weights;
    }
    
    public float GetWeight(float x, float y)
    {
        var xIndex = GetClosestValueIndex(x, xValues);
        var yIndex = GetClosestValueIndex(y, yValues);

        return weights[yIndex, xIndex];
    }

    private int GetClosestValueIndex(float speed, float[] axis)
    {
        float currentSmallestDiff = 10f;
        int smallestDiffIndex = -1;
        int index = 0;
        foreach (float f in axis)
        {
            var difference = Mathf.Abs(f - speed);
            if (difference < currentSmallestDiff)
            {
                currentSmallestDiff = difference;
                smallestDiffIndex = index;
            }

            index++;
        }

        return smallestDiffIndex;
    }
}