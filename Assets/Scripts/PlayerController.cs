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
    public bool IsOnGround;
    public InputActionReference move;
    public InputActionReference Jump;
    public float groundCheckDistance = 0.1f; // Distance from ground
    public LayerMask groundLayer; // Layer mask for ground objects
    public Animator Animator;

    private void Update()
    {

        Animator.SetFloat("Speed", Mathf.Abs(MoveDirection));
        MoveDirection = move.action.ReadValue<float>();
        if (MoveDirection > 0)
        {
            transform.localScale = new Vector3(-.5f, .5f, 1f);
        }
        else if (MoveDirection < 0)
        {
            transform.localScale = new Vector3(.5f, .5f, 1f);
        }
        transform.Translate(new Vector3(MoveDirection * Time.deltaTime * Speed, 0f, 0f));

        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        RaycastHit2D hitDiagL = Physics2D.Raycast(transform.position, new Vector2(-.25f, -1f).normalized, groundCheckDistance, groundLayer);
        RaycastHit2D hitDiagR = Physics2D.Raycast(transform.position, new Vector2(.25f, -1f).normalized, groundCheckDistance, groundLayer);
        if (hit.collider != null || hitDiagL.collider != null || hitDiagR.collider != null)
        {
            IsOnGround = true;
            Animator.SetBool("IsJumping", false);
        }
        else
        {
            IsOnGround = false;
            Animator.SetBool("IsJumping", true);
        }
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
        //rb.linearVelocityY < 0.001 && rb.linearVelocityY > -0.001
        if (IsOnGround)
        {
            AudioSource audio = GetComponent<AudioSource>();

            audio.Play();
            // jump
            rb.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
            
        }
        
    }

}
