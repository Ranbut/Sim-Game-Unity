using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    private PlayerInventory playerInventory;
    public Item item;
    public Image icon;
    public TMP_Text textName;
    public TMP_Text textValue;

    private void Start()
    {
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();

        icon.sprite = item.icon;
        textName.text = item.name;
        textValue.text = item.buyValue.ToString();
    }

    public void BuyItem()
    {
        if (playerInventory.gold >= item.buyValue)
        {
            playerInventory.AddItem(item);
            playerInventory.gold -= item.buyValue;
        }
        else
            Debug.Log("Gold insufficient!");
        
    }
}
