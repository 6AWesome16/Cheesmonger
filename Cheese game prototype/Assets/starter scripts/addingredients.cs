using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addingredients : MonoBehaviour {

    public bool citricAcidAdded = false;
    public bool lipaseAdded = false;
    public bool rennetAdded = false;


	void Update () {
        //Adds the ingredients one at a time each time you press 'E'

        if (citricAcidAdded == false && Input.GetKeyDown(KeyCode.E))
            //if citric acid is false and you press E, citric acid gets added
        {
            Debug.Log("Citric acid added");
            citricAcidAdded = true;
        }
        else if(citricAcidAdded == true && lipaseAdded == false && Input.GetKeyDown(KeyCode.E))
        {
            //if acid is true and lipase is false and E is pressed, lipase is added
            Debug.Log("Lipase Added");
            lipaseAdded = true;
        }
        else if(citricAcidAdded == true && lipaseAdded == true && rennetAdded == false && Input.GetKeyDown(KeyCode.E))
        {
            //if acid is true and lipase is true and rennet is false and E is pressed, rennet is added
            Debug.Log("Rennet added");
            rennetAdded = true;
        }

	}
}
