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
        // Reset rotation, then apply distance
        transform.SetPositionAndRotation(transform.parent.position, transform.parent.rotation);
        transform.position += Vector3.back * cameraDistance;
        transform.parent.Rotate(Vector3.right, cameraAngle, Space.World);
    }

    void Update()
    {
        // Update position of camera parent to follow trucks
        transform.parent.position = fireEngine.position;
        transform.parent.Rotate(Vector3.up, Input.GetAxis("RotateCamera") * rotateSpeed, Space.World);
    }
}
