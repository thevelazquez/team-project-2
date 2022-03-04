using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Menu_UI : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;

    public GameObject controlUI;
    public GameObject creditsUI;

    public GameObject controlXButton;
    public GameObject creditXButton;

    void Start()
    {
        Resume();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }        
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        controlUI.SetActive(false);
        creditsUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }


    
    public void LoadMenu()
    {
        SceneManager.LoadScene("TitleScene");
        Time.timeScale = 1f;
    }

    public void LoadControls()
    {
        Debug.Log("Show Controls");
        pauseMenuUI.SetActive(false);
        controlUI.SetActive(true);
    }

    public void LoadCredits()
    {
        Debug.Log("Show Credits");
        pauseMenuUI.SetActive(false);
        creditsUI.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }

    
    public void ExitControl()
    {
        controlUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

        public void ExitCredit()
    {
        creditsUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("MainScene");
    }
}
