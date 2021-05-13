using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float moveInput;

    public Joystick joystick;

    private Rigidbody2D rb;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform feetpos;
    public float checkRadious;
    public LayerMask whatIsGround;
   
   public VectorValue pos;

    public Animator animator;
    

    
    

    private void Start()
    {
        transform.position = pos.initValue;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        moveInput = joystick.Horizontal;
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        Console.WriteLine(moveInput);
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }

        if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
        if(moveInput == 0)
        {
            animator.SetBool("isRunning", false);
        } 
        else{
            animator.SetBool("isRunning", true);
            }
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetpos.position, checkRadious, whatIsGround);
        if(isGrounded == true)
        {
            animator.SetBool("isJumping", false);
        }
        else{
            animator.SetBool("isJumping", true);
        }
    }
    
    public void OnJumpButtonDown()
    {
        if (isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}

