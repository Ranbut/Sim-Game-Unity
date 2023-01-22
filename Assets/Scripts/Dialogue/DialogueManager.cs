using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

	public TMP_Text nameText;
	public TMP_Text dialogueText;
	public TMP_Text messageText;
	public int typeOfMessage = -1;
	public PlayerController controller;
	public GameObject messageBox;
	public GameObject dialogueBox;

	private Animator anim;
	[HideInInspector]public Shop shop;

	private bool dialogueStarted = false;
	private Queue<string> sentences;

	// Use this for initialization
	private void Start()
	{
		sentences = new Queue<string>();
	}

	private void Update()
    {
		if(typeOfMessage == 0)
        {
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("Message Open"))
				dialogueStarted = true;
		}
		else if (typeOfMessage == 1) 
		{
			if (anim.GetCurrentAnimatorStateInfo(0).IsName("Dialogue Open"))
				dialogueStarted = true;
		}

		if (dialogueStarted)
			PlayerInput();
    }

    public void StartDialogue(Dialogue dialogue)
	{
		if (typeOfMessage == 0)
			anim = messageBox.GetComponent<Animator>();
		else if (typeOfMessage == 1)
			anim = dialogueBox.GetComponent<Animator>();

		controller.freezePlayer = true;
		anim.SetBool("IsOpen", true);

		nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}

		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			dialogueStarted = false;
			EndDialogue();
			return;
		}

		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		if (typeOfMessage == 1)
			dialogueText.text = "";
		else if (typeOfMessage == 0)
			messageText.text = "";

		foreach (char letter in sentence.ToCharArray())
		{
			if (typeOfMessage == 1)
				dialogueText.text += letter;
			else if (typeOfMessage == 0)
				messageText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		anim.SetBool("IsOpen", false);
		if (shop == null)
			controller.freezePlayer = false;
		else
			shop.OpenShop();
	}

	private void PlayerInput()
	{
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
			DisplayNextSentence();
	}
}
