using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject prefeb;
    private void OnEnable() {
        Invoke("DestroyBullet",2f);
    }

    void DestroyBullet()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.transform.position = Vector2.zero;
        gameObject.transform.rotation = Quaternion.Euler(0,0,0);
        gameObject.SetActive(false);
    }

    private void OnDisable() {
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" )
        {
            PlayerDie.instance.GetDamage(1);
            Instantiate(prefeb, transform.position, Quaternion.identity);
            DestroyBullet();
        }
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Instantiate(prefeb, transform.position, Quaternion.identity);
            DestroyBullet();
        }
    }
}
