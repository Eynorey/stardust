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
        operation.allowSceneActivation = false;

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

        while (operation.progress < 0.9f || video.isPlaying)
        {
            slider.value = operation.progress / .9f;
            yield return null;
        }

        operation.allowSceneActivation = true;
    }
}
