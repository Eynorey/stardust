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
    bool playIntro;
    VideoPlayer video;

    public void LoadLevel(int sceneIndex)
    {
        if (sceneIndex == 1)
        {
            playIntro = true;
            video = loadingBar.GetComponent<VideoPlayer>();
        }

        sceneLoading = SceneManager.LoadSceneAsync(sceneIndex);
        sceneLoading.allowSceneActivation = false;
        StartCoroutine(LoadAsynchronously(sceneIndex));    
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        loadingBar.SetActive(true);

        if (playIntro)
        {
            GameObject.Find("MainMenuePanel").SetActive(false);
            video.Prepare();
            while (!video.isPrepared)
            {
                yield return null;
            }
            GameObject.Find("Music").GetComponent<AudioSource>().Stop();
            video.Play();
        }

        while (sceneLoading.progress < 0.9f || (playIntro && video.isPlaying))
        {
            slider.value = sceneLoading.progress / .9f;
            yield return null;
        }

        sceneLoading.allowSceneActivation = true;
    }
}
