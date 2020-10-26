using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] Rigidbody2D rigidbody;

    [SerializeField] float bulletForce = 3f;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate() {
        rigidbody.AddForce(Vector2.right * bulletForce, ForceMode2D.Impulse);
        Destroy(this.gameObject, 1f);
    }
}
