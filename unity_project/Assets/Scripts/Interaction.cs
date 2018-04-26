using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour 
{
	GameObject player;
	Camera thirdPersonCam;
	DialogTrigger startInteraction;
	AnimationController animationController;
	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
		animationController = (AnimationController)player.GetComponent("AnimationController");
		thirdPersonCam = GameObject.Find("thirdPersonCam").GetComponent<Camera>();

		startInteraction = (DialogTrigger) player.GetComponent<DialogTrigger>();
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

	/// <summary>
	/// OnTriggerExit is called when the Collider other has stopped touching the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerExit(Collider other)
	{
		startInteraction.enabled = false;
	}

	void CheckInteraction(Collider hit)
	{
		GameObject obj = hit.transform.gameObject;
		if(obj.tag == "Log")
		{
			startInteraction.TriggerDialog();

			if(Input.GetKeyDown(KeyCode.E) || Input.GetButtonUp("Button_0"))
			{
				startInteraction.enabled = false;
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
		animationController.Logs.Add(interactedObj);
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
		animationController.Shipparts.Add(interactedObj);
		// collect
		interactedObj.SetActive(false);
	}
}