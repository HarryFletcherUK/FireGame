using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 6f; // Speed of the character
    [SerializeField]
    private float jumpForce = 5f; // Force of the character's jump
    [SerializeField]
    private float rotationSpeed = 80f; // Rotation speed of the character
    [SerializeField]
    private Transform groundCheck; // Transform used to check if the character is grounded

    private Rigidbody rb; // Rigidbody component of the character
    private bool isGrounded; // Flag to track if the character is grounded

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Check if the character is grounded
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.1f);

        // Get the horizontal and vertical input from the keyboard
        float horizontalInput = Input.GetAxis("LookHorizontal");
        float horizontalMoveInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");


        // Move the character based on the input
        transform.position -= transform.forward * verticalInput * moveSpeed * Time.deltaTime;
        transform.position += transform.right * horizontalMoveInput * moveSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);

        // Jump if the character is grounded and the space bar is pressed
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the character has collided with an object marked as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            // Set the character's position to be slightly above the ground
            transform.position = new Vector3(transform.position.x, collision.contacts[0].point.y, transform.position.z);
        }
    }
}
