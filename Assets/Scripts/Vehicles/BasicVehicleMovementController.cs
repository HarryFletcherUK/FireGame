using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class BasicVehicleMovementController : MonoBehaviour
{
    [SerializeField] private float speed = 10.0f; // Speed of the vehicle

    [SerializeField] private float rotationSpeed = 100.0f; // Rotation speed of the vehicle

    [SerializeField] private Camera cam;

    void Update()
    {
        var movement = GetInput();
        Move(movement);
    }

    private static Vector2 GetInput()
    {
        var movement = new Vector2();
        
        // Get the horizontal and vertical input from the Xbox controller
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Accelerate") - Input.GetAxis("Brake");

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
