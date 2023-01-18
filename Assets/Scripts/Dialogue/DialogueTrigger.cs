using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{

	public Dialogue dialogue;
    private Interactable interactable;
    private bool dialogueStarted = false;

    private void Start()
    {
        interactable = GetComponent<Interactable>();
    }

    private void Update()
    {
        PlayerInput();
    }

    public void TriggerDialogue()
	{
        FindObjectOfType<DialogueManager>().typeOfMessage = interactable.type;
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
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