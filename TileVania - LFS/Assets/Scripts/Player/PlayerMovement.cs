using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 5f;

    [SerializeField] Rigidbody2D myRigidbody2D;
    [SerializeField] BoxCollider2D myFeetCollider2D;
    [SerializeField] Animator myAnimator;
    [SerializeField] PlayerHealth playerHealth;

    [SerializeField] GameObject bullet;
    [SerializeField] Transform gun;

    Vector2 moveInput;
    float gravityScaleAtStart;

    void Start()
    {
        gravityScaleAtStart = myRigidbody2D.gravityScale;
    }

    void Update()
    {
        if (!playerHealth.IsALive) { return; }

        Run();
        FlipSprite();
        ClimbLadder();
    }

    void OnFire(InputValue value)
    {
        if (!playerHealth.IsALive) { return; }

        Instantiate(bullet, gun.position, transform.rotation);
    }

    void OnMove(InputValue value)
    {
        if (!playerHealth.IsALive) { return; }

        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (!playerHealth.IsALive) { return; }

        if (!myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if (value.isPressed)
        {
            myRigidbody2D.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, myRigidbody2D.velocity.y);
        myRigidbody2D.velocity = playerVelocity;

        ChangeRunningAnimation();
    }

    void FlipSprite()
    {
        if (CheckPlayerHorizontalMovement())
        {
            transform.localScale = new Vector2(Mathf.Sign(myRigidbody2D.velocity.x), 1f);
        }
    }

    void ClimbLadder()
    {
        if (!myFeetCollider2D.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myRigidbody2D.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("isClimbing", false);
            return;
        }

        Vector2 climbVelocity = new Vector2(myRigidbody2D.velocity.x, moveInput.y * climbSpeed);
        myRigidbody2D.velocity = climbVelocity;
        myRigidbody2D.gravityScale = 0f;

        ChangeClimbingAnimation();
    }

    bool CheckPlayerHorizontalMovement()
    {
        return Mathf.Abs(myRigidbody2D.velocity.x) > Mathf.Epsilon;
    }

    bool CheckPlayerVerticalMovement()
    {
        return Mathf.Abs(myRigidbody2D.velocity.y) > Mathf.Epsilon;
    }

    void ChangeRunningAnimation()
    {
        myAnimator.SetBool("isRunning", CheckPlayerHorizontalMovement());

        // Another way to do this
        // if (CheckPlayerHorizontalMovement())
        // {
        //     myAnimator.SetBool("isRunning", true);
        // }
        // else
        // {
        //     myAnimator.SetBool("isRunning", false);
        // }
    }

    void ChangeClimbingAnimation()
    {
        myAnimator.SetBool("isClimbing", CheckPlayerVerticalMovement());

        // Another way to do this
        // if (CheckPlayerVerticalMovement())
        // {
        //     myAnimator.SetBool("isClimbing", true);
        // }
        // else
        // {
        //     myAnimator.SetBool("isClimbing", false);
        // }
    }

}