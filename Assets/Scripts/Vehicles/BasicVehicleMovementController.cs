using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasicVehicleMovementController : MonoBehaviour
{
    private float speed = 10.0f; // Speed of the vehicle
    private float rotationSpeed = 100.0f; // Rotation speed of the vehicle
    private PlayerInputManager input;
    
    private void Start()
    {
        input = PlayerInputManager.Instance;
    }

    void Update()
    {
        var movement = GetInput();
        Move(movement);
    }

    private Vector2 GetInput()
    {
        var movement = new Vector2();
        
        var steering = input.MoveXAxisInput.GetValue;
        var accelerating = input.GrabRightButtonInput.GetValue;
        var breaking = input.GrabLeftButtonInput.GetValue;

        // Get the horizontal and vertical input from the Xbox controller
        movement.x = steering;
        movement.y = accelerating - breaking;

        return movement;
    }
    
    private void Move(Vector2 movement)
    {
        // Move the vehicle based on the input
        transform.position += transform.forward * (movement.y * speed * Time.deltaTime);
        
        // Rotate the vehicle based on the input
        transform.Rotate(Vector3.up, movement.x * rotationSpeed * Time.deltaTime * movement.y);
    }
}