using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDie : MonoBehaviour
{
    public GameObject prefeb;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Instantiate(prefeb, transform.position, Quaternion.identity);
        }
    }
}
