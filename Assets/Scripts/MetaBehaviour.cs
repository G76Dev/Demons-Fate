using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetaBehaviour : MonoBehaviour
{
    public bool enemysKilled = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && enemysKilled)
        {
            if (SceneManager.GetActiveScene().name == "Nivel tutorial")
            {
                SceneManager.LoadScene("Nivel 1");
            }
            else if (SceneManager.GetActiveScene().name == "Nivel Final")
            {
                if(collision.gameObject.GetComponent<PlayerController>().demonicHabilities >= 2)
                {
                    SceneManager.LoadScene("FinalSceneBad");
                }
                else
                {
                    SceneManager.LoadScene("FinalScene");
                }
            }
            else
            {
                GameObject.Find("LevelBehaviour").GetComponent<LevelBehaviour>().habilitiesSelector();
            }
        }
    }
}
