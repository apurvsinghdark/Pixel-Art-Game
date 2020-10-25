using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item item;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            if (item.item == ItemId.gold)
            {
                //Increase on ui
                print("Diamond inc");
                Destroy(this.gameObject);
            }else
            if (item.item == ItemId.powerUp)
            {
                //Increace in health
                print("health inc");
                Destroy(this.gameObject);
            }
        }
    }
}
