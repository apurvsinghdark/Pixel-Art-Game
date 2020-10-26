using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform position;
    [SerializeField] float radius = 5f;
    [SerializeField] LayerMask layer;

    protected RaycastHit2D hit;

    protected virtual void Interaction()
    {
        hit = Physics2D.CircleCast(position.position, radius, Vector3.forward, 0, layer);
    }

    protected virtual void OnDrawGizmos() {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(position.position,radius);
    }
}
