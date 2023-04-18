using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D), typeof(TouchingDirections))]
public class PlayerController : MonoBehaviour
{
    public Animator animator;
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float jumpInpulse = 5f;
    Vector2 moveInput;
    TouchingDirections touchingDirections;
    PlayerHealth playerHealth;

    public float CurrentMoveSpeed { get
        {
            if(IsMoving && !touchingDirections.IsOnWall)
            {
                if(IsRunning)
                {
                    return runSpeed;
                }else
                {
                    return walkSpeed;
                }
            } else
            {
                return 0;
            }
        }
        }

    [SerializeField]
    private bool _isMoving = false;
    public bool IsMoving { get
        {
            return _isMoving;
        } 
        set
            {
                _isMoving = value;
                animator.SetBool("isMoving", value);
            }
    }

    [SerializeField]
    private bool _isRunning = false;
    public bool IsRunning { get
        {
            return _isRunning;
        } 
        set
            {
                _isRunning = value;
                animator.SetBool("isRunning", value);
            }
    }

    public bool _isFacingRight = true;

    public bool isFacingRight { get { return _isFacingRight; } private set {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
    }
    
    }

    Rigidbody2D rb;
   

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections= GetComponent<TouchingDirections>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void FixedUpdate()
    {
        if(playerHealth.IsDead) return;

        rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if(playerHealth.IsDead) return;

        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        setFacingDirection(moveInput);
    }

    private void setFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !isFacingRight)
        {
            isFacingRight = true;
        }
        else if (moveInput.x < 0 && isFacingRight)
        {
            isFacingRight = false;
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if(playerHealth.IsDead) return;

        if (context.started)
        {
            IsRunning = true;
        } else if(context.canceled)
        {
            IsRunning = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(playerHealth.IsDead) return;

        if (context.started && touchingDirections.IsGrounded)
        {
            animator.SetTrigger("jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpInpulse);
        } 
    }
}
