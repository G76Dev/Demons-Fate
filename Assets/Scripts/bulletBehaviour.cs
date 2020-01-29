using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] GameObject hitFX;
    public bool shootedByIA = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((!shootedByIA || collision.gameObject.tag != "Enemy") && collision.gameObject.tag != "SpawnPoint" && collision.gameObject.tag != "Checker")
        {
            GameObject FX = Instantiate(hitFX, transform.position, Quaternion.identity);
            Destroy(FX, 2f);
            Destroy(gameObject);
        }

        if(collision.gameObject.tag == "Enemy" && !shootedByIA)
        {
            collision.gameObject.GetComponent<EnemyGenericController>().takeDamage(damage);

        }

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HPBehaviour>().actualHP -= (damage / 10);
            collision.gameObject.GetComponent<HPBehaviour>().recalculateHP();
        }
    }

}
