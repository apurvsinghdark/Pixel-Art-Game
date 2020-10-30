using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CharacterMovement : MonoBehaviour
{
   [SerializeField] private float speed = 5f;
   [SerializeField] private float jumpSpeed = 2f;
   [SerializeField] private Rigidbody2D rb;

   InputManager inputManager;

   [SerializeField] Transform rayOrigin;
   [Tooltip("Radius For RayCast")][SerializeField] float radius;
   [Tooltip("Layer For GroundCheck")][SerializeField] LayerMask layer;

   public bool IsGrounded {get; private set;}

   private SpriteRenderer spriteRenderer;
   private PlayerAnimator character;

    private void Start() {
        spriteRenderer = transform.GetComponentInChildren<SpriteRenderer>();
        rb = transform.GetComponent<Rigidbody2D>();
        inputManager = GetComponent<InputManager>();

        if(rayOrigin == null)
            rayOrigin.position = transform.position;

        character = PlayerAnimator.instance;
    }

   private void FixedUpdate() {
       
       if(EventSystem.current.IsPointerOverGameObject())
            return;

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
        RaycastHit2D ray = Physics2D.CircleCast(rayOrigin.position, radius, Vector2.down, 0, layer);

        if (ray)
        {
            IsGrounded = true;
            character.animator.SetBool("IsGround",true);
        }
        else
        {
            IsGrounded = false;
            character.animator.SetBool("IsGround",false);
        }
    }

    private void OnDrawGizmos() {
       Gizmos.color = Color.red;
       Gizmos.DrawWireSphere(rayOrigin.position, radius);
   }

   void Movement()
   {
        // float x = Input.GetAxisRaw("Horizontal");
        // float x = SimpleInput.GetAxis("Horizotal");
        // float x = inputManager.MovementInput;

        // float xMove = x * speed * Time.deltaTime;

        //Horizontal Movement
        Vector3 move = inputManager.MovementInput * speed * Time.deltaTime;
        transform.position += move;
        
        #region SpriteFlip at X-axis
        if ( inputManager.MovementInput.x < 0)
        {
            // spriteRenderer.flipX = true;
            transform.rotation = Quaternion.Euler(0, -180f, 0);
        }
        if(inputManager.MovementInput.x > 0)
        {
            // spriteRenderer.flipX = false;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        #endregion

        character.animator.SetFloat("Running", Mathf.Abs(inputManager.MovementInput.x));
   }

   void Jump()
   {
       if(Input.GetButtonDown("Jump") && IsGrounded)
       {
           SoundManager.instance.JumpSound();
           character.animator.SetTrigger("Jump");
           rb.velocity = new Vector2(0, jumpSpeed);
       }
   }

   public void OnClickJump()
    {
        if (IsGrounded)
        {
            SoundManager.instance.JumpSound();
            character.animator.SetTrigger("Jump");
            rb.velocity = new Vector2(0, jumpSpeed);
        }
    }

   void Crouch()
   {
       if (inputManager.MovementInput.y < 0)
       {
           character.animator.SetBool("Crouch",true);
       }
       else if (inputManager.MovementInput.y >= 0)
       {
           character.animator.SetBool("Crouch",false);
       }
   }
}
