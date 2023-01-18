using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Texture2D cursorTexture;
    public bool mouseOverObject;
    public bool playerClose = false;
    private CursorMode cursorMode = CursorMode.Auto;
    private Vector2 hotSpot = Vector2.zero;
    public int type;

    private void Update()
    {
        if (playerClose && mouseOverObject)
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        else
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
    }

    private void OnMouseEnter()
    {
        mouseOverObject = true;
    }

    private void OnMouseExit()
    {
        mouseOverObject = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerClose = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            playerClose = false;
        }
    }

}
