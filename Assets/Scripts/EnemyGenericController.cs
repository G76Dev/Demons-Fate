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
    [SerializeField] GameObject HitFX;
    [SerializeField] Color tintWhenHit;
    [SerializeField] float tintTime;
    Color originalTint;
    SpriteRenderer sr;

    [SerializeField] AudioClip[] impactAudios;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip death;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
        healthBar = GetComponentInChildren<HealthBar>();
        health = healthBar.health;

        sr = GetComponent<SpriteRenderer>();
        originalTint = sr.color;
    }


    public int getHealth()
    {
        return health;
    }

    public void takeDamage(int dmg)
    {
        int random = UnityEngine.Random.Range(0, 4);
        audioSource.PlayOneShot(impactAudios[random]);

        health = health - dmg;
        healthBar.changeHealth(-dmg);

        Destroy(Instantiate(HitFX, this.transform.position, Quaternion.identity), 2);

        sr.color = tintWhenHit;
        StartCoroutine(restoreColor());
    }

    public void takeDamage(int dmg, float force, GameObject inflictor)
    {
        takeDamage(dmg);
        Vector3 dir = transform.position - inflictor.transform.position;
        knockback = new Vector3(dir.normalized.x * force, dir.normalized.y * force, 0);
    }

    IEnumerator restoreColor()
    {
        yield return new WaitForSeconds(tintTime);
        sr.color = originalTint;
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
        audioSource.PlayOneShot(death);
        Destroy(Instantiate(DieFX, this.transform.position, Quaternion.identity),2);
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
