using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public static InputManager Instance {get; private set;}
    //PlayerMovement
    public event EventHandler OnRunPerformed;
    public event EventHandler OnRunCanceled;
    public event EventHandler OnCrouchPerformed;
    public event EventHandler OnCrouchCanceled;
    public event EventHandler OnJumpPerformed;
    public event EventHandler OnJumpCanceled;
    public event EventHandler OnDashPerformed;
    //PlayerAttacks
    public event EventHandler OnSwordPerformed;
    public event EventHandler OnAimWithBowPerformed;
    public event EventHandler OnShootBowPerformed;
    public event EventHandler OnAxePerformed;
    public event EventHandler OnThrowGrenadePerformed;
    //PlayerInventory
    public event EventHandler OnSwitchItemPerformed;
    public event EventHandler OnTakeItemPerformed;
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
        //PlayerMovement
        playerInputActions.Movement.Run.performed += PlayerInputActions_RunPerformed;
        playerInputActions.Movement.Run.canceled += PlayerInputActions_RunCanceled;
        playerInputActions.Movement.Crouch.performed += PlayerInputActions_CrouchPerformed;
        playerInputActions.Movement.Crouch.canceled += PlayerInputActions_CrouchCanceled;
        playerInputActions.Movement.Jump.performed += PlayerInputActions_JumpPerformed;
        playerInputActions.Movement.Jump.canceled += PlayerInputActions_JumpCanceled;
        playerInputActions.Movement.Dash.performed += PlayerInputActions_DashPerformed;
        //PlayerAttacks
        playerInputActions.Attacks.Sword.performed += PlayerInputActions_SwordPerformed;
        playerInputActions.Attacks.AimWithBow.performed += PlayerInputActions_AimWithBowPerformed;
        playerInputActions.Attacks.ShootBow.performed += PlayerInputActions_ShootBowPerformed;
        playerInputActions.Attacks.ThrowGrenade.performed += PlayerInputActions_ThrowGrenadePerformed;
        playerInputActions.Attacks.Axe.performed += PlayerInputActions_AxePerformed;
        //PlayerInventory
        playerInputActions.Inventory.SwitchItem.performed += PlayerInputActions_SwitchItemPerformed;
        playerInputActions.Inventory.TakeItem.performed += PlayerInputActions_TakeItemPerformed;
        playerInputActions.Enable();
    }
    //PlayerMovement
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
    //PlayerAttacks
    void PlayerInputActions_SwordPerformed(InputAction.CallbackContext callbackContext)
    {
        OnSwordPerformed?.Invoke(this, EventArgs.Empty);
    }
    void PlayerInputActions_AimWithBowPerformed(InputAction.CallbackContext callbackContext)
    {
        OnAimWithBowPerformed?.Invoke(this, EventArgs.Empty);
    }
    void PlayerInputActions_ShootBowPerformed(InputAction.CallbackContext callbackContext)
    {
        OnShootBowPerformed?.Invoke(this, EventArgs.Empty);
    }
    void PlayerInputActions_ThrowGrenadePerformed(InputAction.CallbackContext callbackContext)
    {
        OnThrowGrenadePerformed?.Invoke(this, EventArgs.Empty);
    }void PlayerInputActions_AxePerformed(InputAction.CallbackContext callbackContext)
    {
        OnAxePerformed?.Invoke(this, EventArgs.Empty);
    }
    //PlayerInventory
    void PlayerInputActions_SwitchItemPerformed(InputAction.CallbackContext callbackContext)
    {
        OnSwitchItemPerformed?.Invoke(this, EventArgs.Empty);
    }
    void PlayerInputActions_TakeItemPerformed(InputAction.CallbackContext callbackContext)
    {
        OnTakeItemPerformed?.Invoke(this, EventArgs.Empty);
    }
}
