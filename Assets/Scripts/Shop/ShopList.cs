using UnityEngine;

[CreateAssetMenu(fileName = "New List", menuName = "Shop List")]
public class ShopList : ScriptableObject
{
    public Item[] itemsList;
}
