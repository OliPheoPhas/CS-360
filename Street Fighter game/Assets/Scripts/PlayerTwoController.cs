using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 2000f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private Collider2D col;
    private bool isGrounded;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();

        // Punch every 5 seconds
        InvokeRepeating("PerformPunch", 0f, 5f);

        // Stay upright
        rb.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PerformPunch()
    {
        // Trigger the "Punch" animation
        animator.SetTrigger("Punch");

        // Deal damages once its added in
    }
}
