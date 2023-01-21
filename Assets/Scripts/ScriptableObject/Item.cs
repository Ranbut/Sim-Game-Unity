using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Item")]
public class Item : ScriptableObject
{
    [Header("Item")]
    public new string name;
    public Sprite icon;
    public ItemType itemType;
    public bool stackable;
    public string description;
    [Space(5)]
    [Header("Value")]
    public int buyValue;
    public int sellValue;

    public enum ItemType
    {
        Tool,
        Hat,
        Shirt,
        Consumable,
        Resource
    }

}
