using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour 
{
	private static List<GameObject> Logs = new List<GameObject>();
	private static List<GameObject> Shipparts = new List<GameObject>();

	GameObject player;
	Camera thirdPersonCam;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		thirdPersonCam = GameObject.Find("thirdPersonCam").GetComponent<Camera>();
	}

	/// <summary>
	/// OnTriggerStay is called once per frame for every Collider other
	/// that is touching the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerStay(Collider other)
	{
		CheckInteraction(other);
	}

	void CheckInteraction(Collider hit)
	{
		GameObject obj = hit.transform.gameObject;
		if(obj.tag == "Log")
		{
			print("hit: " + hit.transform.gameObject.name);
			if(Input.GetKeyDown(KeyCode.E) || Input.GetButtonUp("Button_0"))
			{
				HandleLog(obj);
			}
		}

		if(obj.tag == "NPC")
		{
			if(Input.GetKeyDown(KeyCode.E) || Input.GetButtonUp("Button_0"))
			{
				HandleNPC(obj);
			}
		}

		if(obj.tag == "Shippart")
		{
			if(Input.GetKeyDown(KeyCode.E) || Input.GetButtonUp("Button_0"))
			{
				HandleNPC(obj);
			}
		}
	}

	// on interacting with a log
	// open window with content of the log 
	// safe it into file
	void HandleLog(GameObject interactedObj)
	{
		Logs.Add(interactedObj);
		// open dialog
		interactedObj.SetActive(false);
	}

	// on interacting with a NPC
	// talk
	void HandleNPC(GameObject interactedObj)
	{
		// trigger dialog with npc
	}

	// collect ship part
	void HandleShippart(GameObject interactedObj)
	{
		Shipparts.Add(interactedObj);
		// collect
		interactedObj.SetActive(false);
	}
}