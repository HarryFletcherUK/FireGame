using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    // Face buttons
    public ButtonInput JumpButtonInput { private set; get; }
    public ButtonInput DropButtonInput { private set; get; }
    public ButtonInput InteractButtonInput { private set; get; }
    public ButtonInput OpenButtonInput { private set; get; }
    
    // Bumpers
    public ButtonInput BumpLeftButtonInput { private set; get; }
    public ButtonInput BumpRightButtonInput { private set; get; }

    // Triggers
    public AxisInput GrabLeftButtonInput { private set; get; }
    public AxisInput GrabRightButtonInput { private set; get; }
    
    // Left stick (move)
    public AxisInput MoveYAxisInput { private set; get; }
    public AxisInput MoveXAxisInput { private set; get; }
    public Player2AxisInput MoveAxisInput { private set; get; }


    // Right stick (Aim)
    public AxisInput LookYAxisInput { private set; get; }
    public AxisInput LookXAxisInput { private set; get; }
    
    // Dpad
    public ButtonInput Option1ButtonInput { private set; get; } // Up
    public ButtonInput Option2ButtonInput { private set; get; } // Right
    public ButtonInput Option3ButtonInput { private set; get; } // Down
    public ButtonInput Option4ButtonInput { private set; get; } // Left
        
    // Stick click
    public ButtonInput LeftClickButtonInput { private set; get; } // Left click
    public ButtonInput RightClickButtonInput { private set; get; } // Right click
    
    // Start and back
    public ButtonInput PauseButtonInput { private set; get; } // Start
    public ButtonInput MapButtonInput { private set; get; } // Back

    public static PlayerInputManager Instance { private set; get; }

    private void Awake()
    {
        Instance = this;
        
        var mapping = PlayerInputMapping.DefaultMap;
        SetMapping(mapping);

        MoveAxisInput = new(MoveXAxisInput, MoveYAxisInput);
    }

    private void Update()
    {
        // This will fire any keys held down this frame
        Input2.CheckAllPlayerInputs();
    }
    
    private void SetMapping(PlayerInputMapping map)
    {
        // Set bindings
        JumpButtonInput = new ButtonInput(map.jumpInputButton, InputType.Player); // Space and A button
        DropButtonInput = new ButtonInput(map.dropInputButton, InputType.Player);     // Q and B button
        InteractButtonInput = new ButtonInput(map.interactInputButton, InputType.Player); // F and X button
        OpenButtonInput = new ButtonInput(map.openInputButton, InputType.Player);     // E and Y button

        BumpLeftButtonInput = new ButtonInput(map.bumpLeftInputButton, InputType.Player); // Shift and LB button
        BumpRightButtonInput = new ButtonInput(map.bumpRightInputButton, InputType.Player);  // Alt and RB button
        
        GrabLeftButtonInput = new AxisInput(map.GrabLeftButtonInput, InputType.Player);
        GrabRightButtonInput = new AxisInput(map.GrabRightButtonInput, InputType.Player);

        MoveXAxisInput = new AxisInput(map.MoveXAxisInput, InputType.Player);
        MoveYAxisInput = new AxisInput(map.MoveYAxisInput, InputType.Player);
        
        LookXAxisInput = new AxisInput(map.LookXAxisInput, InputType.Player);
        LookYAxisInput = new AxisInput(map.LookYAxisInput, InputType.Player);

        Option1ButtonInput = new ButtonInput(map.Option1ButtonInput, InputType.Player); // Up
        Option2ButtonInput = new ButtonInput(map.Option2ButtonInput, InputType.Player); // Right
        Option3ButtonInput = new ButtonInput(map.Option3ButtonInput, InputType.Player); // Down
        Option4ButtonInput = new ButtonInput(map.Option4ButtonInput, InputType.Player); // Left

        LeftClickButtonInput = new ButtonInput(map.LeftClickButtonInput, InputType.Player); // Left click
        RightClickButtonInput = new ButtonInput(map.RightClickButtonInput, InputType.Player); // Right click

        PauseButtonInput = new ButtonInput(map.PauseButtonInput, InputType.Player); // Start
        MapButtonInput = new ButtonInput(map.MapButtonInput, InputType.Player); // Back
    }
}
