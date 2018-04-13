using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    GameObject PlayerToFollow;
    GameObject MusicWall1;
    GameObject BackgroundMusic;
    new AudioSource audio;
    List<AudioClip> Clips;

    int part = 0;

    // Use this for initialization
    void Start()
    {
        PlayerToFollow = GameObject.FindGameObjectWithTag("Player");
        MusicWall1 = GameObject.Find("MusicWall1");
        BackgroundMusic = GameObject.Find("BackgroundMusic");
        audio = BackgroundMusic.GetComponent<AudioSource>();
        LoadClips();
        PlayAudio();
    }

    private void LoadClips()
    {
        var musicfiles = Resources.LoadAll("");
        Clips = new List<AudioClip>();
        foreach (var musicFile in musicfiles)
        {
            if (musicFile.GetType().Equals(typeof(AudioClip)))
            {
                Clips.Add((AudioClip)musicFile);
            }

        }
    }

    private void PlayAudio()
    {
        audio.PlayOneShot(Clips[part]);
    }

    // Update is called once per frame
    void Update()
    {
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
