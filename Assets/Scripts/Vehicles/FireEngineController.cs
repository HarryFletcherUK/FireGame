using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEngineController : MonoBehaviour
{
    private bool driveMode;
    [SerializeField] private BasicVehicleMovementController movecontroller;
    [SerializeField] private Transform vehicleEntryPoint;
    [SerializeField] private GameObject triggerPoint;
    [SerializeField] private ActionButtonEvent actionButtonPressed;
    [SerializeField] private GameObject fireCam;
    
    private GameObject player;
    private GameObject playerCam;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerCam = Camera.main.gameObject;
    }

    public void EnterVehicle()
    {
        // Disable player
        player.SetActive(false);
                
        // Enable Firetruck and firetruck cam
        movecontroller.enabled = true;
        triggerPoint.SetActive(false);
        fireCam.SetActive(true);
        playerCam.SetActive(false);
        
        // Setup trigger for
        actionButtonPressed.GetEvent().AddListener(ExitVehicle);
    }
    
    private void ExitVehicle()
    {
        // Remove trigger for
        actionButtonPressed.GetEvent().RemoveListener(ExitVehicle);
        
        // Disable Firetruck
        movecontroller.enabled = false;
        triggerPoint.SetActive(true);
        fireCam.SetActive(false);
        playerCam.SetActive(true);
                
        // Move and enable player
        player.transform.position = vehicleEntryPoint.position;
        player.SetActive(true);
    }
}
