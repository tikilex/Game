﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float moveInput;
    public float moveInputKeyboard;

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
        moveInputKeyboard = Input.GetAxis ("Horizontal");//Прекрепил W/A и горизантальные стрелки через юнити
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (moveInputKeyboard != 0)
        {
        rb.velocity = new Vector2(moveInputKeyboard * speed, rb.velocity.y);
        }

        if (facingRight == false && (moveInput > 0 || moveInputKeyboard > 0) && GlobalValues.canMove==true)
        {
            Flip();
        }
        if (facingRight == true && (moveInput < 0 || moveInputKeyboard < 0) && GlobalValues.canMove==true)
        {
            Flip();
        }
        if(moveInput != 0 || moveInputKeyboard != 0 && GlobalValues.canMove==true)  
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        if (Input.GetButton("Jump") == true ){
            OnJumpButtonDown();
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
        if(GlobalValues.canMove==true)
        {
            speed=7;
        }
        else
        {
            speed=0;
        }
    }
    
    public void OnJumpButtonDown()
    {
        if (isGrounded == true && GlobalValues.canMove==true)
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
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.tag == "floatPlatform") //передаем персонажу скорость движущихся платформ
            transform.parent = col.transform;
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.tag == "floatPlatform") //убираем у персонажа скорость платформы
            transform.parent = null;
    }
    void OnCollisionBoxEnter2D(Collision2D col)
    {
        if (col.transform.tag == "physicbox") //передаем персонажу скорость блока
            transform.parent = col.transform;
    }
    void OnCollisionBoxExit2D(Collision2D col)
    {
        if (col.transform.tag == "physicbox") //убираем у персонажа скорость блока
            transform.parent = null;
    }
}

