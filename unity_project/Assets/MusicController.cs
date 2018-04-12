using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class MusicController : MonoBehaviour {
    GameObject PlayerToFollow;
    GameObject MusicWall1;
    GameObject BackgroundMusic;
    new AudioSource audio;
    List<AudioClip> Clips;

    int part = 0;

	// Use this for initialization
	void Start () {
        PlayerToFollow = GameObject.FindGameObjectWithTag("Player");
        MusicWall1 = GameObject.Find("MusicWall1");
        BackgroundMusic = GameObject.Find("BackgroundMusic");
        audio = BackgroundMusic.GetComponent<AudioSource>();
        LoadClips();
        PlayAudio();
	}

    private void LoadClips()
    {
        Clips = new List<AudioClip>();
        for (int i = 0; i <= 5; i++)
        {
            string path = string.Format("Assets/_music/first_planet/{0}.ogg", i);
            Clips.Add(AssetDatabase.LoadAssetAtPath<AudioClip>(path));
        }
    }

    private void PlayAudio()
    {
        audio.PlayOneShot(Clips[part]);
    }

    // Update is called once per frame
    void Update () {
        if (audio.isPlaying)
            return;

        bool loop1 = part == 1 || part == 2;
        bool part2 = PlayerToFollow.transform.position.x > MusicWall1.transform.position.x;

        if (part2 && loop1)
        {
            part = 3;
            PlayAudio();
            return;
        }

        if (part == 0 || part == 3)
            part++;

        if (loop1)
        {
            if (part == 1)
                part++;
            else
                part--;
        }
        PlayAudio();
    }
}
