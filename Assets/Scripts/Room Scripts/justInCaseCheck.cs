using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class justInCaseCheck : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Block"))
        {
            Destroy(collision.gameObject);
        }
    }
}
