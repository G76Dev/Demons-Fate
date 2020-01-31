using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPrefabBehaviour : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.tag == "Player")
        {
           

            int aux1 = collision.gameObject.GetComponent<HPBehaviour>().actualHP;
            int aux2 = collision.gameObject.GetComponent<HPBehaviour>().maxHP;

            if (aux1 < aux2)
            {
                collision.gameObject.GetComponent<HPBehaviour>().actualHP++;
                collision.gameObject.GetComponent<HPBehaviour>().recalculateHP();
                Debug.Log("Dentro del corazon");
                Destroy(gameObject);
            }   
        }
    }
}
