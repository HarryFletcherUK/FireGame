using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCameraMovement : MonoBehaviour
{
    [SerializeField] private Transform fireEngine;
    private float cameraDistance = 20f;
    private float cameraAngle = 30f;
    private float rotateSpeed = 1f;

    private void Start()
    {
        var camTransform = transform.GetChild(0);

        // Reset rotation, then apply distance
        camTransform.SetPositionAndRotation(transform.position, transform.rotation);
        camTransform.position += Vector3.back * cameraDistance;
        transform.Rotate(Vector3.right, cameraAngle, Space.World);
    }

    void Update()
    {
        // Update position of camera parent to follow trucks
        transform.position = fireEngine.position;
        transform.Rotate(Vector3.up, Input.GetAxis("RotateCamera") * rotateSpeed, Space.World);
    }
}
