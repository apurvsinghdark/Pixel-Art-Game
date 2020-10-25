﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
   [SerializeField] private float speed = 5f;
   [SerializeField] private float jumpSpeed = 2f;
   [SerializeField] private Rigidbody2D rb;

   [SerializeField] Transform rayOrigin;
   [Tooltip("Radius For RayCast")][SerializeField] float radius;
   [Tooltip("Layer For GroundCheck")][SerializeField] LayerMask layer;

   public bool IsGrounded {get; private set;}

   private SpriteRenderer spriteRenderer;
   private CharacterAnimation character;

    private void Start() {
        spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
        rb = transform.GetComponent<Rigidbody2D>();

        if(rayOrigin == null)
            rayOrigin.position = transform.position;

        character = CharacterAnimation.instance;
    }

   private void FixedUpdate() {
       Movement();
       Jump();
       Crouch();
   }

   private void Update()
    {
        GroundCheck();
    }

    private void GroundCheck()
    {
        RaycastHit2D ray = Physics2D.Raycast(rayOrigin.position, Vector2.down, radius, layer);

        if (ray)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
        }
    }

    private void OnDrawGizmos() {
       Gizmos.color = Color.red;
       Gizmos.DrawRay(rayOrigin.position,Vector3.down * radius);
   }

   void Movement()
   {
        float x = Input.GetAxisRaw("Horizontal");

        float xMove = x * speed * Time.deltaTime;

        //Vertical Movement
        Vector3 move = new Vector3(xMove,0,0);
        transform.position += move;
        
        #region SpriteFlip at X-axis
        if ( x < 0)
        {
            spriteRenderer.flipX = true;
        }
        if(x > 0)
        {
            spriteRenderer.flipX = false;
        }
        #endregion

        character.animator.SetFloat("Running", Mathf.Abs(x));
   }

   void Jump()
   {
       if(Input.GetButtonDown("Jump") && IsGrounded)
       {
           character.animator.SetTrigger("Jump");
           rb.velocity = new Vector2(0, jumpSpeed);
       }
   }

   void Crouch()
   {
       if (Input.GetKeyDown(KeyCode.C))
       {
           character.animator.SetBool("Crouch",true);
       }
       else if (Input.GetKeyUp(KeyCode.C))
       {
           character.animator.SetBool("Crouch",false);
       }
   }
}