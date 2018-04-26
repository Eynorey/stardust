using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class LoadSceneOnClick : MonoBehaviour {

    public GameObject loadingBar;
    public Slider slider;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        var operation = SceneManager.LoadSceneAsync(sceneIndex);
        GameObject.Find("MainMenuePanel").SetActive(false);
        loadingBar.SetActive(true);

        GameObject music = GameObject.Find("Music");
        music.GetComponent<AudioSource>().Stop();
        GameObject video = GameObject.Find("LoadBar");
        video.GetComponent<VideoPlayer>().Play();



        while (!operation.isDone)
        {
            var progress = Mathf.Clamp01(operation.progress / .9f);

            slider.value = progress;
            yield return null;
        }
    }
}
