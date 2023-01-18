using UnityEngine;

public class Item : ScriptableObject
{
    [Header("Item")]
    public new string name;
    public string description;
    [Space(5)]
    [Header("Value")]
    public int buyValue;
    public int sellValue;
}
