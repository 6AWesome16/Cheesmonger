using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stateMachine : MonoBehaviour {

    growmilk fillScript;
    milktimer heatScript;
    addingredients addScript;
    beatRhythm stirScript;
    curdCut cutScript;
    drainCurd drainScript;
    stretchCurd stretchScript;
    //enum is a list of possible states
    //enum is essentially an int
    
    public enum CheeseState
    {
        Fill, //fills the pot with milk
        Heat, //when mouseClicked, timer runs until complete, when a ding sounds
        Add,  //add ingredient to pot
        Stir, //rhythmically stir until exit
        Cut, //chop the curd
        Drain, //drain the curd
        Stretch //stretch the curd
    }
    //the default state
    public CheeseState currentState = CheeseState.Fill;

    void Start () {
        //sets up the bools from other scripts
        fillScript = GameObject.Find("pot with milk").GetComponent<growmilk>();
        heatScript = GameObject.Find("Timer with dings").GetComponent<milktimer>();
        addScript = GameObject.Find("pot with milk").GetComponent<addingredients>();
        stirScript = GameObject.Find("stir bar").GetComponent<beatRhythm>();
        cutScript = GameObject.Find("cut bar").GetComponent<curdCut>();
        drainScript = GameObject.Find("pot with milk").GetComponent<drainCurd>();
        stretchScript = GameObject.Find("curd").GetComponent<stretchCurd>();
        //disable all the bools
        fillScript.enabled = false;
        heatScript.enabled = false;
        addScript.enabled = false;
        stirScript.enabled = false;
        cutScript.enabled = false;
        drainScript.enabled = false;
        stretchScript.enabled = false;
        //sets the default state
        currentState = CheeseState.Fill;
        Debug.Log("Current Script: Fill");
    }

    void Update () {
		if(currentState == CheeseState.Fill)
        {
            //enables the script
            fillScript.enabled = true;
            //when a bool that signifies that the state is complete, set the state to the next state
            if (fillScript.isFilled)
            {
                //disables the current script
                fillScript.enabled = false;
                //changes the state
                Debug.Log("Current Script: Heat");
                currentState = CheeseState.Heat;
            }
        }
        else if(currentState == CheeseState.Heat)
        {
            //enable the script
            heatScript.enabled = true;
            //when the countDownDone bool is true and the ding goes off, set the state to add
            //ding doesn't go off because it checks the bool first
            if (heatScript.dingDone)
            {
                //disables current script
                heatScript.enabled = false;
                //changes the state
                Debug.Log("Current Script: Add");
                currentState = CheeseState.Add;
            }
        }
        else if(currentState == CheeseState.Add)
        {
            addScript.enabled = true;
            if (addScript.rennetAdded)
            {
                addScript.enabled = false;
                Debug.Log("Current Script: Stir");
                currentState = CheeseState.Stir;
            }        
        }
        else if(currentState == CheeseState.Stir)
        {
            stirScript.enabled = true;
            if (stirScript.stirDone)
            {
                stirScript.enabled = false;
                Debug.Log("Current Script: Cut");
                currentState = CheeseState.Cut;
            }
        }
        else if(currentState == CheeseState.Cut)
        {
            cutScript.enabled = true;
            if (cutScript.cutDone)
            {
                cutScript.enabled = false;
                Debug.Log("Current Script: Drain");
                currentState = CheeseState.Drain;
            }
        }
        else if(currentState == CheeseState.Drain)
        {
            drainScript.enabled = true;
            if (drainScript.drainDone)
            {
                drainScript.enabled = false;
                Debug.Log("Current Script: Stretch");
                currentState = CheeseState.Stretch;
            }
        }
        else if(currentState == CheeseState.Stretch)
        {
            stretchScript.enabled = true;
            if (stretchScript.stretched)
            {
                stretchScript.enabled = false;
                Debug.Log("Mozzarella Done!");
            //    Load the Next Scene, with the Cheese Stats intact
            }
        }
    }
}
