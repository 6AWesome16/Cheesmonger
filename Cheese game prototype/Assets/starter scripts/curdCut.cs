using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class curdCut : MonoBehaviour {

    public bool cutDone = false;
    Vector2 mousePos;
    public Transform bar;
    public float startEndRange; //.5 is a good amount of space but is tweekable
    public bool dragStart = false;
    public bool dragMid = false;
    public bool dragEnd = false;

    void Start () {
		//procedurally spawn the start and end points of the line.
        //TO DO LATER
	}
	
	void Update () {
        mousePos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        //converts the mouseposition in pixels to screen values
        //Debug.Log(mousePos);
	}

    void OnMouseDrag()//only works if it is attached to the gameobject that is getting dragged. check
    {
        //confine the mouseDrag to the bar's upper and lower bounds
        if (mousePos.y <= bar.position.y + bar.localScale.y / 2 && mousePos.y >= bar.position.y - bar.localScale.y / 2)
        {
            //trying to confine the start of the mousedrag to the left end of the bar
            if (mousePos.x >= bar.position.x - bar.localScale.x / 2 && mousePos.x <= bar.position.x - bar.localScale.x / 2 + startEndRange)
            {
                Debug.Log("Mouse Being Dragged in Start Point");
                dragStart = true;
            }
            //if mouse held in endpoint/on right end of the bar 
            else if(mousePos.x >= bar.position.x + bar.localScale.x/2 - startEndRange && mousePos.x <= bar.position.x + bar.localScale.x / 2)
            {
                Debug.Log("Mouse Being Dragged in End Point");
                dragEnd = true;
            }
            //If the mouse is within the vertical bounds, but isn't in the start and end points
            //it is therefore in the bar
            else
            {
                Debug.Log("Mouse Being Dragged in the Bar");
                dragMid = true;
            }
        }
        //checks that the mouse was clicked on the bar collider and is being held
        //Debug.Log("Mouse Drag");
    }

    //when mouse is released
    void OnMouseUp()
    {
        //if mouse released on the other side of the cut, after a complete cut
        if(dragStart && dragMid && dragEnd)
        {
            cutDone = true;
        }
        else
        //if a complete cut has not been made, the cut will reset
        {
            dragStart = false;
            dragMid = false;
            dragEnd = false;
        }
    }
}
