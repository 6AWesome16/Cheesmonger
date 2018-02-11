using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stretchCurd : MonoBehaviour {
    public Transform curd;
    public bool stretched = false;
    public float stretchRate;
	
	void Update () {
        //limit how far the curd can stretch wide
        if (curd.localScale.x <= 2f)
        {
            if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            {
                curd.localScale = new Vector2(curd.localScale.x + stretchRate * Time.deltaTime, curd.localScale.y);
            }
        }
        //limit how far the curd can stretch tall
        else if (curd.localScale.y <= 2f)
        {
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
            {
                curd.localScale = new Vector2(curd.localScale.x, curd.localScale.y + stretchRate * Time.deltaTime);
            }
        }
        //once it has reached the limit, end the cheesemaking process
        else
        {
            stretched = true;
        }
	}
}
