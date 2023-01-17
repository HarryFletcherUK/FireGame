using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class NewVehicleMovementController : MonoBehaviour
{
    [SerializeField] private float maxSpeed; // Speed of the vehicle

    private float speed;
    private float Speed
    {
        set
        {
            speed = Mathf.Clamp(value, 0, maxSpeed);
        }
        get
        {
            return speed;
        }
    }
    private float targetSpeed = 0f;

    private float TargetSpeed
    {
        set
        {
            targetSpeed = Mathf.Clamp(value, 0, maxSpeed);
        }
        get
        {
            return targetSpeed;
        }
    }
    [SerializeField] private float rotationSpeed; // Rotation speed of the vehicle

    private float acceleration;
    private float braking;
    private float turnAmount;
    
    private void OnEnable()
    {
        PlayerInputManager.Instance.GrabRightButtonInput.onAxisEvent.AddListener(SetAcceleration);
        PlayerInputManager.Instance.GrabLeftButtonInput.onAxisEvent.AddListener(SetBraking);
        PlayerInputManager.Instance.MoveXAxisInput.onAxisEvent.AddListener(SetTurnAmount);
    }
    private void OnDisable()
    {
        PlayerInputManager.Instance.GrabRightButtonInput.onAxisEvent.RemoveListener(SetAcceleration);
        PlayerInputManager.Instance.GrabLeftButtonInput.onAxisEvent.RemoveListener(SetBraking);
        PlayerInputManager.Instance.MoveXAxisInput.onAxisEvent.RemoveListener(SetTurnAmount);
    }
    
    private void SetAcceleration(float value)
    {
        TargetSpeed = value * maxSpeed;
        print(value);
        print(maxSpeed);
        print(value * maxSpeed);
    }

    [SerializeField] private float brakingSharpness;
    private void SetBraking(float value)
    {
        var speedPercent = speed / maxSpeed;
        if (speedPercent > value)
        {
            TargetSpeed = value * maxSpeed;
            Speed -= value * maxSpeed;
        }
    }

    private void SetTurnAmount(float value)
    {
        turnAmount = value;
    }

    private void Update()
    {
        Move();
        SetSpeed();
    }

    private void SetSpeed()
    {
        if (Speed < TargetSpeed)
            speed += Time.deltaTime * (maxSpeed/3f);
        
        if (Speed > TargetSpeed)
            speed -= Time.deltaTime * (maxSpeed/5f);
        // print($"Target speed: {targetSpeed}");
        // print($"Speed: {Speed}");
    }

    private void Turn()
    {
        // Rotate the vehicle based on the input
        var amount = turnAmount * rotationSpeed * Time.deltaTime * Speed;
        transform.Rotate(Vector3.up, amount);
    }

    private void Move()
    {
        float moveAmount = (Speed * Time.deltaTime);
        Turn();
        // Move forward based on speed
        transform.position += transform.forward * moveAmount;
        
    }
}
