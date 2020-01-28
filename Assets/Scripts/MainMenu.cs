using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
}
