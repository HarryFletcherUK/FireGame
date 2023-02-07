using UnityEngine;

public class InputButtonBind
{
    public readonly KeyCode Keyboard;
    public readonly KeyCode Controller;

    public InputButtonBind(KeyCode keyboardBinding, KeyCode controllerBinding)
    {
        Keyboard = keyboardBinding;
        Controller = controllerBinding;
    }
}

public class InputAxisBind
{
    public readonly string Keyboard;
    public readonly string Controller;

    public InputAxisBind(string keyboardBinding, string controllerBinding)
    {
        Keyboard = keyboardBinding;
        Controller = controllerBinding;
    }
}