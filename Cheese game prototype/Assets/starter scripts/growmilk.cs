using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class growmilk : MonoBehaviour {
    //grabs the lines for the milk
    public GameObject milkheight;
    //grabs the top surface of the milk object
    public GameObject milktop;
    //grabs the bottom surface of the milk object
    public GameObject milkbottom;
    //sets the line's original scale to 0
    float baseScale = 0.0f;
    //the maximum scale height for the milk
    float maxScale = 1f;
    //milktop must start with the same position as the bottom ring
    float topBound = 2.4f;
    //defines a variable to manipulate the rate at which the milk fills up
    //pourRate @ 1 == Normal time, @ pourRate < 1 == slows rate, @ pourRate < 1 == speeds rate up, @ pourRate < 9 == over flows the milk
    public float pourRate;
    public bool isFilled = false;

	void Start () {
        //sets the milkheight(lines) scale to 0
        milkheight.transform.localScale = new Vector2(transform.localScale.x, baseScale);
        //sets the milktop transform to the base
        milktop.transform.position = new Vector2(milkbottom.transform.position.x,milkbottom.transform.position.y);
    }

    void Update () {
        //GOALS OF THIS CODE ACHIEVED HERE
        //scale up milk height
        //translate up milk top
        if (Input.GetKey(KeyCode.Space))
        {
            //limits the height of the milk. when the difference between the milk top and bottom are equal to the topbound value, it stops filling
            if (Mathf.Abs(milktop.transform.position.y - milkbottom.transform.position.y) <= topBound)
            {
                //moves up the milk top according to the pour rate and time
                milktop.transform.position = new Vector2(milktop.transform.position.x, milktop.transform.position.y + topBound * Time.deltaTime * pourRate);
                //works
                //sends a debug log to the computer with milk top position
                //Debug.Log(Mathf.RoundToInt(Mathf.Abs(milktop.transform.position.y - milkbottom.transform.position.y)));
                //goes from 0 to 1 to 2 before the math, goes from 0 to 50 to 100 after math
                //changes the scale of the line according to the pour rate and time
                milkheight.transform.localScale = new Vector2(milkheight.transform.localScale.x, milkheight.transform.localScale.y + maxScale * Time.deltaTime * pourRate);
            }
            //when pot is filled, sets the public bool to true
            else if(Mathf.Abs(milktop.transform.position.y - milkbottom.transform.position.y) >= topBound)
            {
                isFilled = true;
            }
        }
        //resets the milk
        if (Input.GetKeyDown(KeyCode.R))
        {
            //sets the milkheight(lines) scale to 0
            milkheight.transform.localScale = new Vector2(transform.localScale.x, baseScale);
            //sets the milktop transform to the base
            milktop.transform.position = new Vector2(milkbottom.transform.position.x, milkbottom.transform.position.y);
            //public bool resets
            isFilled = false;
        }
	}
}
