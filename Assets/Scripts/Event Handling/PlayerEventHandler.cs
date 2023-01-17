using System;
using System.CodeDom;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(OpenButtonEvent))]
public class PlayerEventHandler : MonoBehaviour
{
    public static PlayerEventHandler Instance { private set; get; }

    [SerializeField] private OpenButtonEvent openButtonPressed;
    [SerializeField] private JumpButtonEvent jumpButtonPressed;

    private void Awake()
    {
        Instance = this;
    }

    public EventHandlerEvent GetJumpEvent()
    {
        return jumpButtonPressed;
    }
}