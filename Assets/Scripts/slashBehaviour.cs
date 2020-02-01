using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slashBehaviour : MonoBehaviour
{
    private Animator anim;

    [Tooltip("Daño causado por este arma")] [SerializeField] int damage = 30;
    [Tooltip("Retroceso causado a los enemigos que daña este arma")] [SerializeField] float knockback = 0.35f;
    [Tooltip("Cooldown entre ataque y ataque")][SerializeField] float cooldown = 0.2f;
    [Tooltip("Cantidad de espacio que avanza el jugador al atacar en una direccion con este arma")] [SerializeField] float thrust = 1;


    [Tooltip("0->destruye balas, 1->no hace nada con las balas, 2->refleja balas")] [SerializeField] int bulletInterac = 0;

    private void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    public float getCooldown()
    {
        return cooldown;
    }

    public float getThrust()
    {
        return thrust;
    }

    private void Update()
    {
        if(!AnimatorIsPlaying())
        {
            Destroy(gameObject,0.1f);
        }
    }

    bool AnimatorIsPlaying()
    {
        return anim.GetCurrentAnimatorStateInfo(0).length >
               anim.GetCurrentAnimatorStateInfo(0).normalizedTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyGenericController>().takeDamage(damage, knockback, transform.parent.gameObject);
        }

        if (collision.gameObject.tag == "bullet")
        {
            if(bulletInterac == 1)
            {
                //nada
            }
            else if(bulletInterac == 2)
            {
                collision.GetComponent<Rigidbody2D>().AddForce(transform.parent.gameObject.GetComponent<PlayerController>().mouseVector.normalized * 15, ForceMode2D.Impulse);
                collision.gameObject.GetComponent<bulletBehaviour>().shootedByIA = false;
                collision.gameObject.transform.localScale = new Vector3(collision.gameObject.transform.localScale.x, -collision.gameObject.transform.localScale.y, 1);
                collision.gameObject.transform.rotation = transform.parent.gameObject.GetComponent<shootingController>().weaponPrefab.transform.rotation;
                collision.gameObject.transform.localScale = -collision.gameObject.transform.localScale;
            }
            else
            {
                collision.gameObject.GetComponent<bulletBehaviour>().explode();
            }
        }
    }
}
