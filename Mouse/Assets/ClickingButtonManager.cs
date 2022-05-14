using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickingButtonManager : MonoBehaviour
{
    bool onetime;
    public GameObject nextbutton;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++) {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount!=0)
        transform.GetChild(0).gameObject.SetActive(true);
        if (transform.childCount == 4 && !onetime)
        { DialogueManager._instance.DisplayNextSentence();
            onetime = true;
        }
        if (transform.childCount == 0)
            nextbutton.SetActive(true);
    }
}
