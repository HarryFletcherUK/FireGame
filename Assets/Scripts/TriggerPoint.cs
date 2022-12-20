using System;
using UnityEngine;
using UnityEngine.Events;

public class TriggerPoint : MonoBehaviour
{
    [SerializeField] private string tagName;
    [SerializeField] private GameObject prompt;
    [SerializeField] private UnityEvent onButtonPressed;
    [SerializeField] private EventHandlerEvent eventButton;
    private bool listenerActive = false;
    
    private void Start()
    {
        if (prompt != null) prompt.SetActive(false);
    }

    public void Activate()
    {
        onButtonPressed.Invoke();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(tagName))
            return;

        ToggleAll();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(tagName))
            return;

        ToggleAll();
    }

    private void ToggleListener()
    {
        listenerActive = !listenerActive;

        if (listenerActive)
            eventButton.GetEvent().AddListener(Activate);
        else
            eventButton.GetEvent().RemoveListener(Activate);
    }

    private void ToggleAll()
    {
        TogglePrompt();
        ToggleListener();
    }

    private void OnDisable()
    {
        ToggleAll();
    }

    private void TogglePrompt()
    {
        if (prompt != null) prompt.SetActive(!prompt.activeSelf);
    }
}
