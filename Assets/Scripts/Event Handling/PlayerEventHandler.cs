using System;
using System.CodeDom;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(ActionButtonEvent))]
public class PlayerEventHandler : MonoBehaviour
{
    public static PlayerEventHandler Instance { private set; get; }

    [SerializeField] private ActionButtonEvent actionButtonPressed;
    [SerializeField] private JumpButtonEvent jumpButtonPressed;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        actionButtonPressed = GetComponent<ActionButtonEvent>();
    }

    public void Update()
    {
        // Y button on xbox
        if (Input.GetKeyDown(KeyCode.JoystickButton3)) // TODO: Update to use new input system instead
        {
            // Y Pressed
            actionButtonPressed.GetEvent().Invoke();
        }
    }

    public EventHandlerEvent GetJumpEvent()
    {
        return jumpButtonPressed;
    }
}