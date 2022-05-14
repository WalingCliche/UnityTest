using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepManager : MonoBehaviour
{
    public static StepManager _ins;
    public GameObject ClickTheButtons;
    public GameObject[] pic;
    public int step;
    public GameObject nextbutton;
    public Transform[] pos;
    private bool onetime;
    // Start is called before the first frame update
    void Start()
    {
        _ins = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (step == 3)
        {
            nextbutton.transform.position = pos[1].position;
            nextbutton.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        if (step == 4)
        {
            nextbutton.GetComponent<SpriteRenderer>().color = Color.white;
            nextbutton.transform.position = pos[0].position;
        }
        if (step == 5) {
            foreach (GameObject pic in pic) {
                pic.SetActive(true);
            }
        }
        if (step == 6)
        {
            foreach (GameObject pic in pic)
            {
                pic.SetActive(false);
            }
        }
        if (step == 8)
        {
            nextbutton.transform.position = pos[2].position;
            FakeCursor.Cursor_ins.CurrentState = FakeCursor.CursorState.Invert;
        }
        if (step == 9)
        {
            nextbutton.transform.position = pos[0].position;
        }
        if (step == 10&&!onetime)
        {
            nextbutton.gameObject.SetActive(false);
            ClickTheButtons.SetActive(true);
            onetime = true;
        }
        if (step == 11)
        {
            nextbutton.transform.position = pos[0].position;
        }
        if (step == 12)
        {
            FakeCursor.Cursor_ins.CurrentState = FakeCursor.CursorState.Trembling;
            nextbutton.GetComponent<Animator>().enabled = true;             
        }

    }
}
