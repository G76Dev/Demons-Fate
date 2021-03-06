﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] AudioClip buttonClickSound, buttonEnterSound;
    [SerializeField] AudioSource audioSource;
    GameObject menu;

    private void Start()
    {
        menu = GameObject.Find("Main menu buttons");
        DontDestroyOnLoad(menu);
        
    }

    public void playGame()
    {
        //Cargar la escena del primer nivel 
    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void goSettings()
    {
        GetComponent<Animator>().Play("GoSettings");
        GameObject.Find("SettingsMenu").GetComponent<Animator>().Play("SettingsIn");
    }

    public void backSettigns()
    {
        GetComponent<Animator>().Play("BackSettings");
        GameObject.Find("SettingsMenu").GetComponent<Animator>().Play("SettingsOut");
    }

    public void InitGame() {
        Destroy(menu, 2);
        Time.timeScale = 1;
        SceneManager.LoadScene("InitScene");
    }

    public void playClickButtonSound()
    {
        audioSource.PlayOneShot(buttonClickSound);

    }

    public void playEnterButtonSound()
    {
        audioSource.PlayOneShot(buttonEnterSound);
    }
}
