﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovent : MonoBehaviour
{
    public CharacterController controller;

    GameController gameController;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 2;

    public bool canMove;
    public bool detectCollision;

    //jump twice
    private bool doubleJump; // probably doesnt have to be private but what the hell 

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        canMove = true;  
    }

    // Update is called once per frame
    void Update()
    {
        //creates sphere on bottom of character to see if on ground
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if(isGrounded)
        {
            doubleJump = true;
        }

        //v=squareroot(h * -2 * g) this is jump height cause math
        if(Input.GetButtonDown("Jump"))
        {
            if(isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity) * 2;
            }
            else{
                if(doubleJump) //doubled the height of the second jump for super jump 
                {
                    velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity) * 3;
                    doubleJump = false;
                }
            }
            
        }

        velocity.y += gravity * Time.deltaTime;
        //multiple gravity twice acording to formula 
        controller.Move(velocity * Time.deltaTime);
    }
    //conditions and other
    void Death()
    {
        //add audio later
        //audioSource.Stop();
        //audioSource.PlayOneShot(dead);
        gameController.LoseCondition();
    }
}
