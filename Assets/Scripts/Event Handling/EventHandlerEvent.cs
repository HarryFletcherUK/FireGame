using UnityEngine;
using UnityEngine.Events;

public abstract class EventHandlerEvent : MonoBehaviour
{
    private readonly UnityEvent _event = new UnityEvent();
    public UnityEvent GetEvent() => _event;
    public void Invoke() => _event.Invoke();
}