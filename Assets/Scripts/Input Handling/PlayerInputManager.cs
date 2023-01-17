using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    // Face buttons
    public PlayerButtonInput JumpButtonInput { private set; get; }
    public PlayerButtonInput DropButtonInput { private set; get; }
    public PlayerButtonInput InteractButtonInput { private set; get; }
    public PlayerButtonInput OpenButtonInput { private set; get; }
    
    // Bumpers
    public PlayerButtonInput BumpLeftButtonInput { private set; get; }
    public PlayerButtonInput BumpRightButtonInput { private set; get; }

    // Triggers
    public PlayerAxisInput GrabLeftButtonInput { private set; get; }
    public PlayerAxisInput GrabRightButtonInput { private set; get; }
    
    // Left stick (move)
    public PlayerAxisInput MoveYAxisInput { private set; get; }
    public PlayerAxisInput MoveXAxisInput { private set; get; }
    public Player2AxisInput MoveAxisInput { private set; get; }


    // Right stick (Aim)
    public PlayerAxisInput LookYAxisInput { private set; get; }
    public PlayerAxisInput LookXAxisInput { private set; get; }
    
    // Dpad
    public PlayerButtonInput Option1ButtonInput { private set; get; } // Up
    public PlayerButtonInput Option2ButtonInput { private set; get; } // Right
    public PlayerButtonInput Option3ButtonInput { private set; get; } // Down
    public PlayerButtonInput Option4ButtonInput { private set; get; } // Left
        
    // Stick click
    public PlayerButtonInput LeftClickButtonInput { private set; get; } // Left click
    public PlayerButtonInput RightClickButtonInput { private set; get; } // Right click
    
    // Start and back
    public PlayerButtonInput PauseButtonInput { private set; get; } // Start
    public PlayerButtonInput MapButtonInput { private set; get; } // Back

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
        PlayerInput.CheckAllPlayerInputs();
    }
    
    private void SetMapping(PlayerInputMapping map)
    {
        // Set bindings
        JumpButtonInput = new PlayerButtonInput(map.jumpInputButton); // Space and A button
        DropButtonInput = new PlayerButtonInput(map.dropInputButton);     // Q and B button
        InteractButtonInput = new PlayerButtonInput(map.interactInputButton); // F and X button
        OpenButtonInput = new PlayerButtonInput(map.openInputButton);     // E and Y button

        BumpLeftButtonInput = new PlayerButtonInput(map.bumpLeftInputButton); // Shift and LB button
        BumpRightButtonInput = new PlayerButtonInput(map.bumpRightInputButton);  // Alt and RB button
        
        GrabLeftButtonInput = new PlayerAxisInput(map.GrabLeftButtonInput);
        GrabRightButtonInput = new PlayerAxisInput(map.GrabRightButtonInput);

        MoveXAxisInput = new PlayerAxisInput(map.MoveXAxisInput);
        MoveYAxisInput = new PlayerAxisInput(map.MoveYAxisInput);
        
        LookXAxisInput = new PlayerAxisInput(map.LookXAxisInput);
        LookYAxisInput = new PlayerAxisInput(map.LookYAxisInput);

        Option1ButtonInput = new PlayerButtonInput(map.Option1ButtonInput); // Up
        Option2ButtonInput = new PlayerButtonInput(map.Option2ButtonInput); // Right
        Option3ButtonInput = new PlayerButtonInput(map.Option3ButtonInput); // Down
        Option4ButtonInput = new PlayerButtonInput(map.Option4ButtonInput); // Left

        LeftClickButtonInput = new PlayerButtonInput(map.LeftClickButtonInput); // Left click
        RightClickButtonInput = new PlayerButtonInput(map.RightClickButtonInput); // Right click

        PauseButtonInput = new PlayerButtonInput(map.PauseButtonInput); // Start
        MapButtonInput = new PlayerButtonInput(map.MapButtonInput); // Back
    }
}
