using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Pixel Art Game/Item", order = 0)]
public class Item : ScriptableObject {
    
    public string name = "new item";
    public ItemId item;
    public bool powerUp;

}

public enum ItemId {gold , powerUp}

