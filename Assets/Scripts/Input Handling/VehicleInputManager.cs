using UnityEngine;

public class VehicleInputManager : MonoBehaviour
{
    // Face buttons
    public ButtonInput JumpButtonInput { private set; get; }
    public ButtonInput DropButtonInput { private set; get; }
    public ButtonInput InteractButtonInput { private set; get; }
    public ButtonInput ExitButtonInput { private set; get; }
    
    // Bumpers
    public ButtonInput BumpLeftButtonInput { private set; get; }
    public ButtonInput BumpRightButtonInput { private set; get; }

    // Triggers
    public AxisInput BrakeButtonInput { private set; get; }
    public AxisInput AccelerateButtonInput { private set; get; }
    
    // Left stick (move)
    public AxisInput MoveYAxisInput { private set; get; }
    public AxisInput SteeringAxisInput { private set; get; }
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
    public ButtonInput SirenButtonInput { private set; get; } // Right click
    
    // Start and back
    public ButtonInput PauseButtonInput { private set; get; } // Start
    public ButtonInput MapButtonInput { private set; get; } // Back

    public static VehicleInputManager Instance { private set; get; }

    private void Awake()
    {
        Instance = this;
        
        var mapping = VehicleInputMapping.DefaultMap;
        SetMapping(mapping);

        MoveAxisInput = new(SteeringAxisInput, MoveYAxisInput);
    }

    private void Update()
    {
        // This will fire any keys held down this frame
        Input2.CheckAllVehicleInputs();
    }
    
    private void SetMapping(VehicleInputMapping map)
    {
        // Set bindings
        // JumpButtonInput = new ButtonInput(map.JumpInputButton); // Space and A button
        // DropButtonInput = new ButtonInput(map.DropInputButton);     // Q and B button
        // InteractButtonInput = new ButtonInput(map.InteractInputButton); // F and X button
        // ExitButtonInput = new ButtonInput(map.ExitInputButton);     // E and Y button
        //
        // BumpLeftButtonInput = new ButtonInput(map.BumpLeftInputButton); // Shift and LB button
        // BumpRightButtonInput = new ButtonInput(map.BumpRightInputButton);  // Alt and RB button

        BrakeButtonInput = new AxisInput(map.BrakeButtonInput, InputType.Vehicle);
        AccelerateButtonInput = new AxisInput(map.AccelerateButtonInput, InputType.Vehicle);

        SteeringAxisInput = new AxisInput(map.SteeringAxisInput, InputType.Vehicle);
        MoveYAxisInput = new AxisInput(map.MoveYAxisInput, InputType.Vehicle);

        LookXAxisInput = new AxisInput(map.LookXAxisInput, InputType.Vehicle);
        LookYAxisInput = new AxisInput(map.LookYAxisInput, InputType.Vehicle);

        // Option1ButtonInput = new ButtonInput(map.Option1ButtonInput); // Up
        // Option2ButtonInput = new ButtonInput(map.Option2ButtonInput); // Right
        // Option3ButtonInput = new ButtonInput(map.Option3ButtonInput); // Down
        // Option4ButtonInput = new ButtonInput(map.Option4ButtonInput); // Left
        //
        // LeftClickButtonInput = new ButtonInput(map.LeftClickButtonInput); // Left click
        // SirenButtonInput = new ButtonInput(map.SirenButtonInput); // Right click
        //
        // PauseButtonInput = new ButtonInput(map.PauseButtonInput); // Start
        // MapButtonInput = new ButtonInput(map.MapButtonInput); // Back
    }
}
