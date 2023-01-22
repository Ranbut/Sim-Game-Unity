using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

	public Dialogue dialogue;
    private Interactable interactable;
    private Shop shop;
    private bool dialogueStarted = false;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
        shop = GetComponent<Shop>();
    }

    private void Update()
    {
        PlayerInput();
    }

    public void TriggerDialogue()
	{
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>(); ;
        dialogueManager.shop = shop;
        dialogueManager.typeOfMessage = interactable.type;
        dialogueManager.controller = interactable.controller;
        dialogueManager.StartDialogue(dialogue);
    }

    private void PlayerInput()
    {
        if (interactable.playerClose && interactable.mouseOverObject)
        {
            if (Input.GetMouseButtonDown(1) && !dialogueStarted)
            {
                TriggerDialogue();
            }
        }
    }

}