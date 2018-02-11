using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class milktimer : MonoBehaviour {
    public bool isHeated = false;
    public bool countDownDone = false;
    public AudioClip ding;
    private new AudioSource audio;
    public bool dingDone = false;
    public Text timertext;
    float count = 3;

    void Start () {
        audio = GetComponent<AudioSource>();
	}
	
	void Update () {
        if (!isHeated)
        {
            if (Input.GetMouseButtonDown(0))
            {
                //with isheated bool set to false and mouseright is pressed, sets isheated to true
                isHeated = true;
            }
        }
        else if (isHeated)
            //if isheated was false and mouse was pressed
        {
            if (countDownDone == false)
                //if countdown false
            {
                //starts the timer, with one second interval
                StartCoroutine(timer(1));
            }
                //else if countdown true 
            else if (countDownDone == true)
            {
                //dings
                audio.PlayOneShot(ding);
                //resetting the isHeated bool keeps the dings from repeating over the course of the frame
                //just goes once
                //isHeated = false;
                //but I need it to exit the function once isheated is true
                //sets the bool to true
                dingDone = true;
                //use of the statemachine also has the added bonus of keeping the ding from playing multiple times
            }
        }
	}
    //coroutine is not reliant on framerate. happens once each second
    IEnumerator timer(int timeTilNext)
    {
        //changes the timer on the screen
        count = count - Time.deltaTime;
        timertext.text = "" + Mathf.Round(count);
        //for loop, each time it runs it halts the yield return for a second
        //then it does it two more times, then it changes the bool. which dings!
        for (int i = 3; i > 0; i--)
        {        
            yield return new WaitForSeconds(timeTilNext);
        }
        countDownDone = true;
    }
}
