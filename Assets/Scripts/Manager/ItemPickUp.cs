using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;
    [SerializeField] GameObject effect;

    public delegate void OnPointIncrease(Item item);
    public OnPointIncrease onPointIncrease;

    public event System.Action<Item> OnhealthInc;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            if (item.item == ItemId.gold)
            {
                if(onPointIncrease != null)
                    onPointIncrease.Invoke(item);
                
                print("Diamond inc");
                SoundManager.instance.PickedUpCoin();
                Destroy(this.gameObject);
                Instantiate(effect, transform.position, Quaternion.identity);
            }else
            if (item.item == ItemId.powerUp)
            {
                if(OnhealthInc != null)
                    OnhealthInc(item);

                print("health inc");
                Destroy(this.gameObject);
                Instantiate(effect, transform.position, Quaternion.identity);
            }
        }
    }
}
