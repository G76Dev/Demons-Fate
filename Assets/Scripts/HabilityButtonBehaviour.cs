using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HabilityButtonBehaviour : MonoBehaviour
{
    [SerializeField] AudioClip clickSound, enterSound;
    [SerializeField] AudioSource audioSource;

    [SerializeField] int increaseMaxHP;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPointerIn()
    {
        PlayEnterSound();

        transform.localScale = new Vector3(transform.localScale.x * 1.3f, transform.localScale.y * 1.3f, transform.localScale.z);
    }

    public void onPointerOut()
    {
        PlayEnterSound();

        transform.localScale = new Vector3(transform.localScale.x / 1.3f, transform.localScale.y / 1.3f, transform.localScale.z);
    }

    //Si se quieren añadir más niveles, basta con añadir en los casos, los nombres de dichos niveles y la próxima escena que se debe cargar.
    public void nextLevel()
    {
        PlayClickSound();

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
            case "FinalSceneBad":
                SceneManager.LoadScene("Menu");
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

    public void ProfaneHealing()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("Habilidades D escogidas : " + player.GetComponent<PlayerController>().demonicHabilities);
        Debug.Log("Profane healing");
        player.GetComponent<HPBehaviour>().maxHP += increaseMaxHP;
        player.GetComponent<HPBehaviour>().actualHP = player.GetComponent<HPBehaviour>().maxHP;
        player.GetComponent<HPBehaviour>().recalculateHP();
        player.GetComponent<PlayerController>().demonicHabilities++;
        player.GetComponent<PlayerController>().profaneHealing = true;
        player.GetComponent<PlayerController>().demonicHabilities++;
    }

    public void activateDemonicSword()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().demonicHabilities++;
        Debug.Log("Habilidades D escogidas : " + player.GetComponent<PlayerController>().demonicHabilities);
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().DemonicSword = true;
        player.GetComponent<PlayerController>().SacredSword = false;
    }
    public void activateDemonicShooter()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().demonicHabilities++;
        Debug.Log("Habilidades D escogidas : " + player.GetComponent<PlayerController>().demonicHabilities);
        Debug.Log("Has adquirido el disparo demoníaco");
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().DemonicShooter = true;
        player.GetComponent<PlayerController>().SacredShooter = false;
    }
    public void activateSacredSword()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().SacredSword = true;
        player.GetComponent<PlayerController>().DemonicSword = false;
    }
    public void activateSacredShooter()
    {
        Debug.Log("Has adquirido el disparo sagrado");
        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().SacredShooter = true;
        player.GetComponent<PlayerController>().DemonicShooter = false;

    }

    public void nonDemonicHabilities()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("Se resetean las habilidades demoniacas");

        player.GetComponent<PlayerController>().eliminateDemonic = true;

        player.GetComponent<PlayerController>().DemonicSword=false;
        player.GetComponent<PlayerController>().DemonicShooter = false;

        if (player.GetComponent<PlayerController>().profaneHealing)
        {
            player.GetComponent<PlayerController>().profaneHealing = false; 
            player.GetComponent<HPBehaviour>().maxHP -= increaseMaxHP;
            player.GetComponent<HPBehaviour>().actualHP -= increaseMaxHP;
            if (player.GetComponent<HPBehaviour>().actualHP<=0)
            {
                player.GetComponent<HPBehaviour>().actualHP = 1;
            }
            player.GetComponent<HPBehaviour>().recalculateHP();
            player.GetComponent<PlayerController>().demonicHabilities = 0;
        }
        
    }

    public void PlayClickSound()
    {
        if(clickSound!=null)
            audioSource.PlayOneShot(clickSound);
    }

    public void PlayEnterSound()
    {
        if(enterSound != null)
            audioSource.PlayOneShot(enterSound);
    }

}
