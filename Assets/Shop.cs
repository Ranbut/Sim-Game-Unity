using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public ShopList shopList;
    public GameObject itemPrefab;
    public GameObject shopMenu;
    public GameObject shopContent;
    public List<GameObject> itemsShop;

    private void Update()
    {
        bool isOpen = shopMenu.activeSelf;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpen)
                CloseShop();
            else
                OpenShop();
        }
    }

    public void OpenShop()
    {
        shopMenu.SetActive(true);
        for (int i = 0; i < shopList.itemsList.Length; i++)
        {
            GameObject item = Instantiate(itemPrefab, shopContent.transform);
            item.GetComponent<ShopItem>().item = shopList.itemsList[i];
            itemsShop.Add(item);
        }
    }

    public void CloseShop()
    {
        for (int i = 0; i < itemsShop.Count; i++)
        {
            Destroy(itemsShop[i]);
        }
        itemsShop.Clear();
        shopMenu.SetActive(false);
        PlayerController playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        playerController.freezePlayer = false;
    }

}
