using UnityEngine;

public class FrogEnemy : Enemy
{
    [SerializeField] float jumpSpeed = 8f;

    [SerializeField] Transform rayOrigin;
    [Tooltip("Radius For GroundCheck")][SerializeField] float rayRadius = 0.39f;
    [Tooltip("Layer For GroundCheck")][SerializeField] LayerMask groundLayer;
    
    [SerializeField] Rigidbody2D rb;

    public bool IsGrounded {get; private set;}

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        rayOrigin.position = transform.position;
    }

    private void Update() {
        Interaction();
        GroundCheck();
    }
    protected override void Interaction()
    {
        base.Interaction();

        if(hit)
        {
            Debug.Log("name " + hit.transform.name);
            Jump();
            FrogShooting.instance.Shoot();
        }else
        {
            EnemyAnimator.instance.animator.SetBool("Jump", false);
        }
    }

     private void Jump()
    {
        if(IsGrounded)
        {
            rb.velocity = new Vector2(0, jumpSpeed);
            EnemyAnimator.instance.animator.SetBool("Jump", true);
        }
    }

    private void GroundCheck()
    {
        RaycastHit2D ray = Physics2D.Raycast(rayOrigin.position, Vector2.down, rayRadius, groundLayer);

        if (ray)
        {
            IsGrounded = true;
            EnemyAnimator.instance.animator.SetBool("IsGround",true);
        }
        else
        {
            IsGrounded = false;
            EnemyAnimator.instance.animator.SetBool("IsGround",false);
        }
    }

    protected override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.color = Color.red;
        Gizmos.DrawRay(rayOrigin.position,Vector3.down * rayRadius);
    }
}
