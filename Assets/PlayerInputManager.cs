using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInputManager : MonoBehaviour
{

    private UnityEvent jumpButtonInput;
    void Start()
    {
        
        SubscribePlayerEventsToInputEvents();
    }
    
    jumpKey = KeyCode.space;

    void Update()
    {
        // A button on xbox
        if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Space)) // TODO: Update to use new input system instead
        {
            jumpButtonInput.Invoke();
        }
        
        // Foreach playerInput in allPlayerInputs, playerInput.CheckForInput(); // This will fire any keys held down this frame
    }
    
    private void SubscribePlayerEventsToInputEvents()
    {
        PlayerEventHandler eventHandler = PlayerEventHandler.Instance;
        var jumpInput = new JumpInput();
        EventHandlerEvent event_ = eventHandler.GetJumpEvent();
        jumpButtonInput.AddListener(event_.Invoke);
    }
}

public class JumpInput : PlayerInput
{
    
}

public abstract class PlayerInput
{
    KeyCode keyboardKey;
    KeyCode controllerButton;

    private UnityEvent onDownEvent = new UnityEvent();
    private UnityEvent onEvent = new UnityEvent();
    private UnityEvent onUpEvent = new UnityEvent();

    public void SetKey(KeyCode key)
    {
        keyboardKey = key;
    }

    public void SetButton(KeyCode button)
    {
        controllerButton = button;
    }

    public void CheckForInput()
    {
        // Controller Button                   || Keyboard key
        if (Input.GetKeyDown(controllerButton) || Input.GetKeyDown(keyboardKey)) onDownEvent.Invoke();
        if (Input.GetKey(controllerButton)     || Input.GetKey(keyboardKey))     onEvent.Invoke();
        if (Input.GetKeyUp(controllerButton)   || Input.GetKeyUp(keyboardKey))   onUpEvent.Invoke();
    }
}
