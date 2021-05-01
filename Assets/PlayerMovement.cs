﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Public Variables
    public float speed = 10f;
    public float jumpForce = 500f;
    public bool jumping = false;
    public int maxJumps = 2;
    public int jumpCount;
    public float fallMultiplier = 0.3f;
    public float microJumpMultiplier = 0.1f;

    //Private Variables
    Rigidbody2D rb2d;
    float xInput;
    float originalDirection;
    float invoriginalDirection;
    bool jumpPressed;
    bool isFlipped = false;

    // Start is called before the first frame update
    void Start()
    {
        jumpCount = maxJumps;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        originalDirection = transform.localScale.x;
        invoriginalDirection = -1f * transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");

        if (xInput > 0)
        {
            transform.localScale = new Vector2(originalDirection, originalDirection);

            isFlipped = false;
        }
        else if (xInput < 0)
        {
            transform.localScale = new Vector2(invoriginalDirection, originalDirection);

            isFlipped = true;
        }
        if (xInput == 0f)
        {
            if (isFlipped)
            {
                transform.localScale = new Vector2(invoriginalDirection, originalDirection);
            }
            else
            {
                transform.localScale = new Vector2(originalDirection, originalDirection);
            }
        }


        if (Input.GetAxisRaw("Jump") == 1)
        {
            if (jumpPressed && 0 < jumpCount)
            {
                rb2d.velocity = Vector2.zero;
                rb2d.angularVelocity = 0f;
                rb2d.AddForce(new Vector2(0.0f, jumpForce));
                jumpCount--;
                jumpPressed = false;
            }
        }
        else
        {
            jumpPressed = true;
        }
        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }

        else if (rb2d.velocity.y > 0 /* && !jump*/)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (microJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        rb2d.velocity = new Vector2(xInput * speed, rb2d.velocity.y);
    }
}
