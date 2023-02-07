using UnityEngine;

public struct PlayerInputMapping
{
    // Put all bindings in here
    public InputButtonBind jumpInputButton;
    public InputButtonBind dropInputButton;
    public InputButtonBind interactInputButton;
    public InputButtonBind openInputButton;
    
    public InputButtonBind bumpLeftInputButton;
    public InputButtonBind bumpRightInputButton;
    
    public InputAxisBind GrabLeftButtonInput;
    public InputAxisBind GrabRightButtonInput;

    public InputAxisBind MoveXAxisInput;
    public InputAxisBind MoveYAxisInput;

    public InputAxisBind LookXAxisInput;
    public InputAxisBind LookYAxisInput;
    
    public InputButtonBind Option1ButtonInput;
    public InputButtonBind Option2ButtonInput;
    public InputButtonBind Option3ButtonInput;
    public InputButtonBind Option4ButtonInput;
    
    public InputButtonBind LeftClickButtonInput;
    public InputButtonBind RightClickButtonInput;
    public InputButtonBind PauseButtonInput;
    public InputButtonBind MapButtonInput;

    public static PlayerInputMapping DefaultMap => new ()
    {
        jumpInputButton = new InputButtonBind (KeyCode.Space, KeyCode.JoystickButton0), // Space and A button
        dropInputButton = new InputButtonBind(KeyCode.Q, KeyCode.JoystickButton1),    // Q and B button
        interactInputButton = new InputButtonBind(KeyCode.F, KeyCode.JoystickButton2), // F and X button
        openInputButton = new InputButtonBind(KeyCode.E, KeyCode.JoystickButton3),     // E and Y button

        bumpLeftInputButton = new InputButtonBind(KeyCode.LeftShift, KeyCode.JoystickButton4), // Shift and LB button
        bumpRightInputButton = new InputButtonBind(KeyCode.LeftAlt, KeyCode.JoystickButton5),  // Alt and RB button

        GrabLeftButtonInput = new InputAxisBind("MouseLeftClick", "LeftTrigger"),
        GrabRightButtonInput = new InputAxisBind("MouseRightClick", "RightTrigger"),

        MoveXAxisInput = new InputAxisBind("AD", "LeftStickHorizontal"),
        MoveYAxisInput = new InputAxisBind("WS", "LeftStickVertical"),

        LookXAxisInput = new InputAxisBind("MouseX", "RightStickHorizontal"),
        LookYAxisInput = new InputAxisBind("MouseY", "RightStickVertical"),
        
        Option1ButtonInput = new InputButtonBind(KeyCode.Alpha1, KeyCode.B),
        Option2ButtonInput = new InputButtonBind(KeyCode.Alpha2, KeyCode.B),
        Option3ButtonInput = new InputButtonBind(KeyCode.Alpha3, KeyCode.B),
        Option4ButtonInput = new InputButtonBind(KeyCode.Alpha4, KeyCode.B),

        LeftClickButtonInput = new InputButtonBind(KeyCode.T, KeyCode.JoystickButton8),
        RightClickButtonInput = new InputButtonBind(KeyCode.Y, KeyCode.JoystickButton9),

        PauseButtonInput = new InputButtonBind(KeyCode.Escape, KeyCode.JoystickButton7),
        MapButtonInput = new InputButtonBind(KeyCode.M, KeyCode.JoystickButton6),
    };
}