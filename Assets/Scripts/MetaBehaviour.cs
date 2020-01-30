using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MetaBehaviour : MonoBehaviour
{
    public bool enemysKilled = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && enemysKilled)
        {
            GameObject.Find("LevelBehaviour").GetComponent<LevelBehaviour>().habilitiesSelector();
        }
    }
}
