using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slashBehaviour : MonoBehaviour
{
    private Animator anim;

    [SerializeField] int damage = 30;
    [SerializeField] float knockback = 0.35f;

    private void Start()
    {
        anim = this.GetComponent<Animator>();

    }

    private void Update()
    {
        if(!AnimatorIsPlaying())
        {
            Destroy(gameObject,0.3f);
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
            collision.gameObject.GetComponent<bulletBehaviour>().explode();
        }

        //CODIGO PARA REFLEJAR DISPAROS CON ESPADA
        /*if(collision.CompareTag("bullet"))
        {
            collision.GetComponent<Rigidbody2D>().AddForce(transform.parent.gameObject.GetComponent<PlayerController>().mouseVector.normalized * 15, ForceMode2D.Impulse);
            collision.gameObject.GetComponent<bulletBehaviour>().shootedByIA = false;
            collision.gameObject.transform.localScale = new Vector3(collision.gameObject.transform.localScale.x, -collision.gameObject.transform.localScale.y, 1);
            collision.gameObject.transform.rotation = transform.parent.gameObject.GetComponent<shootingController>().weaponPrefab.transform.rotation;
            collision.gameObject.transform.localScale = -collision.gameObject.transform.localScale;
        }*/
    }
}
