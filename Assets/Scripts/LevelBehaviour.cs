﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelBehaviour : MonoBehaviour
{
    //Estas 2 listas se deben llenar cada una con las habilidades que se quieran en el juego. Cada lista debe tener solo habilidades del tipo correspondiente para garantizar que siempre aparece una opcion de cada una.
    public List<GameObject> sacredHabilities;
    public List<GameObject> profaneHabilities;

    GameObject HSCanvas;

    GameObject hability1;
    GameObject hability2;
    GameObject hability3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this);

        //Cheats
        if (Input.GetKeyDown(KeyCode.P))
        {
            habilitiesSelector();
        }
        

        HSCanvas = GameObject.Find("HabilitesSelectorBackground");
        hability1 = GameObject.Find("hability 1 text");
        hability2 = GameObject.Find("hability 2 text");
        hability3 = GameObject.Find("No hability text");
    }

    public void habilitiesSelector()
    {
        //Se configura el apartado visual para que aparezcan botones con habilidades aleatorias.

        Time.timeScale = 0;
        int index1 = Random.Range(0, sacredHabilities.Count);
        int index2 = Random.Range(0, profaneHabilities.Count);

        if (sacredHabilities.Count != 0 && profaneHabilities.Count != 0)
        {
            hability1.GetComponent<Text>().text = sacredHabilities[index1].GetComponent<Text>().text;
            hability1.GetComponentInChildren<Image>().sprite = sacredHabilities[index1].GetComponentInChildren<Image>().sprite;
            hability1.GetComponentInChildren<Button>().onClick = sacredHabilities[index1].GetComponentInChildren<Button>().onClick;

            hability2.GetComponent<Text>().text = profaneHabilities[index2].GetComponent<Text>().text;
            hability2.GetComponentInChildren<Image>().sprite = profaneHabilities[index2].GetComponentInChildren<Image>().sprite;
            hability2.GetComponentInChildren<Button>().onClick = profaneHabilities[index2].GetComponentInChildren<Button>().onClick;

            sacredHabilities.RemoveAt(index1);
            profaneHabilities.RemoveAt(index2);

            HSCanvas.GetComponent<Animator>().Play("HSIn");
            Debug.Log("Dale carla");
        }
        else
        {
            nextLevel();
            Debug.Log("No quedan habilidades");
        }      
    }

    public void nextLevel()
    {

        Time.timeScale = 1;

        switch (SceneManager.GetActiveScene().name)
        {
            case "Nivel tutorial":
                SceneManager.LoadScene("Nivel 1");
                break;
            case "InitScene":
                SceneManager.LoadScene("Nivel tutorial");
                break;
            case "Nivel 1":
                SceneManager.LoadScene("Nivel 2");
                break;
            case "Nivel 2":
                SceneManager.LoadScene("Nivel 3");
                break;
            case "Nivel 3":
                SceneManager.LoadScene("Nivel Final");
                break;
            case "FinalScene":
                SceneManager.LoadScene("Menu");
                break;
        }
    }

    public void test()
    {
        Debug.Log("Funciona");
    }

}
