using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance {get; private set;}
    public event EventHandler OnRunPerformed;
    public event EventHandler OnRunCanceled;
    public event EventHandler OnCrouchPerformed;
    public event EventHandler OnCrouchCanceled;
    public event EventHandler OnJumpPerformed;
    public event EventHandler OnJumpCanceled;
    public event EventHandler OnDashPerformed;
    PlayerInputActions playerInputActions;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        playerInputActions = new PlayerInputActions();
    }

    void Start()
    {
        playerInputActions.Movement.Run.performed += PlayerInputActions_RunPerformed;
        playerInputActions.Movement.Run.canceled += PlayerInputActions_RunCanceled;
        playerInputActions.Movement.Crouch.performed += PlayerInputActions_CrouchPerformed;
        playerInputActions.Movement.Crouch.canceled += PlayerInputActions_CrouchCanceled;
        playerInputActions.Movement.Jump.performed += PlayerInputActions_JumpPerformed;
        playerInputActions.Movement.Jump.canceled += PlayerInputActions_JumpCanceled;
        playerInputActions.Movement.Dash.performed += PlayerInputActions_DashPerformed;
        playerInputActions.Movement.Enable();
    }

    public Vector2 GetWalkInputVectorNormalized()
    {
        return playerInputActions.Movement.Walk.ReadValue<Vector2>().normalized;
    }
    void PlayerInputActions_RunPerformed(InputAction.CallbackContext callbackContext)
    {
        OnRunPerformed?.Invoke(this, EventArgs.Empty);
    }
    void PlayerInputActions_RunCanceled(InputAction.CallbackContext callbackContext)
    {
        OnRunCanceled?.Invoke(this, EventArgs.Empty);
    }
    void PlayerInputActions_CrouchPerformed(InputAction.CallbackContext callbackContext)
    {
        OnCrouchPerformed?.Invoke(this, EventArgs.Empty);
    }
    void PlayerInputActions_CrouchCanceled(InputAction.CallbackContext callbackContext)
    {
        OnCrouchCanceled?.Invoke(this, EventArgs.Empty);
    }
    void PlayerInputActions_JumpPerformed(InputAction.CallbackContext callbackContext)
    {
        OnJumpPerformed?.Invoke(this, EventArgs.Empty);
    }
    void PlayerInputActions_JumpCanceled(InputAction.CallbackContext callbackContext)
    {
        OnJumpCanceled?.Invoke(this, EventArgs.Empty);
    }
    void PlayerInputActions_DashPerformed(InputAction.CallbackContext callbackContext)
    {
        OnDashPerformed?.Invoke(this, EventArgs.Empty);
    }
}
