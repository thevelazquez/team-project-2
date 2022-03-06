using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_UI : MonoBehaviour
{
    public GameObject aboutControlUI;
    public GameObject aboutCreditUI;

    public GameObject menuButtons;


    void Start()
    {
        aboutControlUI.SetActive(false);
        aboutCreditUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            Application.Quit();
        }
    }

    public void LoadAboutControl()
    {
        Debug.Log("Loading Controls");
        aboutCreditUI.SetActive(false);
        aboutControlUI.SetActive(true);
        menuButtons.SetActive(false);
    }

    public void ExitAbout()
    {
        aboutControlUI.SetActive(false);
        aboutCreditUI.SetActive(false);
        menuButtons.SetActive(true);
    }

    public void LoadAboutCredit()
    {
        Debug.Log("Loading Credits");
        aboutControlUI.SetActive(false);
        aboutCreditUI.SetActive(true);
        menuButtons.SetActive(false);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
