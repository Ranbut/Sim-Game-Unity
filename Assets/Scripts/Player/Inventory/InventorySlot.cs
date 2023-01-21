using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IDropHandler
{
    public Image selector;
    public Color selectedColor, notSelectedColor;

    public void Awake()
    {
        Deselect();
    }

    public void Select()
    {
        selector.color = selectedColor;
    }

    public void Deselect()
    {
        selector.color = notSelectedColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0) {
        GameObject dropped = eventData.pointerDrag;
        InventoryItem draggableItem = dropped.GetComponent<InventoryItem>();
        draggableItem.parentAfterDrag = transform;
        }
    }
}
