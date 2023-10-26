using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(TextMeshProUGUI))]
public class DebugText : MonoBehaviour
{
    [SerializeField]
    private string label;

    public UnityEvent<string> updateText;

    private TextMeshProUGUI text;
    
    private string TextFormatter(string value) => $"{label}: {value}";

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        updateText.AddListener(UpdateText);
    }

    private void UpdateText(string value)
    {
        text.SetText(TextFormatter(value));
    }
}
