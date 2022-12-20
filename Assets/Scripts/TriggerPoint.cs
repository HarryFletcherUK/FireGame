using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerPoint : MonoBehaviour
{
    [SerializeField] private string tagName;
    [SerializeField] private GameObject prompt;
    [SerializeField] private UnityEvent onButtonPressed;
    [SerializeField] private EventHandlerEvent activationEvent;
    private bool listenerActive = false;
    
    private void Start()
    {
        if (prompt != null) prompt.SetActive(false);
    }

    private void Update()
    {
        transform.position = new Vector3();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(tagName))
            TogglePromptAndEventListener();
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(tagName))
            TogglePromptAndEventListener();
    }
    
    private void OnDisable()
    {
        TogglePromptAndEventListener();
    }

    /// <summary>
    /// This method will display the prompt 
    /// </summary>
    private void TogglePromptAndEventListener()
    {
        TogglePrompt();
        ToggleListener();
    }

    /// <summary>
    /// Toggles listening or not listening to [activationEvent]
    /// [activationEvent] is the event that will trigger [onButtonPressed] while tagged object is in the trigger area
    /// </summary>
    private void ToggleListener()
    {
        if (listenerActive.Toggle())
            activationEvent.GetEvent().AddListener(onButtonPressed.Invoke);
        else
            activationEvent.GetEvent().RemoveListener(onButtonPressed.Invoke);
    }

    /// <summary>
    /// Show or hide the button prompt canvas
    /// </summary>
    private void TogglePrompt()
    {
        if (prompt != null) prompt.SetActive(!prompt.activeSelf);
    }
}
