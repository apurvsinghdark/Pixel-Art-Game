using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text text;
    private int scorePlus = 0;
    private ItemPickUp[] itemPick;

    private void Start() {
        itemPick = GameObject.FindObjectsOfType<ItemPickUp>();

        foreach (var item in itemPick)
        {
            item.onPointIncrease += IncreacePoint;
        }
    }

    public void IncreacePoint(Item item)
    {
        if(item != null)
        {
            scorePlus += item.value;
            text.text = "X " + scorePlus.ToString();
        }
        else
        {
            print("No Item");
        }
    }
}
