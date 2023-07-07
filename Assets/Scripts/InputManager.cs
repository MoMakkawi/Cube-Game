using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput playerInput;
    public PlayerInput.OnFootActions onFoot;

    public PlayerLook playerLook;

    public PlayerMotor motor;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new PlayerInput();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        playerLook = GetComponent<PlayerLook>();
        playerLook.cam = GetComponentInChildren<Camera>();

        onFoot.Sprint.performed += ctx => motor.Sprint();
        onFoot.Croush.performed += ctx => motor.Crouch();

        onFoot.Jump.performed += ctx => motor.Jumb();
    }

    // FixedUpdate is called every fixed framerate frame
    void FixedUpdate()
    {
        //tell the playermotor to move using the value from our movement action
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }

    //LateUpdate is called after all Update functions have been called. This is useful to order script execution.
    private void LateUpdate()
    {
        if (playerLook != null)
        {
            playerLook.ProcessLook(onFoot.Look.ReadValue<Vector2>());
        }
        else
        {
            Debug.LogError("PlayerLook component is missing or not assigned.");
        }
    }

    private void OnEnable()
    {
        onFoot.Enable();
    }
    private void OnDisable()
    {
        onFoot.Disable();
    }
}
