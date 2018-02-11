using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beatRhythm : MonoBehaviour {

    //Noah's advice
    //"yeah you probably want to make a counter 
    //and have it countdown 
    //and while the value is between say like 2 and 0 
    //if an input is pressed pass = true else pass = false"

    //my ideas
    //maybe i can have a meter with a bar, and when the bar scrawls across and crosses the center, hit a or d
    //maybe i can track the number of button hits in a period of time and then once the time is up it sets the cheese's mix quality

    //or maybe i will combine them
    //have the bar and when it is in a certain range, you hold down the button for stirring
    //each time the key is held in the right area, points go up, and affects the cheese's end quality
    stirBallColl collisionScript;
    public float score = 0;
    public bool stirDone = false;

    public float ballSpeed;
    public Transform ball;
    public Transform bar;

    public float spacing;
    float hitZones = 3;
    public Transform zoneParent;
    public GameObject zonePrefab;
    GameObject createdZone;

    public bool nextA = true;
    public bool nextD = false;

    int stircount = 0;

    void Start () {
		//procedurally generate the hitzones
        for(int i = 0; i < hitZones; i++)
        {
            //sets the position variable
            Vector2 pos = new Vector2(bar.position.x, i * (spacing + .1f) - spacing);
            //then instantiate, first put in the prefab object, then its position, then the rotation, and the transform of the parent object
            createdZone = (GameObject)Instantiate(zonePrefab,pos, Quaternion.Euler(0,0,0), zoneParent);
        }
        //stores the matching script in a variable
        collisionScript = GameObject.Find("stirBall").GetComponent<stirBallColl>();

	}
	
	void Update () {
        //moves the ball at the speed of ball speed, up and down
        ball.position = new Vector2(ball.position.x, ball.position.y + ballSpeed * Time.deltaTime);
        //switch the ball's direction when it reaches the length of the bar
        if(ball.position.y > bar.localScale.y/2 - ball.localScale.x/2 || ball.position.y < -bar.localScale.y/2 + ball.localScale.x/2)
        {
            ballSpeed = ballSpeed * -1;
        }
        //If in the hitzone and A is pressed, adds to some score and switches bools so that D must be pressed next to progress
        if(collisionScript.inZone && nextA && Input.GetKeyDown(KeyCode.A))
        {
            score += 10f;
            nextD = true;
            nextA = false;
            stircount++;
        }
        //If in the hitzone and D is pressed, adds to some score and switches bools so that A must be pressed next to progress
        else if (collisionScript.inZone && nextD && Input.GetKeyDown(KeyCode.D))
        {
            score += 10f;
            nextA = true;
            nextD = false;
            stircount++;
        }
        //If the player has executed the proper action 3 times(appropriate for mozzarella), move on to the next phase
            if (stircount == 3)
        {
            stirDone = true;
        }
	}
}
