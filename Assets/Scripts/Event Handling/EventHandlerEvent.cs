using UnityEngine;
using UnityEngine.Events;

public abstract class EventHandlerEvent : MonoBehaviour
{
    protected UnityEvent _event = new UnityEvent();
    public UnityEvent GetEvent() => _event;
    public void Invoke() => _event.Invoke();
}