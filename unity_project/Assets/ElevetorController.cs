using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevetorController : MonoBehaviour {

    int maxY = 119, minY = 80, maxX = 198, minX = 188, stay = 0;
    bool moveDown = true;
    GameObject elevator;

	// Use this for initialization
	void Start () {
		elevator = GameObject.Find("Elevator");
    }
	
	// Update is called once per frame
	void Update () {
        if (stay <= 120)
        {
            stay++;
            return;
        }

        if (moveDown && elevator.transform.position.y > minY)
        {
            float x = 0f;
            if (elevator.transform.position.x < maxX)
                x = -.05f;
                
            elevator.transform.position -= new Vector3(x, .25f, 0.0f);
            return;
        }
        else
        {
            if (moveDown)
                stay = 0;
            moveDown = false;
        }
            
        if (elevator.transform.position.y < maxY)
        {
            float x = 0f;
            if (elevator.transform.position.x > minX)
                x = -.05f;
            elevator.transform.position += new Vector3(x, .25f, 0.0f);
        }
            
        else
        {
            if (!moveDown)
                stay = 0;
            moveDown = true;
        }    
    }
}
