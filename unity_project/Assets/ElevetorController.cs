using System.Collections;
using UnityEngine;

public class ElevetorController : MonoBehaviour {

    int maxY = 119, minY = 80;
    bool moveDown = true;
    GameObject elevator;
    bool waiting;

	// Use this for initialization
	void Start () {
		elevator = GameObject.Find("Elevator");
    }
	
	// Update is called once per frame
	void Update () {
        if (waiting)
            return;

        var velocity = Vector3.zero;

        Vector3 newPos;
        if (elevator.transform.position.y <= minY + .2f)
        {
            moveDown = false;
            StartCoroutine(Stay());
        }
        if (elevator.transform.position.y >= maxY - .2f)
        {
            moveDown = true;
            StartCoroutine(Stay());
        }

        if (moveDown)
            newPos = new Vector3(198f, 80, elevator.transform.position.z);
        else
            newPos = new Vector3(188f, 119, elevator.transform.position.z);

        elevator.transform.position = Vector3.SmoothDamp(elevator.transform.position, newPos, ref velocity, .1f, 30f); 
    }

    IEnumerator Stay()
    {
        waiting = true;
        yield return new WaitForSeconds(3);
        waiting = false;
    }
}
