using UnityEngine;
using TMPro;

public class PlayerInventory : MonoBehaviour
{
    private PlayerController controller;
    private PlayerAppearance appearance;
    public int gold = 0;
    public TMP_Text textGold; 
    public TMP_Text textGoldShop; 
    public int maxStackedItems = 64;
    public GameObject inventoryMenu;
    public GameObject inventory;
    public InventorySlot[] inventorySlots;
    public GameObject inventoryItemPrefab;
    public bool isInventoryOpen = false;

    public InventorySlot shirtSlot;
    int selectedSlot = -1;

    private void Start()
    {
        controller = GetComponent<PlayerController>();
        appearance = GetComponent<PlayerAppearance>();
        ChangeSelectedSlot(0);
    }


    private void Update()
    {
        PlayerInput();
        textGold.text = gold.ToString();
        appearance.shirt = (Shirt)shirtSlot.itemInSlot;
    }

    void ChangeSelectedSlot(int newValue)
    {
        if (selectedSlot >= 0)
        {
            inventorySlots[selectedSlot].Deselect();
        }

        inventorySlots[newValue].Select();
        selectedSlot = newValue;
    }

    public bool AddItem(Item item)
    {

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();

            if (itemInSlot != null && itemInSlot.item == item && itemInSlot.count < maxStackedItems && itemInSlot.item.stackable)
            {
                itemInSlot.count++;
                itemInSlot.RefreshCount();
                return true;
            }
        }

        for (int i = 0; i < inventorySlots.Length; i++)
        {
            InventorySlot slot = inventorySlots[i];
            InventoryItem itemInSlot = slot.GetComponentInChildren<InventoryItem>();

            if (itemInSlot == null)
            {
                SpawnNewItem(item, slot);
                return true;
            }
        }

        return false;
    }


    private void SpawnNewItem(Item item, InventorySlot slot)
    {
        GameObject newItemGo = Instantiate(inventoryItemPrefab, slot.transform);
        InventoryItem inventoryItem = newItemGo.GetComponent<InventoryItem>();
        inventoryItem.InitialiseItem(item);
    }

    private void PlayerInput()
    {
        if (Input.inputString != null)
        {
            bool isNumber = int.TryParse(Input.inputString, out int number);
            if (isNumber && number > 0 && number < 10)
            {
                ChangeSelectedSlot(number - 1);
            }
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            controller.freezePlayer = !controller.freezePlayer;

            isInventoryOpen = inventoryMenu.activeSelf;
            inventoryMenu.SetActive(!isInventoryOpen);
            isInventoryOpen = inventoryMenu.activeSelf;
        }
    }
}
