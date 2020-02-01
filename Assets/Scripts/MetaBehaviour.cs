using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MetaBehaviour : MonoBehaviour
{
    public bool enemysKilled = false;
    [SerializeField] Sprite metaSprite;

    private void Update()
    {
        if (enemysKilled)
        {
            this.gameObject.GetComponent<SpriteRenderer>().sprite = metaSprite;
        }
    }

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
                Debug.Log("Habilidades D escogidas : " + collision.gameObject.GetComponent<PlayerController>().demonicHabilities);
                if(collision.gameObject.GetComponent<PlayerController>().demonicHabilities >= 2)
                {
                    SceneManager.LoadScene("FinalSceneBad");
                    Destroy(collision.gameObject);
                    Destroy(GameObject.Find("LevelBehaviour"));
                }
                else
                {
                    SceneManager.LoadScene("FinalScene");
                    Destroy(collision.gameObject);
                    Destroy(GameObject.Find("LevelBehaviour"));
                }
            }
            else
            {
                GameObject.Find("LevelBehaviour").GetComponent<LevelBehaviour>().habilitiesSelector();
            }
        }
    }
}
