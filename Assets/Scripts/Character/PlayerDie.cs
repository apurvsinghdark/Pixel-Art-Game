using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour
{
    public GameObject prefeb;
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy")
        {
            Instantiate(prefeb, transform.position, Quaternion.identity);
            Destroy(gameObject);
            Invoke("OnDie", 1f);
        }
    }

    void OnDie()
    {
        Debug.Log("Reload Scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
