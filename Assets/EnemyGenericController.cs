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
        Debug.Log(health);
        //dontMove();
        healthBar.changeHealth(-dmg);
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

    private void Die()
    {
        Instantiate(DieFX, this.transform.position, Quaternion.identity);
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
        healthBar.GetComponent<Transform>().Translate(new Vector3(999, 999, 999));
        Destroy(gameObject,2);
    }

    public void dontMove()
    {
        //Si se quiere introducir un knockup a los enemigos usando esta función, se recomienda poner la velocidad de los enemigos a 0 antes de hacer el empuje.
        this.movement = false;
        timerStopped = 0;
        Debug.Log("Paralizado");
    }
}
