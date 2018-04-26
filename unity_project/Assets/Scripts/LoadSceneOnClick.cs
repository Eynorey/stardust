using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class LoadSceneOnClick : MonoBehaviour {

    public GameObject loadingBar;
    public Slider slider;
    AsyncOperation sceneLoading;

    public void LoadLevel(int sceneIndex)
    {
        sceneLoading = SceneManager.LoadSceneAsync(sceneIndex);
        sceneLoading.allowSceneActivation = false;
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {

        GameObject.Find("MainMenuePanel").SetActive(false);
        loadingBar.SetActive(true);
        VideoPlayer video = loadingBar.GetComponent<VideoPlayer>();
        video.Prepare();
        while (!video.isPrepared)
        {
            yield return null;
        }
        GameObject.Find("Music").GetComponent<AudioSource>().Stop();
        video.Play();

        while (sceneLoading.progress < 0.9f || video.isPlaying)
        {
            slider.value = sceneLoading.progress / .9f;
            yield return null;
        }

        sceneLoading.allowSceneActivation = true;
    }
}
