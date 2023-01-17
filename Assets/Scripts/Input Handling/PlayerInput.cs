using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEngine;
using UnityEngine.Events;

public abstract class PlayerInput
{
    private static List<PlayerInput> allPlayerInputs = new List<PlayerInput>();

    protected PlayerInput()
    {
        allPlayerInputs.Add(this);
    }

    public static void CheckAllPlayerInputs()
    {
        foreach (var playerInput in allPlayerInputs)
        {
            playerInput.CheckForInput();
        }
    }

    protected abstract void CheckForInput();
}

public class Player2AxisInput: PlayerInput
{
    private PlayerAxisInput axisX;
    private PlayerAxisInput axisY;
    
    public UnityEvent<Vector2> onAxisEvent = new UnityEvent<Vector2>();
    
    public Player2AxisInput(PlayerAxisInput axisX, PlayerAxisInput axisY)
    {
        this.axisX = axisX;
        this.axisY = axisY;
    }
    
    protected override void CheckForInput()
    {
        // Controller Axis                     || Mouse Axis
        if (axisX.GetValue != 0 || axisY.GetValue != 0) onAxisEvent.Invoke(new Vector2(axisX.GetValue, axisY.GetValue));
    }
}

public class PlayerAxisInput: PlayerInput
{
    private string mouseAxis;
    private string controllerAxis;
    private bool isZero;

    public UnityEvent<float> onAxisEvent = new UnityEvent<float>();

    public PlayerAxisInput(PlayerInputAxisBind axisBind)
    {
        mouseAxis = axisBind.Keyboard;
        controllerAxis = axisBind.Controller;
    }

    public float GetValue => Input.GetAxis(controllerAxis);

    protected override void CheckForInput()
    {
        if (Input.GetAxis(controllerAxis) == 0 && Input.GetAxis(mouseAxis) == 0)
        {
            if (isZero)
                return;
            isZero = true;
        }
        else
            if (isZero)
                isZero = false;

        onAxisEvent.Invoke(GetValue);
    }
}

public class PlayerButtonInput: PlayerInput
{
    private KeyCode keyboardKey;
    private KeyCode controllerButton;

    public UnityEvent onDownEvent = new UnityEvent();
    public UnityEvent onEvent = new UnityEvent();
    public UnityEvent onUpEvent = new UnityEvent();

    public PlayerButtonInput(PlayerInputButtonBind buttonBind)
    {
        keyboardKey = buttonBind.Keyboard;
        controllerButton = buttonBind.Controller;
    }

    protected override void CheckForInput()
    {
        // Controller Button                   || Keyboard key
        if (Input.GetKeyDown(controllerButton) || Input.GetKeyDown(keyboardKey)) onDownEvent.Invoke();
        if (Input.GetKey(controllerButton)     || Input.GetKey(keyboardKey))     onEvent.Invoke();
        if (Input.GetKeyUp(controllerButton)   || Input.GetKeyUp(keyboardKey))   onUpEvent.Invoke();
    }
}