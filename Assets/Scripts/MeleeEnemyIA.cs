﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(EnemyGenericController))]
public class MeleeEnemyIA : MonoBehaviour
{
    [SerializeField] AudioClip[] embestidaAudios;
    [SerializeField] AudioSource audioSource;

    EnemyGenericController enemyController;

    public float speed;
    public float strength;
    public float detectDistance;
    public float maximunDistance;
    public float attackTime;

    private EnemyGenericController egc;
    private bool movement = true;
    private float timerPush = 0;
    private float attackTimer = 0;
    private Vector3 distance;
    private Vector3 direction;
    private bool detected;
    private Rigidbody2D rb;
    private bool inPush = false;
    private bool preparing = false;
    private GameObject playerReference;
    private Animator animator;

    [SerializeField] float knockback;
    [SerializeField] int dmg;

    [Tooltip("Rozamiento del knockback del jugador")] [SerializeField] float kFriction;


    // Start is called before the first frame update
    void Start()
    {
        audioSource.volume = 0.2f;
        animator = GetComponent<Animator>();
        enemyController = GetComponent<EnemyGenericController>();
        rb = GetComponent<Rigidbody2D>();
        playerReference = GameObject.Find("Player");
        egc = this.GetComponent<EnemyGenericController>();
    }


    // Update is called once per frame
    void Update()
    {
        this.movement = egc.movement;

        if (playerReference != null)
            distance = playerReference.transform.position - transform.position;
        direction = Vector3.Normalize(distance);

        if (distance.magnitude <= 0 && distance.magnitude < -maximunDistance && distance.magnitude >= -detectDistance && detected && !preparing && !inPush && movement) //Si el jugador está en el rango de vision del enemigo, el enemigo le persigue
        {
            attackTimer = 0;
            rb.velocity = direction * speed;
            inPush = false;
            animator.SetBool("hasNoticedPlayer", true);
        }
        else if (distance.magnitude > 0 && distance.magnitude > maximunDistance && distance.magnitude <= detectDistance && detected && !preparing && !inPush && movement) //Si el jugador está en el rango de vision del enemigo,
        {
            attackTimer = 0;
            rb.velocity = direction * speed;
            inPush = false;
            animator.SetBool("hasNoticedPlayer", true);
        }
        else if (distance.magnitude > 0 && distance.magnitude <= maximunDistance && detected && !inPush && movement) //Si el jugador está en el rango de visión del enemigo, y demasiado cerca, el enemigo embiste.
        {
            attack();
        }
        else if (distance.magnitude <= 0 && distance.magnitude >= maximunDistance && detected && !inPush && movement) //Si el jugador está en el rango de visión del enemigo, y demasiado cerca, el enemigo embiste.
        {
            attack();
        }else if (preparing && movement)
        {
            attack();
        }
        else if(!inPush && movement) //Si no se detecta al jugador, el enemigo se queda quieto.
        {
            rb.velocity = new Vector3(0, 0);
            inPush = false;
            animator.SetBool("hasNoticedPlayer", false);
        }

        if (distance.x >= 0 && distance.magnitude <= detectDistance && detected)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        if (distance.x < 0 && distance.magnitude <= detectDistance && detected)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

        if (!movement)
        {
            inPush = false;
            preparing = false;
            attackTimer = 0;
            animator.SetBool("hasNoticedPlayer", false);
        }


        if (inPush)
        {
            timerPush += Time.deltaTime;
            if (timerPush >= 0.7)
            {
                timerPush = 0;
                inPush = false;
            }
            animator.SetBool("isCharging", true);
        }
        else
        {
            animator.SetBool("isCharging", false);
        }

        //fisicas adicionales de knockback
        float previousKnockbackL = enemyController.knockback.magnitude - kFriction;
        if (previousKnockbackL < 0.01f)
            previousKnockbackL = 0;
        enemyController.knockback = enemyController.knockback.normalized * previousKnockbackL;
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, distance, distance.magnitude);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Player"))
            {
                detected = true;
            }
            else
            {
                detected = false;
            }
        }

        transform.position += enemyController.knockback;
    }

    void attack()
    {
        preparing = true;
        animator.SetBool("isPreparing", true);
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackTime)
        {
            int random = UnityEngine.Random.Range(0, embestidaAudios.Length);
            if (embestidaAudios[random] != null)
            {
                audioSource.PlayOneShot(embestidaAudios[random]);
            }

            animator.SetBool("isPreparing", false);
            preparing = false;
            Debug.Log("Embestida");
            attackTimer = 0;
            rb.AddForce(new Vector2(direction.x * strength, direction.y * strength));
            inPush = true;
        }
        else if(!inPush)
        {
             rb.velocity = new Vector3(0, 0);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && inPush)
        {
            collision.gameObject.GetComponent<HPBehaviour>().damage(dmg, knockback, gameObject);
        }
    }
}
