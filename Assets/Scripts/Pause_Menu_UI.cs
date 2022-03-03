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

    public GameObject pauseButton;

    // Update is called once per frame

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
        Time.timeScale = 1f;
        isPaused = false;
        pauseButton.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        pauseButton.SetActive(false);
    }


    
    public void LoadMenu()
    {
        SceneManager.LoadScene("IntroScreen");
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
        Debug.Log("Show Controls");
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
}
