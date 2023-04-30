using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
    Camera mainCamera;
    
    public Vector3 respawnPoint;
    public int respawnCash;

    public float CurrentMoveSpeed {
        get {
            if (IsMoving && !touchingDirections.IsOnWall) {
                if (IsRunning) {
                    return runSpeed;
                } else {
                    return walkSpeed;
                }
            } else {
                return 0;
            }
        }
    }

    [SerializeField]
    private bool _isMoving = false;
    public bool IsMoving {
        get {
            return _isMoving;
        } set {
            _isMoving = value;
            animator.SetBool("isMoving", value);
        }
    }

    [SerializeField]
    private bool _isRunning = false;
    public bool IsRunning {
        get {
            return _isRunning;
        } set {
            _isRunning = value;
            animator.SetBool("isRunning", value);
        }
    }

    public bool _isFacingRight = true;

    public bool isFacingRight {
        get { return _isFacingRight; } 
        private set {
            if (_isFacingRight != value) {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    }

    Rigidbody2D rb;

    void Start()
    {
        // Get the stored values of the variables from PlayerPrefs
        if (PlayerPrefs.GetFloat("PlayerPosX") != 0 && PlayerPrefs.GetFloat("PlayerPosY") != 0) {
            float playerPosX = PlayerPrefs.GetFloat("PlayerPosX");
            float playerPosY = PlayerPrefs.GetFloat("PlayerPosY");
            playerHealth.pickupQuantity = PlayerPrefs.GetInt("Cash");

            // Set the values of the variables
            transform.position = new Vector3(playerPosX, playerPosY, 0);
            PlayerPrefs.DeleteAll();
        }
    }  

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        playerHealth = GetComponent<PlayerHealth>();
        mainCamera = Camera.main;
    }

    private void FixedUpdate() {
        if (playerHealth.IsDead) return;

        rb.velocity = new Vector2(moveInput.x * CurrentMoveSpeed, rb.velocity.y);

        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        if (mousePos.x < transform.position.x && isFacingRight) {
            isFacingRight = false;
        } else if (mousePos.x >= transform.position.x && !isFacingRight) {
            isFacingRight = true;
        }

    }

    public void OnMove(InputAction.CallbackContext context) {
        if (playerHealth.IsDead) return;

        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

    }

    public void OnRun(InputAction.CallbackContext context) {
        if (playerHealth.IsDead) return;

        if (context.started) {
            IsRunning = true;
        } else if (context.canceled) {
            IsRunning = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context) {
        if (playerHealth.IsDead) return;

        if (context.started && touchingDirections.IsGrounded) {
            animator.SetTrigger("jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpInpulse);
        } 
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("RespawnPoints"))
        {
            respawnPoint = transform.position;
            respawnCash = playerHealth.pickupQuantity;
        }
    }

    public void Respawn()
    {
        // Store the values of the variables in PlayerPrefs
        PlayerPrefs.SetFloat("PlayerPosX", respawnPoint.x);
        PlayerPrefs.SetFloat("PlayerPosY", respawnPoint.y);
        PlayerPrefs.SetInt("Cash", respawnCash);

        // Reload the scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}