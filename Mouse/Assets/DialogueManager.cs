using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueManager : MonoBehaviour
{

	//public Text nameText;
//	public Text dialogueText;
	public TMP_Text  dialogueText;

	public Animator animator;

	private Queue<string> sentences;

	private int totalcount;
	public static DialogueManager _instance;
	private void Awake()
    {
		_instance = this;

	}
    // Use this for initialization
    void Start()
	{
		sentences = new Queue<string>();


	}

	public void StartDialogue(Dialogue dialogue)
	{
		//	animator.SetBool("IsOpen", true);

		//	nameText.text = dialogue.name;

		sentences.Clear();

		foreach (string sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
		totalcount = sentences.Count;	
		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		FakeCursor.Cursor_ins.SetIdle();
		StepManager._ins.step = totalcount - sentences.Count;
		//Debug.Log(sentences.Count);
		if (sentences.Count == 0)
		{
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
	//	animator.SetBool("IsOpen", false);
	}

}

