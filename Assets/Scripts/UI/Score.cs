using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    #region  SINGLETON
    public static Score instance;

    private void Awake() {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion
    
    // [SerializeField] private Text dText;
    // [SerializeField] Text hText;
    public Text diamondText;
    public Text HealthText;
    public int scorePlus = 0;
    private int healthUI = 3;
    private ItemPickUp[] itemPick;


    private void Start() {
        itemPick = GameObject.FindObjectsOfType<ItemPickUp>();

        foreach (var item in itemPick)
        {
            item.onPointIncrease += IncreacePoint;
        }
        
        PlayerDie.instance.OnHealthScore += IncreaceHealth;
    }

    public void IncreacePoint(Item item)
    {
        if(item != null)
        {
            scorePlus += item.value;
            diamondText.text = "X " + scorePlus.ToString();
        }
    }
    public void IncreaceHealth(int health)
    {
        healthUI = health;
        HealthText.text = "X " + healthUI.ToString();
    }


    // private void OnEnable() {
    //     dText.text = Score.instance.diamondText.text;
    //     hText.text = Score.instance.HealthText.text;
    //     // dText.text = "X " + Score.instance.diamondText.ToString();
    //     // hText.text = "X " + Score.instance.HealthText.ToString();
    // }
}
