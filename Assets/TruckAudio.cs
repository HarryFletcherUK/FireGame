using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TruckAudio : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    public static TruckAudio Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void SetSpeedPercent(float speedPercent)
    {
        speedPercent = Mathf.Clamp(speedPercent, 0, 30);
        if (speedPercent < 0.02f)
            speedPercent = 0;

        source.pitch = (speedPercent * 3f);

    }
}
