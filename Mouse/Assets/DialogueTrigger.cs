using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueTrigger : MonoBehaviour {

	public Dialogue dialogue;
    public GameObject nextbutton;
   
    public void Start()
    {
        // nextbutton.SetActive(true);
        //   DialogueManager._instance.StartDialogue(dialogue);
        nextbutton.SetActive(false);
        StartCoroutine(wait());

    }
    public void TriggerDialogue ()
	{
		DialogueManager._instance.StartDialogue(dialogue);
        nextbutton.SetActive(true);
        gameObject.SetActive(false);


    }
    IEnumerator wait() {

        yield return new WaitForSeconds(1f);
        DialogueManager._instance.StartDialogue(dialogue);
         nextbutton.SetActive(true);
        gameObject.SetActive(false);
    }

}