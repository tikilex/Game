using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;
    private float moveInputKeyboard;

    public Joystick joystick;

    private Rigidbody2D rb;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform feetpos;
    public float checkRadious;
    public LayerMask whatIsGround;
    private double CurrentFrame = 0;

    public VectorValue pos;

    public Animator animator;

    private bool wasAirborn = true;

    private int airbornTime = 0;

    public int damagingHeight = 0;
    private void Start()
    {
        transform.position = pos.initValue;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        GlobalValues.playerVolume = PlayerPrefs.GetFloat("PlayerVolume",10);
        GlobalValues.worldVolume = PlayerPrefs.GetFloat("WorldVolume",10);
        SoundManager.worldSrc.volume = GlobalValues.worldVolume * 0.1F;
        SoundManager.playerSrc.volume = GlobalValues.playerVolume * 0.1F;
    }

    private void FixedUpdate()
    {

        moveInput = joystick.Horizontal;
        moveInputKeyboard = Input.GetAxis("Horizontal");//Прекрепил W/A и горизантальные стрелки через юнити
        if(!GlobalValues.UIstateGameplay){
            GlobalValues.canMove = false;
            moveInput = 0;
            moveInputKeyboard = 0;
        }
        if (GlobalValues.canMove == true)

        {
            //Debug.Log(moveInput);
            rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
            if (moveInputKeyboard != 0)
            {
                rb.velocity = new Vector2(moveInputKeyboard * speed , rb.velocity.y);
            }

            if (facingRight == false && (moveInput > 0 || moveInputKeyboard > 0) && GlobalValues.canMove == true)
            {
                Flip();
            }
            if (facingRight == true && (moveInput < 0 || moveInputKeyboard < 0) && GlobalValues.canMove == true)
            {
                Flip();
            }
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
            animator.SetBool("isRunning", false);
        }
        if ( GlobalValues.canMove == true && isGrounded == true && (moveInput!=0 || moveInputKeyboard!=0))
        {
            animator.SetBool("isRunning", true);
            CurrentFrame += 0.4;
            if (CurrentFrame > 5)
            {
                CurrentFrame = 1;
            }
            StartCoroutine(StepSound());
        }
        else
        {
            CurrentFrame = 0;
            animator.SetBool("isRunning", false);
        }

        if (Input.GetButton("Jump") == true)
        {
            OnJumpButtonDown();
        }

        if (isGrounded && wasAirborn)//приземлился
        {
            animator.SetBool("isLanding", true);
            wasAirborn = false;
            if (airbornTime >= damagingHeight)
                SoundManager.PlaySound("longfall");
            else
                SoundManager.PlaySound("drop");
            airbornTime = 0;
        }
        else
        {
            animator.SetBool("isLanding", false);//падает
            if (!isGrounded)
            {
                wasAirborn = true;
                airbornTime++;
                //Debug.Log(airbornTime);
            }
        }
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetpos.position, checkRadious, whatIsGround);
        if (isGrounded == true)
        {
            animator.SetBool("isJumping", false);
        }
        else
        {
            animator.SetBool("isJumping", true);
        }
        if (GlobalValues.canMove == true)
        {
            speed = 7;
        }
        else
        {
            speed = 0;
        }
    }

    public void OnJumpButtonDown()
    {
        if (isGrounded == true && GlobalValues.canMove == true)
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



    IEnumerator StepSound()
    {
        switch (CurrentFrame)
        {
            case 1:
                if (isGrounded)
                    SoundManager.PlaySound("step1");
                yield return new WaitForSeconds(1f);
                break;
            case 2:
                if (isGrounded)
                    SoundManager.PlaySound("step2");
                yield return new WaitForSeconds(1f);
                break;
            case 3:
                if (isGrounded)
                    SoundManager.PlaySound("step3");
                yield return new WaitForSeconds(1f);
                break;
            case 4:
                if (isGrounded)
                    SoundManager.PlaySound("step4");
                yield return new WaitForSeconds(1f);
                break;
            case 5:
                if (isGrounded)
                    SoundManager.PlaySound("step5");
                yield return new WaitForSeconds(1f);
                break;
        }

    }
}

