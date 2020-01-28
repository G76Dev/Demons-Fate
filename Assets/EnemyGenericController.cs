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
        healthBar.changeHealth(-dmg);
    }

    // Update is called once per frame
    void Update()
    {
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
}
