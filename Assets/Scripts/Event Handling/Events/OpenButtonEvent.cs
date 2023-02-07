using System;
using Unity.VisualScripting;

public class OpenButtonEvent : EventHandlerEvent
{
    private void Start()
    {
        PlayerInputManager.Instance.OpenButtonInput.onDownEvent.AddListener(Invoke);
    }
}