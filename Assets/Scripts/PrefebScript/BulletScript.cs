using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject prefeb;
    private void OnEnable() {
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.right * 7f;

        Invoke("DestroyBullet",2f);
    }

    void DestroyBullet()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable() {
        CancelInvoke();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
            Instantiate(prefeb, transform.position, Quaternion.identity);
            DestroyBullet();
        }
    }
}
