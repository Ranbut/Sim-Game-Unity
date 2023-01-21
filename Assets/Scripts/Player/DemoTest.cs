using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoTest : MonoBehaviour
{
    public PlayerInventory playerInventory;
    public Item[] itemsToPickup;

    public void PickupItem(int id)
    {
        bool result = playerInventory.AddItem(itemsToPickup[id]);
        if (result)
            Debug.Log("Added item to inventory!");
        else
            Debug.Log("Inventory is full!");
    }
}
