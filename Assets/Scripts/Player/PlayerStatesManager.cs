using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStatesManager : MonoBehaviour
{
    //Movement
    PlayerMovementState playerMovementState = PlayerMovementState.Walking;
    public PlayerMovementState GetPlayerMovementState()
    {
        return playerMovementState;
    }
    public enum PlayerMovementState
    {
        Walking,
        Running,
        Crouching
    }
    //Inventory
    PlayerInventoryState playerCurrentItem = PlayerInventoryState.Sword;
    public PlayerInventoryState GetPlayerInventoryState()
    {
        return playerCurrentItem;
    }
    public enum PlayerInventoryState
    {
        Sword,
        Axe,
        Grenade,
        EnumCount
    }
    void Start()
    {
        //Movement
        InputManager.Instance.OnRunPerformed += InputManager_Run;
        InputManager.Instance.OnRunCanceled += InputManager_StopRun;
        InputManager.Instance.OnCrouchPerformed += InputManager_Crouch;
        InputManager.Instance.OnCrouchCanceled += InputManager_StopCrouch;
        //Inventory
        InputManager.Instance.OnSwitchItemPerformed += InputManager_SwitchItem;
    }
    //Movement
    void InputManager_Run(object sender, EventArgs e)
    {
        playerMovementState = PlayerMovementState.Running;
    }
    void InputManager_StopRun(object sender, EventArgs e)
    {
        playerMovementState = PlayerMovementState.Walking;
    }
    void InputManager_Crouch(object sender, EventArgs e)
    {
        playerMovementState = PlayerMovementState.Crouching;
    }
    void InputManager_StopCrouch(object sender, EventArgs e)
    {
        playerMovementState = PlayerMovementState.Walking;
    }
    //Inventory
    void InputManager_SwitchItem(object sender, EventArgs e)
    {
        if (playerCurrentItem + (int)Mouse.current.scroll.y.ReadValue() < 0 || playerCurrentItem + (int)Mouse.current.scroll.y.ReadValue() > PlayerInventoryState.EnumCount-1)
        playerCurrentItem = Mouse.current.scroll.y.ReadValue() > 0 ? 0 : PlayerInventoryState.EnumCount-1;
        else playerCurrentItem += (int)Mouse.current.scroll.y.ReadValue();
        Debug.Log((int)playerCurrentItem + " " + playerCurrentItem.ToString());
    }
    void OnDestroy()
    {
        InputManager.Instance.OnRunPerformed -= InputManager_Run;
        InputManager.Instance.OnRunCanceled -= InputManager_StopRun;
        InputManager.Instance.OnCrouchPerformed -= InputManager_Crouch;
        InputManager.Instance.OnCrouchCanceled -= InputManager_StopCrouch;
    }
}
