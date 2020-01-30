using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] float knockback = 0.15f;
    [SerializeField] GameObject hitFX;
    public bool shootedByIA = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if ((!shootedByIA || collision.gameObject.tag != "Enemy"))
        {
            GameObject FX = Instantiate(hitFX, transform.position, Quaternion.identity);
            Destroy(FX, 2f);
            Destroy(gameObject);
        }*/
        if((shootedByIA && collision.gameObject.tag == "Wall") || (shootedByIA && collision.gameObject.tag == "Player"))
        {
            explode();
        }

        if(collision.gameObject.tag == "Enemy" && !shootedByIA)
        {
            collision.gameObject.GetComponent<EnemyGenericController>().takeDamage(damage, knockback, gameObject);
            explode();
        }

        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<HPBehaviour>().damage(1, knockback, gameObject);
            explode();
        }
    }

    public void explode()
    {
        GameObject FX = Instantiate(hitFX, transform.position, Quaternion.identity);
        Destroy(FX, 2f);
        Destroy(gameObject);
    }

}
