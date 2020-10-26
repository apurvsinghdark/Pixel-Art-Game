using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    [SerializeField] GameObject effect;

    public delegate void OnPointIncrease(Item item);
    public OnPointIncrease onPointIncrease;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            if (item.item == ItemId.gold)
            {
                if(onPointIncrease != null)
                    onPointIncrease.Invoke(item);
                
                print("Diamond inc");
                Destroy(this.gameObject);
                Instantiate(effect, transform.position, Quaternion.identity);
            }else
            if (item.item == ItemId.powerUp)
            {
                //Increace in health
                print("health inc");
                Destroy(this.gameObject);
                Instantiate(effect, transform.position, Quaternion.identity);
            }
        }
    }
}
