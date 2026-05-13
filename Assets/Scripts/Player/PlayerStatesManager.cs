using System;
using UnityEngine;

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
    //Attacks
        //Melee
        PlayerMeleeAttackState playerMeleeAttackState = PlayerMeleeAttackState.Sword;
        public PlayerMeleeAttackState GetPlayerMeleeAttackState()
        {
            return playerMeleeAttackState;
        }
        public enum PlayerMeleeAttackState
        {
            Sword,
            Maze
        }
    void Start()
    {
        InputManager.Instance.OnRunPerformed += InputManager_Run;
        InputManager.Instance.OnRunCanceled += InputManager_StopRun;
        InputManager.Instance.OnCrouchPerformed += InputManager_Crouch;
        InputManager.Instance.OnCrouchCanceled += InputManager_StopCrouch;
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
    void OnDestroy()
    {
        InputManager.Instance.OnRunPerformed -= InputManager_Run;
        InputManager.Instance.OnRunCanceled -= InputManager_StopRun;
        InputManager.Instance.OnCrouchPerformed -= InputManager_Crouch;
        InputManager.Instance.OnCrouchCanceled -= InputManager_StopCrouch;
    }
}
