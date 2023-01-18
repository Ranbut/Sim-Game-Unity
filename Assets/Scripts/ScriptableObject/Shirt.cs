using UnityEngine;

[CreateAssetMenu(fileName = "New Shirt", menuName = "Item/Shirt")]
public class Shirt : Item
{
    [Space(5)]
    [Header("Shirt")]
    public Sprite frontSprite;
    public Sprite rightSprite;
    public Sprite leftSprite;
    public Sprite backSprite;
}
