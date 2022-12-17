using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerMovement : MonoBehaviour
{
    float verticalMoveAxis;

    float horizontalLookAxis;

    Vector3 lookVector;

    float stillThreshold = 0.1f;

    [SerializeField]
    int speed;

    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        GetInput();

        Move();
    }

    private void GetInput()
    {
        verticalMoveAxis = Input.GetAxis("MoveVertical");

        if (Mathf.Abs(verticalMoveAxis) < stillThreshold)
        {
            verticalMoveAxis = 0;
        }

        horizontalLookAxis = Input.GetAxis("LookHorizontal");
    }

    private void Move()
    {
        lookVector.y = horizontalLookAxis;

        transform.position += transform.forward * verticalMoveAxis * speed * Time.deltaTime;

        transform.Rotate(lookVector);
    }
}
