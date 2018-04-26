﻿using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class Interaction : MonoBehaviour 
{
	GameObject player;
	Camera thirdPersonCam;
	DialogTrigger startInteraction;
	public GameObject interactionDialog;
	public Image image;
	AnimationController animationController;
	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
		animationController = (AnimationController)player.GetComponent("AnimationController");
		thirdPersonCam = GameObject.Find("thirdPersonCam").GetComponent<Camera>();

		// startInteraction = (DialogTrigger) player.GetComponent<DialogTrigger>();
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
		interactionDialog.SetActive(false);
	}

	void CheckInteraction(Collider hit)
	{
		GameObject obj = hit.transform.gameObject;
		if(obj.tag == "Log")
		{
			interactionDialog.SetActive(true);
			image.rectTransform.anchoredPosition = new Vector3(obj.transform.position.x, obj.transform.position.y + 1, obj.transform.position.z);

			if(Input.GetKeyDown(KeyCode.E) || Input.GetButtonUp("Button_0"))
			{
				interactionDialog.SetActive(false);

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
				HandleShippart(obj);
			}
		}

		if(obj.tag == "Spaceship")
		{
			startInteraction.TriggerDialog();

			if(Input.GetKeyDown(KeyCode.E) || Input.GetButtonUp("Button_0"))
			{
				startInteraction.enabled = false;
				HandleSpaceship(obj);
			}
		}

		if(obj.tag == "Fuel")
		{
			startInteraction.TriggerDialog();

			if(Input.GetKeyDown(KeyCode.E) || Input.GetButtonUp("Button_0"))
			{
				startInteraction.enabled = false;
				HandleFuel(obj);
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
		interactedObj.GetComponent<DialogTrigger>().TriggerDialog();
	}

	// on interacting with a NPC
	// talk
	void HandleNPC(GameObject interactedObj)
	{
		// trigger dialog with npc
		
	}

	// collect fuel
	void HandleFuel(GameObject interactedObj)
	{
		animationController.Fuel.Add(interactedObj);
		// collect
		interactedObj.SetActive(false);
	}

	// collect ship part
	void HandleShippart(GameObject interactedObj)
	{
		animationController.Shipparts.Add(interactedObj);
		// collect
		interactedObj.SetActive(false);
	}

	void HandleSpaceship(GameObject obj)
	{
		// if all parts are found and enough fuel was found -> able to switch planet
		if(animationController.Shipparts.Count == 5 && animationController.Fuel.Count >= 3)
		{

		}
		else 
		{

		}
	}
}