using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Speedo : MonoBehaviour
{
    public static Speedo Instance { private set; get; }
    private float maxSpeed = 30f;
    
    [SerializeField] private TextMeshProUGUI speedText;
    
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private float maxRotation;

    private void Awake()
    {
        Instance = this;
    }

    public void UpdateSpeed(float speed)
    {
        speedText.SetText($"{speed:00} MPH");
        speed = Mathf.Clamp(speed, 0f, maxSpeed);
        
        // Set the X rotation to 45 degrees
        var speedPercent = speed / maxSpeed;
        float zRotation = maxRotation - (2 * speedPercent * maxRotation);
        
        // Get the current rotation
        Quaternion rotation = rectTransform.transform.localRotation;
        rotation = Quaternion.Euler(0f, 0f, zRotation);

        // Apply the new rotation to the RectTransform
        rectTransform.transform.localRotation = rotation;
    }
}
