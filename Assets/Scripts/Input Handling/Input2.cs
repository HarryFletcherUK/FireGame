using System.Collections.Generic;
using System.Drawing.Printing;
using UnityEngine;
using UnityEngine.Events;

public abstract class Input2
{
    protected static List<Input2> allPlayerInputs = new List<Input2>();
    protected static List<Input2> allVehicleInputs = new List<Input2>();

    public static void CheckAllPlayerInputs()
    {
        foreach (var playerInput in allPlayerInputs)
        {
            playerInput.CheckForInput();
        }
    }
    
    public static void CheckAllVehicleInputs()
    {
        foreach (var vehicleInput in allVehicleInputs)
        {
            vehicleInput.CheckForInput();
        }
    }

    protected void AddInputToList(Input2 input, InputType type)
    {
        switch (type)
        {
            case InputType.Player:
                allPlayerInputs.Add(input);
                break;
            case InputType.Vehicle:
                allVehicleInputs.Add(input);
                break;
        }
    }

    protected abstract void CheckForInput();
}

public class Player2AxisInput: Input2
{
    private AxisInput axisX;
    private AxisInput axisY;
    
    public UnityEvent<Vector2> onAxisEvent = new UnityEvent<Vector2>();
    
    public Player2AxisInput(AxisInput axisX, AxisInput axisY)
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

public class AxisInput: Input2
{
    private string mouseAxis;
    private string controllerAxis;
    private bool isZero;

    public UnityEvent<float> onAxisEvent = new UnityEvent<float>();

    public AxisInput(InputAxisBind axisBind, InputType type)
    {
        mouseAxis = axisBind.Keyboard;
        controllerAxis = axisBind.Controller;
        AddInputToList(this, type);
    }

    public float GetValue => Input.GetAxis(controllerAxis) + Input.GetAxis(mouseAxis);

    protected override void CheckForInput()
    {
        if (Input.GetAxis(controllerAxis) == 0 && Input.GetAxis(mouseAxis) == 0)
        {
            if (isZero)
                return;
            isZero = true;
        }
        else
        {
            if (isZero)
                isZero = false;
        }

        onAxisEvent.Invoke(GetValue);
    }
}

public class ButtonInput: Input2
{
    private KeyCode keyboardKey;
    private KeyCode controllerButton;

    public UnityEvent onDownEvent = new UnityEvent();
    public UnityEvent onEvent = new UnityEvent();
    public UnityEvent onUpEvent = new UnityEvent();

    public ButtonInput(InputButtonBind buttonBind, InputType type)
    {
        keyboardKey = buttonBind.Keyboard;
        controllerButton = buttonBind.Controller;
        AddInputToList(this, type);
    }

    protected override void CheckForInput()
    {
        // Controller Button                   || Keyboard key
        if (Input.GetKeyDown(controllerButton) || Input.GetKeyDown(keyboardKey)) onDownEvent.Invoke();
        if (Input.GetKey(controllerButton)     || Input.GetKey(keyboardKey))     onEvent.Invoke();
        if (Input.GetKeyUp(controllerButton)   || Input.GetKeyUp(keyboardKey))   onUpEvent.Invoke();
    }
}

public enum InputType
{
    Player,
    Vehicle,
}