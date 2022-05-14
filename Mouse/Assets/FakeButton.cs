using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeButton : MonoBehaviour
{
    SpriteRenderer sp;
    bool entering;
    // Start is called before the first frame update
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)&&entering)
        {
            StartCoroutine(TurnBlack());
            DialogueManager._instance.DisplayNextSentence();
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        sp.color = Color.gray;
        if (collision.CompareTag("Player"))
        {
            sp.color = Color.gray;
            entering = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        sp.color = Color.white;
        entering = false;
    }
   IEnumerator TurnBlack() {
        sp.color = Color.black;
        yield return new WaitForSeconds(0.02f);
        sp.color = Color.white;
    }

}
