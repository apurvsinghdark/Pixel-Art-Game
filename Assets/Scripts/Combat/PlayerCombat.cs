using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [Tooltip("PreFeb For Bullet")][SerializeField] GameObject prefeb;
    [SerializeField] Transform firepoint;

     Rigidbody2D rigidbody;

    private void Start() {
    }
    private void FixedUpdate() {
        if(Input.GetButtonDown("Fire1"))
            FireBullet();
    }
    
    
    [SerializeField] float bulletForce = 3f;

    // private void Start() {
    //     
    // }
    // private void FixedUpdate() {
    //     Destroy(this.gameObject, 1f);
    // }
    private void FireBullet()
    {
        Instantiate(prefeb, firepoint.position, Quaternion.identity);
        rigidbody = prefeb.GetComponent<Rigidbody2D>();
        
        rigidbody.AddForce(firepoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
