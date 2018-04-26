using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]
public class Savegame
{
	public Guid Id {get; set;}
	public GameObject Player {get;set;}
	public Scene Scene {get; set;}
	public DateTime SaveDate {get;set;}
	public List<GameObject> Logs {get;set;}
	public List<GameObject> Shipparts {get;set;}
	public List<GameObject> Fuel {get;set;}
}

[RequireComponent(typeof(Rigidbody))]
public class Autosave : MonoBehaviour 
{
	private Savegame savegame = null;
	private GameObject player;
	private AnimationController animationController;

	// Use this for initialization
	void Awake () 
	{
		player = GameObject.FindGameObjectWithTag("Player");
		animationController = (AnimationController)player.GetComponent("AnimationController");
		CheckSaveFile();
		if(savegame == null)
		{
			savegame = new Savegame()
			{
				Id = Guid.NewGuid(),
				Player = player,
				SaveDate = DateTime.Now,
				Scene = SceneManager.GetActiveScene(),
				Logs = animationController.Logs,
				Shipparts = animationController.Shipparts
			};
		}
	}

	void Update()
	{
		StartCoroutine(DoCheck());
	}

	IEnumerator DoCheck() 
	{
		Save();
		yield return new WaitForSeconds(5f);
 	}

	void Save() {
		savegame.Scene = SceneManager.GetActiveScene();
		savegame.SaveDate = DateTime.Now;
		savegame.Logs = animationController.Logs;
		savegame.Shipparts = animationController.Shipparts;
		savegame.Fuel = animationController.Fuel;

		WriteSavefile();
	}

	void WriteSavefile()
	{
        // Stream the file with a File Stream. (Note that File.Create() 'Creates' or 'Overwrites' a file.)
        FileStream file = File.Create(@"Savegames\stardust_save.xml");

        //Serialize to xml
        DataContractSerializer bf = new DataContractSerializer(savegame.GetType());
        MemoryStream streamer = new MemoryStream();

        //Serialize the file
        bf.WriteObject(streamer, savegame);
        streamer.Seek(0, SeekOrigin.Begin);

        //Save to disk
        file.Write(streamer.GetBuffer(), 0, streamer.GetBuffer().Length);

        // Close the file to prevent any corruptions
        file.Close();

        //string result = XElement.Parse(Encoding.ASCII.GetString(streamer.GetBuffer()).Replace("\0", "")).ToString();
	}

	void CheckSaveFile()
	{
		try
		{
			using(StreamReader reader = new StreamReader(@"Savegames\stardust_save.xml"))
			{
				XmlSerializer serializer = new XmlSerializer(typeof(Savegame));
				savegame = (Savegame) serializer.Deserialize(reader);
			}
		} 
		catch(Exception e) { }
	}
}