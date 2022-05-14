using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FakeCursor : MonoBehaviour
{
    public bool invert;
    public float MouseSpeed;
    private Vector3 originalScale;
    private Vector2 worldPosLeftBottom;
    private Vector2 worldPosTopRight;
    private float OrginalSpeed;
    public static FakeCursor Cursor_ins;
    public enum CursorState
    {
    Idle,
    Invert,
    SmallerSlower,
     Bigger,
    Trembling,
    Hard,

}
    public CursorState CurrentState = CursorState.Idle;
    private void Awake()
    {
        Cursor_ins = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        originalScale = transform.localScale;
        OrginalSpeed = MouseSpeed;
        worldPosLeftBottom = Camera.main.ViewportToWorldPoint(Vector2.zero);
        worldPosTopRight = Camera.main.ViewportToWorldPoint(Vector2.one);
         
}

    // Update is called once per frame
    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        InvertMove(invert);
        /*   if (Invert)
           {          
               transform.position = new Vector3(-Input.GetAxis("Mouse X") * MouseSpeed,-Input.GetAxis("Mouse Y") * MouseSpeed, 0) + transform.position;
           }
           else {
               transform.position = new Vector3(Input.GetAxis("Mouse X")* MouseSpeed, Input.GetAxis("Mouse Y")*MouseSpeed,0)+transform.position;
           }*/
        //if (Smaller)
        //{
        //    transform.localScale = originalScale * 0.2f;
        //}
        //if (Bigger)
        //{
        //    transform.localScale = originalScale * 3f;
        //}
        //if (!Smaller && !Bigger) {
        //    transform.localScale = originalScale;
        //}
        //if (Trembling) {
        //    transform.GetChild(0).GetComponent<Animator>().enabled = true;
        //}
        //else
        //    transform.GetChild(0).GetComponent<Animator>().enabled = false;
        //if (Slower)
        //{
        //    MouseSpeed = OrginalSpeed * 0.2f;
        //}
        //else { 

        //}
        /*  if(hard)
                  transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x*0.1f, Camera.main.ScreenToWorldPoint(Input.mousePosition).y*0.1f, 0);
          else{
                  transform.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0);
              } */

        switch (CurrentState) {
            case CursorState.Invert:
                invert = true;
                break;
            case CursorState.Idle:
                break;
            case CursorState.Trembling:
                transform.GetChild(0).GetComponent<Animator>().enabled = true;
                break;
            case CursorState.SmallerSlower:
                transform.localScale = originalScale * 0.1f;
                MouseSpeed = OrginalSpeed * 0.1f;
                break;

        }






        LimitBorder();

}
    public void LimitBorder() {
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, worldPosLeftBottom.x, worldPosTopRight.x),
                                                          Mathf.Clamp(transform.position.y, worldPosLeftBottom.y, worldPosTopRight.y),
                                                          0);
    }
    public void InvertMove(bool Invert){
        if (!Invert)
            transform.position = new Vector3(Input.GetAxis("Mouse X") * MouseSpeed, Input.GetAxis("Mouse Y") * MouseSpeed, 0) + transform.position;
        else {
            transform.position = new Vector3(-Input.GetAxis("Mouse X") * MouseSpeed,-Input.GetAxis("Mouse Y") * MouseSpeed, 0) + transform.position;
        }
    }
    public void SetIdle() {
        CurrentState = CursorState.Idle;
        transform.localScale = originalScale ;
        MouseSpeed = OrginalSpeed;
        invert = false;
    }

}
