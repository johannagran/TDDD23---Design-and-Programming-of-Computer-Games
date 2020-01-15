using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    [SerializeField]
    private GameObject GameOverUI;
    [SerializeField]
    private GameObject OverlayUI;

    public void EndGame()
    {
        GameOverUI.SetActive(true);
        OverlayUI.SetActive(false);
    }

    public void Restart()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Debug.Log("Restart");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            FindObjectOfType<ScoreManager>().StartScore();
        }
    }

    public void Quit()
    {
        Debug.Log("APPLICATION QUIT!");
        Application.Quit();
    }
}
