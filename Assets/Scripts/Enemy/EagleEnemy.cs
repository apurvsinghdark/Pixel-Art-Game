using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleEnemy : Enemy
{
    [SerializeField] Transform rightPosition;
    [SerializeField] Transform leftPosition;
    Vector3 nextPosition;

    SpriteRenderer spriteRenderer;

    [SerializeField] float speed;
    
   
    private void Start() {
        nextPosition = leftPosition.position;
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void Update() {
        Interaction();

        Moving();
    }

    protected override void Interaction()
    {
        base.Interaction();

        if(hit)
        {
            Debug.Log("name " + hit.transform.name);
            EagleShooting.instance.Shoot();
        }else
        {
            //EnemyAnimator.instance.animator.SetBool("Jump", false);
        }
    }

    void Moving()
    {
        if(transform.position == rightPosition.position)
        {
            nextPosition = leftPosition.position;
            // transform.localRotation = Quaternion.Euler(0,0,0);
            spriteRenderer.flipX = false;
        }else
        if(transform.position == leftPosition.position)
        {
            nextPosition = rightPosition.position;
            // transform.localRotation = Quaternion.Euler(0,-180,0);
            spriteRenderer.flipX = true;
        }
    
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
    }

}
