using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] float knockback = 0.15f;
    [SerializeField] GameObject hitFX;
    public bool shootedByIA = false;

    public float cooldown;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if ((!shootedByIA || collision.gameObject.tag != "Enemy"))
        {
            GameObject FX = Instantiate(hitFX, transform.position, Quaternion.identity);
            Destroy(FX, 2f);
            Destroy(gameObject);
        }*/
        if((collision.gameObject.tag == "Wall") || (collision.gameObject.tag == "Block"))
        {
            explode();
        }

        if(collision.gameObject.tag == "Enemy" && !shootedByIA)
        {
            collision.gameObject.GetComponent<EnemyGenericController>().takeDamage(damage, knockback, gameObject);
            explode();
        }

        if (collision.gameObject.tag == "Player" && shootedByIA)
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

    public void buff()
    {
        damage += damage/2;
        transform.localScale = transform.localScale * 1.75f;
        knockback += 0.05f;
    }

}
