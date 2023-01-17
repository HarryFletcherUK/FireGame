using UnityEngine;

public class PlayerInputButtonBind
{
    public readonly KeyCode Keyboard;
    public readonly KeyCode Controller;

    public PlayerInputButtonBind(KeyCode keyboardBinding, KeyCode controllerBinding)
    {
        Keyboard = keyboardBinding;
        Controller = controllerBinding;
    }
}

public class PlayerInputAxisBind
{
    public readonly string Keyboard;
    public readonly string Controller;

    public PlayerInputAxisBind(string keyboardBinding, string controllerBinding)
    {
        Keyboard = keyboardBinding;
        Controller = controllerBinding;
    }
}