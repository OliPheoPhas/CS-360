using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Declare variables
    private Rigidbody2D rb;
    private Animator animator;
    private bool isPunching;
    private bool isKicking;
    private float punchCooldown = 0.5f;
    private float kickCooldown = 0.8f;

    [SerializeField] private KeyCode upKey;
    [SerializeField] private KeyCode downKey;
    [SerializeField] private KeyCode leftKey;
    [SerializeField] private KeyCode rightKey;
    [SerializeField] private KeyCode punchKey;
    [SerializeField] private KeyCode kickKey;

    [SerializeField] private Sprite[] characterVariations;
    private SpriteRenderer characterRenderer;
    private int currentVariation = 0;

    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float jumpForce = 10.0f;

    private void Start()
    {
        // Initialize components and set initial character variation
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        characterRenderer = GetComponent<SpriteRenderer>();
        SetCharacterVariation(currentVariation);
    }

    private void Update()
    {
        // Handle player movement, actions, and jumping
        MovePlayer();
        HandlePunchAndKick();
        HandleJump();
    }

    private void MovePlayer()
    {
        // Get input for horizontal and vertical movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector2 moveDirection = transform.forward * verticalInput + transform.right * horizontalInput;

        // Update Rigidbody velocity
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, rb.velocity.y);
    }

    private void HandleJump()
    {
        // Check if the player is on the ground and apply jump force if needed
        if (IsGrounded())
        {
            ApplyJumpForce();
        }
    }

    private bool IsGrounded()
    {
        // Perform a raycast check to determine if the player is on the ground
        Bounds bounds = GetComponent<BoxCollider2D>().bounds;
        float rayLength = bounds.extents.y + 0.1f;
        Ray ray = new Ray(bounds.center, Vector2.down);

        return Physics.Raycast(ray, rayLength);
    }

    private void ApplyJumpForce()
    {
        // Apply upward force to simulate jumping
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private void HandlePunchAndKick()
    {
        // Handle punch and kick actions based on user input
        if (Input.GetKeyDown(punchKey) && !isPunching)
        {
            StartPunch();
        }

        if (Input.GetKeyDown(kickKey) && !isKicking)
        {
            StartKick();
        }
    }

    private void StartPunch()
    {
        // Initiate punch animation and set cooldown
        isPunching = true;
        animator.SetTrigger("Punch");
        Invoke("ResetPunch", punchCooldown);
    }

    private void StartKick()
    {
        // Initiate kick animation and set cooldown
        isKicking = true;
        animator.SetTrigger("Kick");
        Invoke("ResetKick", kickCooldown);
    }

    private void ResetPunch()
    {
        // Reset punch state after cooldown
        isPunching = false;
    }

    private void ResetKick()
    {
        // Reset kick state after cooldown
        isKicking = false;
    }

    private void SetCharacterVariation(int variationIndex)
    {
        // Set the active character sprite based on the provided variation index
        if (variationIndex >= 0 && variationIndex < characterVariations.Length)
        {
            characterRenderer.sprite = characterVariations[variationIndex];
        }
    }

    private void SwitchCharacterVariation()
    {
        // Example method to switch to the next character sprite variation
        currentVariation = (currentVariation + 1) % characterVariations.Length;
        SetCharacterVariation(currentVariation);
    }
}