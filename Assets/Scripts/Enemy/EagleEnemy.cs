using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleEnemy : Enemy
{
    [SerializeField] Transform rightPosition;
    [SerializeField] Transform leftPosition;
    Vector3 nextPosition;

    SpriteRenderer spriteRenderer;
    EagleShooting eagleShooting;

    [SerializeField] float speed;
    
   
    private void Start() {
        nextPosition = leftPosition.position;
        spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        eagleShooting = transform.GetChild(1).GetComponent<EagleShooting>();
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
            eagleShooting.Shoot();
        }
    }

    void Moving()
    {
        if(transform.position == rightPosition.position)
        {
            nextPosition = leftPosition.position;
            spriteRenderer.flipX = false;
        }else
        if(transform.position == leftPosition.position)
        {
            nextPosition = rightPosition.position;
            spriteRenderer.flipX = true;
        }
    
        transform.position = Vector3.MoveTowards(transform.position, nextPosition, speed * Time.deltaTime);
    }

}
