using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stirBallColl : MonoBehaviour {
    public bool inZone = false;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hit Zone")
        {
            Debug.Log("On Trigger Stay");
            inZone = true;
        }
        else
        {
            inZone = false;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hit Zone")
        {
            Debug.Log("On Trigger Exit");
            inZone = false;
        }
    }
}
