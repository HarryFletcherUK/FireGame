using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasicVehicleMovementController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f; // Speed of the vehicle
    [SerializeField] private float rotationSpeed = 100.0f; // Rotation speed of the vehicle

    void Update()
    {
        var movement = GetInput();
        Move(movement);
    }

    private static Vector2 GetInput()
    {
        var movement = new Vector2();
        
        // Get the horizontal and vertical input from the Xbox controller
        movement.x = PlayerInputManager.Instance.MoveXAxisInput.GetValue;
        movement.y = PlayerInputManager.Instance.GrabRightButtonInput.GetValue - PlayerInputManager.Instance.GrabLeftButtonInput.GetValue;

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