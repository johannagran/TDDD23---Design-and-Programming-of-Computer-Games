using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class StartMenu : MonoBehaviour {

    public string sceneName;
    public Animator transitionAnim;
    public AudioMixer audioMixer;

    public void PlayGame ()
    {
            StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        transitionAnim.SetTrigger("endis");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneName);
    }

    public void SetVolume (float Volume)
    {
        audioMixer.SetFloat("Volume", Volume);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}