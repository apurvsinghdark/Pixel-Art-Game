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

        rb = GetComponent<Rigidbody2D>();
        itemPicks = FindObjectsOfType<ItemPickUp>();
        
        foreach(var items in itemPicks)
            items.OnhealthInc += AddHealth;
    }
    void Update()
    {
        if(OnHealthScore != null)
            OnHealthScore((int)Health);
        
        if(rb.velocity.sqrMagnitude > 90)
        {
            //cameraFollow.CanFollow = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            SoundManager.instance.DieSound();
            //GameplayController.instance.Restart();
        }
    }
    
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Enemy")
        {
            GetDamage(3);
        }
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
            SoundManager.instance.DieSound();
            GameManager.instance.Restart();
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
