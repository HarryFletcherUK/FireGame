using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float sensitivity = 5f;

    void Update()
    {
        float mouseX = Input.GetAxis("LookHorizontal");
        float mouseY = Input.GetAxis("LookVertical");

        transform.Rotate(Vector3.up * mouseX * sensitivity);
        transform.Rotate(Vector3.left * mouseY * sensitivity);
    }
}

