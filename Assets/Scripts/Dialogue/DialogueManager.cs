using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{

	public TMP_Text nameText;
	public TMP_Text dialogueText;

	private Animator anim;
	private bool dialogueStarted = false;
	private Queue<string> sentences;

	// Use this for initialization
	private void Start()
	{
		anim = GetComponent<Animator>();
		sentences = new Queue<string>();
	}

	private void Update()
    {
		if (anim.GetCurrentAnimatorStateInfo(0).IsName("Message Open"))
		{
			dialogueStarted = true;
		}

		if (dialogueStarted)
			PlayerInput();
    }

    public void StartDialogue(Dialogue dialogue)
	{
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
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	void EndDialogue()
	{
		anim.SetBool("IsOpen", false);
	}

	private void PlayerInput()
	{
		if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
			DisplayNextSentence();
	}
}
