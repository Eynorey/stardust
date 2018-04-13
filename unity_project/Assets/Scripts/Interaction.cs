using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour 
{
	GameObject player;
	Camera thirdPersonCam;

	Text interactionDialog;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		thirdPersonCam = GameObject.Find("thirdPersonCam").GetComponent<Camera>();
		interactionDialog = GameObject.Find("Dialoges/InteractionDialog").GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		CheckInteraction();
	}

	void CheckInteraction()
	{
		//Vector3 origin = transform.position;
		//Vector3 direction = transform.forward;
		Vector3 origin = thirdPersonCam.transform.position;
		Vector3 direction = thirdPersonCam.transform.forward;
		float distance = 1f;
		RaycastHit hit;

		if(Physics.Raycast(origin, direction, out hit, distance))
		{
			if(hit.transform.tag == "Log")
			{
				interactionDialog.text = "Log aufnehmen";
				print("hit: " + hit.transform.gameObject.name);
				if(Input.GetKeyDown(KeyCode.E) || Input.GetButtonUp("Button_0"))
				{
					GameObject obj = hit.transform.gameObject;
					HandleLog(obj);
				}
			}

			if(hit.transform.tag == "NPC")
			{
				interactionDialog.text = "Reden";
				if(Input.GetKeyDown(KeyCode.E) || Input.GetButtonUp("Button_0"))
				{
					GameObject obj = hit.transform.gameObject;
					HandleNPC(obj);
				}
			}

			if(hit.transform.tag == "Shippart")
			{
				interactionDialog.text = "Schiffteil aufnehmen";
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
