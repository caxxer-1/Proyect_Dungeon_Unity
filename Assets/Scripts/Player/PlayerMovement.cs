using System;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    //Movement
    float speed = 10;
    float rotationSpeed = 15;
    float runSpeedMultiplier = 2;
    float crouchSpeedMultiplier = .5f;
    bool crouching = false;
    bool running = false;
    //Jump
    LayerMask floorLayerMask = 1 << 3;
    bool jumpAsked = false;
    bool jumpButtonPressed = false;
    float jumpForce = 10;
    float jumpFallForce = 3;
    float satisfyingFallMultiplier = 4;
    //Dash
    bool dashAsked = false;
    bool dashing = false;
    float dashImpulse = 20;
    void Start()
    {
        InputManager.Instance.OnRunPerformed += InputManager_Run;
        InputManager.Instance.OnRunCanceled += InputManager_StopRun;
        InputManager.Instance.OnCrouchPerformed += InputManager_Crouch;
        InputManager.Instance.OnCrouchCanceled += InputManager_StopCrouch;
        InputManager.Instance.OnJumpPerformed += InputManager_Jump;
        InputManager.Instance.OnJumpCanceled += InputManager_StopJump;
        InputManager.Instance.OnDashPerformed += InputManager_Dash;
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (dashAsked && !dashing) ManageDash();
        if (!dashing) ManageMovement();
        ManageRotation();
        if (jumpAsked) ManageJump();
        ManageJumpPhysics();
    }
    void ManageMovement()
    {
        Vector2 inputVector = InputManager.Instance.GetWalkInputVectorNormalized();
        if (inputVector.magnitude < 0.01f) return;
        float currentSpeed = speed;
        if (running) currentSpeed = speed * runSpeedMultiplier;
        else if (crouching) currentSpeed = speed * crouchSpeedMultiplier;
        rb.linearVelocity = new Vector3(inputVector.x * currentSpeed, rb.linearVelocity.y, inputVector.y * currentSpeed);
    }
    void ManageRotation()
    {
        Vector2 inputVector = InputManager.Instance.GetWalkInputVectorNormalized();
        if (inputVector.magnitude < 0.01f) return;
        Vector3 rotateDir = new Vector3(inputVector.x, 0, inputVector.y);
        Quaternion lookTarget = Quaternion.LookRotation(rotateDir);
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, lookTarget, rotationSpeed * Time.fixedDeltaTime));
    }
    void ManageJump()
    {
        jumpAsked = false;
        if (!CheckFloor()) return;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
    }
    void ManageJumpPhysics()
    {   
        if (rb.linearVelocity.y < 0) rb.linearVelocity += Vector3.up * Physics.gravity.y * (satisfyingFallMultiplier - 1) * Time.fixedDeltaTime;
        else if (rb.linearVelocity.y > 0 && !jumpButtonPressed) rb.linearVelocity += Vector3.up * Physics.gravity.y * (jumpFallForce - 1) * Time.fixedDeltaTime;
    }
    void ManageDash()
    {
        dashAsked = false;
        rb.linearVelocity = new Vector3(dashImpulse * transform.forward.x, rb.linearVelocity.y, dashImpulse * transform.forward.z);
        dashing = true;
        StartCoroutine(DashVelocityManteinance());
    }
    IEnumerator DashVelocityManteinance()
    {
        yield return new WaitForSeconds(.1f);
        dashing = false;
    }
    bool CheckFloor()
    {
        return Physics.CheckSphere(rb.position + Vector3.up * .9f, 1, floorLayerMask);
    }
    void InputManager_Run(object sender, EventArgs e)
    {
        running = true;
    }
    void InputManager_StopRun(object sender, EventArgs e)
    {
        running = false;
    }
    void InputManager_Crouch(object sender, EventArgs e)
    {
        crouching = true;
    }
    void InputManager_StopCrouch(object sender, EventArgs e)
    {
        crouching = false;
    }
    void InputManager_Jump(object sender, EventArgs e)
    {
        jumpAsked = true;
        jumpButtonPressed = true;
    }
    void InputManager_StopJump(object sender, EventArgs e)
    {
        jumpButtonPressed = false;
    }
    void InputManager_Dash(object sender, EventArgs e)
    {
        dashAsked = true;
    }
    void OnDestroy()
    {
        InputManager.Instance.OnRunPerformed -= InputManager_Run;
        InputManager.Instance.OnRunCanceled -= InputManager_StopRun;
        InputManager.Instance.OnCrouchPerformed -= InputManager_Crouch;
        InputManager.Instance.OnCrouchCanceled -= InputManager_StopCrouch;
        InputManager.Instance.OnJumpPerformed -= InputManager_Jump;
        InputManager.Instance.OnJumpCanceled -= InputManager_StopJump;
        InputManager.Instance.OnDashPerformed -= InputManager_Dash;
    }
}
