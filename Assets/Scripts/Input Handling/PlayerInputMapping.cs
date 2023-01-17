using UnityEngine;

public struct PlayerInputMapping
{
    // Put all bindings in here
    public PlayerInputButtonBind jumpInputButton;
    public PlayerInputButtonBind dropInputButton;
    public PlayerInputButtonBind interactInputButton;
    public PlayerInputButtonBind openInputButton;
    
    public PlayerInputButtonBind bumpLeftInputButton;
    public PlayerInputButtonBind bumpRightInputButton;
    
    public PlayerInputAxisBind GrabLeftButtonInput;
    public PlayerInputAxisBind GrabRightButtonInput;

    public PlayerInputAxisBind MoveXAxisInput;
    public PlayerInputAxisBind MoveYAxisInput;

    public PlayerInputAxisBind LookXAxisInput;
    public PlayerInputAxisBind LookYAxisInput;
    
    public PlayerInputButtonBind Option1ButtonInput;
    public PlayerInputButtonBind Option2ButtonInput;
    public PlayerInputButtonBind Option3ButtonInput;
    public PlayerInputButtonBind Option4ButtonInput;
    
    public PlayerInputButtonBind LeftClickButtonInput;
    public PlayerInputButtonBind RightClickButtonInput;
    public PlayerInputButtonBind PauseButtonInput;
    public PlayerInputButtonBind MapButtonInput;

    public static PlayerInputMapping DefaultMap => new ()
    {
        jumpInputButton = new PlayerInputButtonBind (KeyCode.Space, KeyCode.JoystickButton0), // Space and A button
        dropInputButton = new PlayerInputButtonBind(KeyCode.Q, KeyCode.JoystickButton1),    // Q and B button
        interactInputButton = new PlayerInputButtonBind(KeyCode.F, KeyCode.JoystickButton2), // F and X button
        openInputButton = new PlayerInputButtonBind(KeyCode.E, KeyCode.JoystickButton3),     // E and Y button

        bumpLeftInputButton = new PlayerInputButtonBind(KeyCode.LeftShift, KeyCode.JoystickButton4), // Shift and LB button
        bumpRightInputButton = new PlayerInputButtonBind(KeyCode.LeftAlt, KeyCode.JoystickButton5),  // Alt and RB button

        GrabLeftButtonInput = new PlayerInputAxisBind("MouseLeftClick", "LeftTrigger"),
        GrabRightButtonInput = new PlayerInputAxisBind("MouseRightClick", "RightTrigger"),

        MoveXAxisInput = new PlayerInputAxisBind("AD", "LeftStickHorizontal"),
        MoveYAxisInput = new PlayerInputAxisBind("WS", "LeftStickVertical"),

        LookXAxisInput = new PlayerInputAxisBind("MouseX", "RightStickHorizontal"),
        LookYAxisInput = new PlayerInputAxisBind("MouseY", "RightStickVertical"),
        
        Option1ButtonInput = new PlayerInputButtonBind(KeyCode.Alpha1, KeyCode.B),
        Option2ButtonInput = new PlayerInputButtonBind(KeyCode.Alpha2, KeyCode.B),
        Option3ButtonInput = new PlayerInputButtonBind(KeyCode.Alpha3, KeyCode.B),
        Option4ButtonInput = new PlayerInputButtonBind(KeyCode.Alpha4, KeyCode.B),

        LeftClickButtonInput = new PlayerInputButtonBind(KeyCode.T, KeyCode.JoystickButton8),
        RightClickButtonInput = new PlayerInputButtonBind(KeyCode.Y, KeyCode.JoystickButton9),

        PauseButtonInput = new PlayerInputButtonBind(KeyCode.Escape, KeyCode.JoystickButton7),
        MapButtonInput = new PlayerInputButtonBind(KeyCode.M, KeyCode.JoystickButton6),
    };
}