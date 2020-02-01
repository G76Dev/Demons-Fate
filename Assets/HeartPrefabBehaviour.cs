using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPrefabBehaviour : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == "Player")
        {         

            int aux1 = collision.gameObject.GetComponent<HPBehaviour>().actualHP;
            int aux2 = collision.gameObject.GetComponent<HPBehaviour>().maxHP;

            if (aux1 < aux2)
            {
                audioSource.PlayOneShot(audioClip);

                collision.gameObject.GetComponent<HPBehaviour>().actualHP += 2;
                if (collision.gameObject.GetComponent<HPBehaviour>().actualHP > collision.gameObject.GetComponent<HPBehaviour>().maxHP)
                {
                    collision.gameObject.GetComponent<HPBehaviour>().actualHP = collision.gameObject.GetComponent<HPBehaviour>().maxHP;
                }
                collision.gameObject.GetComponent<HPBehaviour>().recalculateHP();
                Debug.Log("Dentro del corazon");
                Destroy(gameObject);
            }   
        }
    }
}
