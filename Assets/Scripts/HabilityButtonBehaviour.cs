using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HabilityButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPointerIn()
    {
        transform.localScale = new Vector3(transform.localScale.x * 1.3f, transform.localScale.y * 1.3f, transform.localScale.z);
    }

    public void onPointerOut()
    {
        transform.localScale = new Vector3(transform.localScale.x / 1.3f, transform.localScale.y / 1.3f, transform.localScale.z);
    }

    //Si se quieren añadir más niveles, basta con añadir en los casos, los nombres de dichos niveles y la próxima escena que se debe cargar.
    public void nextLevel()
    {
        Time.timeScale = 1;

        switch (SceneManager.GetActiveScene().name)
        {
            case "Nivel 1":
                SceneManager.LoadScene("Nivel 2");
                break;
            case "Nivel 2":
                SceneManager.LoadScene("Nivel 3");
                break;
            case "Nivel 3":
                SceneManager.LoadScene("Nivel Final");
                break;
        }
    }

    public void returnToMenu()
    {
        Time.timeScale = 1;

        SceneManager.LoadScene("Menu");
    }

    public void HabilidadPrueba2()
    {
        Debug.Log("Habilidad elegida 2:");
    }
    public void HabilidadPrueba1()
    {
        Debug.Log("Habilidad elegida 1:");
    }
    public void HabilidadPrueba3()
    {
        Debug.Log("Habilidad elegida 3:");
    }

}
