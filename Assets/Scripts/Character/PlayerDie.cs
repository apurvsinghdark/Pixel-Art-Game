using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDie : MonoBehaviour , IDamageHeal
{
    public static PlayerDie instance;

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
    }
    private int maxHealth = 3;

    public int Health{get; set;}
    public GameObject prefeb;

    public Rigidbody2D rb;
    private ItemPickUp[] itemPicks;

    public event System.Action<int> OnHealthScore;

    private void Start() {
        Health = maxHealth;

        itemPicks = FindObjectsOfType<ItemPickUp>();
        
        foreach(var items in itemPicks)
            items.OnhealthInc += AddHealth;
    }
    void Update()
    {
        OnHealthScore((int)Health);
        
        if(rb.velocity.sqrMagnitude > 60)
        {
            //cameraFollow.CanFollow = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //SoundManager.instance.GameEndSound();
            //GameplayController.instance.Restart();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy")
        {
            GetDamage(1);
        }
    }

    void OnDie()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GetDamage(int damage)
    {
        Health -= damage;

        if(Health <= 0)
        {
            Health = 0;
            Score.instance.HealthText.text = "X " + 0;
            Destroy(gameObject);
            Instantiate(prefeb, transform.position, Quaternion.identity);
            Invoke("OnDie", 1f);
        }
    }

    public void AddHealth(Item heal)
    {
        if (heal != null)
        {
            if ( Health >= maxHealth)
            {
                Health = maxHealth;
                return;
            }
            
            Health += heal.value;
        }
    }
}
