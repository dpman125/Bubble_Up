using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System;
public class PlayerController: MonoBehaviour
{
    public Rigidbody2D rb;
    public float Speed;
    public float MoveDirection;
    public float JumpForce = 5f;
    public bool IsOnGround = false;
    public InputActionReference move;
    public InputActionReference Jump;
    public float test;

    private void Update()
    {
        MoveDirection = move.action.ReadValue<float>();
        transform.Translate(new Vector3(MoveDirection * Time.deltaTime * Speed, 0f, 0f));
        test = rb.linearVelocityY;
    }
    // ensures that input doesent count the same object twice
    private void OnEnable()
    {
        Jump.action.started += Jumping;
    }
    private void OnDisable()
    {
        Jump.action.started -= Jumping;
    }

    // when jumping input is active, then this is called
    private void Jumping(InputAction.CallbackContext obj)
    {
        if (rb.linearVelocityY < 0.001 && rb.linearVelocityY > -0.001)
        rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);  
    }


}
