using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    PlayerInputAction playerInputAction;

    public Vector2 axes => playerInputAction.Gameplay.Move.ReadValue<Vector2>();
    public Vector3 moveInput => new Vector3(AxisX, 0f, AxisY);
    public bool Run => playerInputAction.Gameplay.Run.WasPressedThisFrame();
    public bool StopRun => playerInputAction.Gameplay.Run.WasReleasedThisFrame();
    public bool Move => AxisX != 0f || AxisY != 0f;
    public float AxisX => axes.x;
    public float AxisY => axes.y;

    void Awake()
    {
        playerInputAction = new PlayerInputAction();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // public void OnMove(InputValue value)
    // {
    //     Vector2 input = value.Get<Vector2>();
    //     moveInput = new Vector3(input.x, 0f, input.y);
    // }

    public void EnableGameplayInput()
    {
        playerInputAction.Gameplay.Enable();
    }

    
}
