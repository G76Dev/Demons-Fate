using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenericController : MonoBehaviour
{

    private int health;
    private HealthBar healthBar;
    [SerializeField] GameObject DieFX;
    private bool alive;

    [SerializeField] float timeStopped;
    private float timerStopped=0;
    public bool movement;

    [HideInInspector]public Vector3 knockback;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        healthBar = GetComponentInChildren<HealthBar>();
        health = healthBar.health;
    }


    public int getHealth()
    {
        return health;
    }

    public void takeDamage(int dmg)
    {
        health = health - dmg;
        //dontMove();
        healthBar.changeHealth(-dmg);
    }

    public void takeDamage(int dmg, float force, GameObject inflictor)
    {
        takeDamage(dmg);
        Vector3 dir = transform.position - inflictor.transform.position;
        knockback = new Vector3(dir.normalized.x * force, dir.normalized.y * force, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (!movement)
        {
            timerStopped += Time.deltaTime;
            if (timerStopped >= timeStopped)
            {
                timerStopped = 0;
                movement = true;
            }
        }

        if (health <= 0 && alive)
        {
            alive = false;
            Die();
        }
    }

   /* IEnumerator stopAdvancing(float sec)
    {
        speedModifierX = 0;
        speedModifierY = 0;

        yield return new WaitForSeconds(sec);
        speedModifierX = 1;
        speedModifierY = 1;
    }*/

    private void Die()
    {
        Instantiate(DieFX, this.transform.position, Quaternion.identity);
        GameObject.Find("Canvas").GetComponent<PlayerInterface>().enemyKilled();
        //GetComponent<SpriteRenderer>().enabled = false;
        //GetComponent<BoxCollider2D>().enabled = false;
        //healthBar.GetComponent<Transform>().Translate(new Vector3(999, 999, 999));
        Destroy(gameObject); //antes estaba en ,2
    }

    public void dontMove()
    {
        //Si se quiere introducir un knockup a los enemigos usando esta función, se recomienda poner la velocidad de los enemigos a 0 antes de hacer el empuje.
        this.movement = false;
        timerStopped = 0;
        Debug.Log("Paralizado");
    }
}
