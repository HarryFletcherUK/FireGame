using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControllerDebug : MonoBehaviour
{
    [Space]
    [Header("Buttons")]
    [SerializeField] private Image aButton;
    [SerializeField] private Image bButton;
    [SerializeField] private Image xButton;
    [SerializeField] private Image yButton;
    
    [SerializeField] private Image rbButton;
    [SerializeField] private Image lbButton;
    [SerializeField] private Image rsButton;
    [SerializeField] private Image lsButton;
    
    [SerializeField] private Image backButton;
    [SerializeField] private Image startButton;
    
    [Space]
    [Header("Axes")]
    [SerializeField] private Image rTrigger;
    [SerializeField] private Image lTrigger;
    [SerializeField] private Transform rStick;
    [SerializeField] private Transform lStick;
    
    private Dictionary<Image, Color> startColours = new();
    private Dictionary<Transform, Vector3> startPositions = new();
    private Color defaultColour = Color.white;
    
    private PlayerInputManager input;
    private void Start()
    {
        input = PlayerInputManager.Instance;

        // Face Buttons
        AddDebugBinding(input.JumpButtonInput, aButton);
        AddDebugBinding(input.DropButtonInput, bButton);
        AddDebugBinding(input.InteractButtonInput, xButton);
        AddDebugBinding(input.OpenButtonInput, yButton);
        
        // Bumpers
        AddDebugBinding(input.BumpRightButtonInput, rbButton);
        AddDebugBinding(input.BumpLeftButtonInput, lbButton);
        
        // Sticks
        AddDebugBinding(input.RightClickButtonInput, rsButton);
        AddDebugBinding(input.LeftClickButtonInput, lsButton);
        
        // Back and Start
        AddDebugBinding(input.MapButtonInput, backButton);
        AddDebugBinding(input.PauseButtonInput, startButton);

        AddTriggerBinding(input.GrabLeftButtonInput, lTrigger);
        AddTriggerBinding(input.GrabRightButtonInput, rTrigger);

        AddStickBinding(input.MoveXAxisInput, input.MoveYAxisInput, lStick);
        AddStickBinding(input.LookXAxisInput, input.LookYAxisInput, rStick);
    }
    
    // Setup

    private void AddTriggerBinding(AxisInput inputMapButtonInput, Image triggerImage)
    {
        // Setup colour in dict, then change image to white
        startColours.Add(triggerImage, triggerImage.color);
        triggerImage.color = defaultColour;
        
        // Add listeners to display colour when pressed and return to white when released
        inputMapButtonInput.onAxisEvent.AddListener(lerpAmount => SetButtonColour(lerpAmount, triggerImage));
    }

    private void AddStickBinding(AxisInput inputMoveXAxisInput, AxisInput inputMoveYAxisInput, Transform stick)
    {
        // Set default position
        startPositions.Add(stick, stick.position);
        
        // Add listener
        inputMoveXAxisInput.onAxisEvent.AddListener(moveAmount => SetStickPosition(moveAmount, stick, Vector3.right));
        inputMoveYAxisInput.onAxisEvent.AddListener(moveAmount => SetStickPosition(moveAmount, stick, Vector3.up));
    }

    private void AddDebugBinding(ButtonInput playerButtonInput, Image buttonImage)
    {
        // Setup colour in dict, then change image to white
        startColours.Add(buttonImage, buttonImage.color);
        buttonImage.color = defaultColour;
        
        // Add listeners to display colour when pressed and return to white when released
        playerButtonInput.onDownEvent.AddListener(() => ActivateButtonColour(buttonImage));
        playerButtonInput.onUpEvent.AddListener(() => DisableButtonColour(buttonImage));
    }

    // Actions

    private void SetStickPosition(float amount, Transform stick, Vector3 axis)
    {
        var multiplier = 30f;
        var offset = amount * multiplier;

        var position = stick.position;
        
        if (axis == Vector3.up)
            position.y = startPositions[stick].y + offset;
        if (axis == Vector3.right)
            position.x = startPositions[stick].x + offset;

        stick.position = position;
    }
    
    private void SetButtonColour(float amount, Image image)
    {
        image.color = Color.Lerp(defaultColour,startColours[image], amount);
    }

    private void ActivateButtonColour(Image buttonImage)
    {
        SetButtonColour(1f, buttonImage);
    }
    
    private void DisableButtonColour(Image buttonImage)
    {
        SetButtonColour(0f, buttonImage);
    }
}
