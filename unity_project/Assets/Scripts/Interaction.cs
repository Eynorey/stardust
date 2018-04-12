using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour 
{
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		CheckInteraction();
	}

	void CheckInteraction()
	{
		Vector3 origin = transform.position;
		Vector3 direction = transform.forward;
		float distance = 1f;
		RaycastHit hit;

		if(Physics.Raycast(origin, direction, out hit, distance))
		{
			if(hit.transform.tag == "Log")
			{
				if(Input.GetKeyDown(KeyCode.E) || Input.GetButtonUp("Button_0"))
				{
					GameObject obj = hit.transform.gameObject;
					HandleLog(obj);
				}
			}

			if(hit.transform.tag == "NPC")
			{
				if(Input.GetKeyDown(KeyCode.E) || Input.GetButtonUp("Button_0"))
				{
					GameObject obj = hit.transform.gameObject;
					HandleNPC(obj);
				}
			}
		}
	}

	// on interacting with a log
	// open window with content of the log 
	// safe it into file
	void HandleLog(GameObject interactedObj)
	{

	}

	// on interacting with a NPC
	// talk
	void HandleNPC(GameObject interactedObj)
	{

	}
}
