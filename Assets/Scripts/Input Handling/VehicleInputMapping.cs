using UnityEngine;

public struct VehicleInputMapping
{
    // Put all bindings in here
    // public InputButtonBind JumpInputButton;
    // public InputButtonBind DropInputButton;
    // public InputButtonBind InteractInputButton;
    // public InputButtonBind ExitInputButton;
    //
    // public InputButtonBind BumpLeftInputButton;
    // public InputButtonBind BumpRightInputButton;
    
    public InputAxisBind BrakeButtonInput;
    public InputAxisBind AccelerateButtonInput;

    public InputAxisBind SteeringAxisInput;
    public InputAxisBind MoveYAxisInput;

    public InputAxisBind LookXAxisInput;
    public InputAxisBind LookYAxisInput;
    
    // public InputButtonBind Option1ButtonInput;
    // public InputButtonBind Option2ButtonInput;
    // public InputButtonBind Option3ButtonInput;
    // public InputButtonBind Option4ButtonInput;
    //
    // public InputButtonBind LeftClickButtonInput;
    // public InputButtonBind SirenButtonInput;
    // public InputButtonBind PauseButtonInput;
    // public InputButtonBind MapButtonInput;

    public static VehicleInputMapping DefaultMap => new ()
    {
        // JumpInputButton = new InputButtonBind (KeyCode.Space, KeyCode.JoystickButton0), // Space and A button
        // DropInputButton = new InputButtonBind(KeyCode.Q, KeyCode.JoystickButton1),    // Q and B button
        // InteractInputButton = new InputButtonBind(KeyCode.F, KeyCode.JoystickButton2), // F and X button
        // ExitInputButton = new InputButtonBind(KeyCode.E, KeyCode.JoystickButton3),     // E and Y button
        //
        // BumpLeftInputButton = new InputButtonBind(KeyCode.LeftShift, KeyCode.JoystickButton4), // Shift and LB button
        // BumpRightInputButton = new InputButtonBind(KeyCode.LeftAlt, KeyCode.JoystickButton5),  // Alt and RB button

        BrakeButtonInput = new InputAxisBind("MouseLeftClick", "LeftTrigger"),
        AccelerateButtonInput = new InputAxisBind("MouseRightClick", "RightTrigger"),

        SteeringAxisInput = new InputAxisBind("AD", "LeftStickHorizontal"),
        MoveYAxisInput = new InputAxisBind("WS", "LeftStickVertical"),

        LookXAxisInput = new InputAxisBind("MouseX", "RightStickHorizontal"),
        LookYAxisInput = new InputAxisBind("MouseY", "RightStickVertical"),
        
        // Option1ButtonInput = new InputButtonBind(KeyCode.Alpha1, KeyCode.B),
        // Option2ButtonInput = new InputButtonBind(KeyCode.Alpha2, KeyCode.B),
        // Option3ButtonInput = new InputButtonBind(KeyCode.Alpha3, KeyCode.B),
        // Option4ButtonInput = new InputButtonBind(KeyCode.Alpha4, KeyCode.B),
        //
        // LeftClickButtonInput = new InputButtonBind(KeyCode.T, KeyCode.JoystickButton8),
        // SirenButtonInput = new InputButtonBind(KeyCode.Y, KeyCode.JoystickButton9),
        //
        // PauseButtonInput = new InputButtonBind(KeyCode.Escape, KeyCode.JoystickButton7),
        // MapButtonInput = new InputButtonBind(KeyCode.M, KeyCode.JoystickButton6),
    };
}