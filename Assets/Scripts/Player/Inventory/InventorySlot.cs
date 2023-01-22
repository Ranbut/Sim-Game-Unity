using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    private Image image;
    public Color selectedColor, notSelectedColor;
    public Item itemInSlot;

    private void Awake()
    {
        image = GetComponent<Image>();
        Deselect();
    }

    public void Select()
    {
        image.color = selectedColor;
    }

    public void Deselect()
    {
        image.color = notSelectedColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0) {
            GameObject dropped = eventData.pointerDrag;
            InventoryItem draggableItem = dropped.GetComponent<InventoryItem>();
            itemInSlot = draggableItem.item;
            draggableItem.parentAfterDrag = transform;
        }
    }
}
