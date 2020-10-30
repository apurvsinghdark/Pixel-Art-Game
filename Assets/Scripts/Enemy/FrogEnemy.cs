using UnityEngine;

public class FrogEnemy : Enemy
{
    [SerializeField] float jumpSpeed = 8f;

    [SerializeField] Transform rayOrigin;
    [Tooltip("Radius For GroundCheck")][SerializeField] float rayRadius = 0.39f;
    [Tooltip("Layer For GroundCheck")][SerializeField] LayerMask groundLayer;
    
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform Player;
    [SerializeField] EnemyAnimator enemyAnimator;
    FrogShooting frogShooting;

    public bool IsGrounded {get; private set;}

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<EnemyAnimator>();
        frogShooting = GetComponentInChildren<FrogShooting>();
        rayOrigin.position = transform.position;
        Player = FindObjectOfType<CharacterMovement>().transform;
    }

    private void Update() {
        Interaction();
        GroundCheck();
        
        if(Player != null)
            Rotate();
    }
    protected override void Interaction()
    {
        base.Interaction();

        if(hit)
        {
            Debug.Log("name " + hit.transform.name);
            Jump();
            frogShooting.Shoot();
        }else
        {
            enemyAnimator.animator.SetBool("Jump", false);
        }
    }

    private void Jump()
    {
        if(IsGrounded)
        {
            rb.velocity = new Vector2(0, jumpSpeed);
            enemyAnimator.animator.SetBool("Jump", true);
        }
    }

    private void GroundCheck()
    {
        RaycastHit2D ray = Physics2D.Raycast(rayOrigin.position, Vector2.down, rayRadius, groundLayer);

        if (ray)
        {
            IsGrounded = true;
            enemyAnimator.animator.SetBool("IsGround",true);
        }
        else
        {
            IsGrounded = false;
            enemyAnimator.animator.SetBool("IsGround",false);
        }
    }

    private void Rotate()
    {
        float distance = transform.position.x - Player.position.x;

        if (distance > 0)
        {
            transform.rotation = Quaternion.Euler(0,0,0);
        }
        else if (distance < 0)
        {
            transform.rotation = Quaternion.Euler(0,180,0);
        }
    }
    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawRay(rayOrigin.position,Vector3.down * rayRadius);
    }
}
