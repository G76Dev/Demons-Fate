using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageObstacle : MonoBehaviour
{
    [SerializeField] int damage = 1;
    [SerializeField] float knockback = 0.4f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HPBehaviour>().damage(damage, knockback, gameObject);
        }
    }
}
