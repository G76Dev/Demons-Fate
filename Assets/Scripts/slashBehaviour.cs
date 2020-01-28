using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slashBehaviour : MonoBehaviour
{
    private Animator anim;

    [SerializeField] int damage = 30;

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
            collision.gameObject.GetComponent<EnemyGenericController>().takeDamage(damage);

        }
    }
}
