using UnityEngine;

public class BasicVehicleController : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f; // Speed of the vehicle

    [SerializeField]
    private float rotationSpeed = 100.0f; // Rotation speed of the vehicle

    void Update()
    {
        // Get the horizontal and vertical input from the Xbox controller
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Accelerate") - Input.GetAxis("Brake");

        // Move the vehicle based on the input
        transform.position += transform.forward * (verticalInput * speed * Time.deltaTime);

        // Rotate the vehicle based on the input
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
