﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyIA : MonoBehaviour
{
    public float speed;
    public float strength;
    public float detectDistance;
    public float maximunDistance;
    public float attackTime;


    private float timerPush = 0;
    private float attackTimer = 0;
    private Vector3 distance;
    private Vector3 direction;
    private bool detected;
    private Rigidbody2D rb;
    private bool inPush = false;
    private bool preparing = false;

    private GameObject playerReference;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerReference = GameObject.Find("Player");
    }


    // Update is called once per frame
    void Update()
    {
        distance = playerReference.transform.position - transform.position;
        direction = Vector3.Normalize(distance);

        if (distance.magnitude <= 0 && distance.magnitude < -maximunDistance && distance.magnitude >= -detectDistance && detected && !preparing && !inPush) //Si el jugador está en el rango de vision del enemigo, el enemigo le persigue
        {
            attackTimer = 0;
            rb.velocity = direction * speed;
            inPush = false;
        }
        else if (distance.magnitude > 0 && distance.magnitude > maximunDistance && distance.magnitude <= detectDistance && detected && !preparing && !inPush) //Si el jugador está en el rango de vision del enemigo,
        {
            attackTimer = 0;
            rb.velocity = direction * speed;
            inPush = false;
        }
        else if (distance.magnitude > 0 && distance.magnitude <= maximunDistance && detected && !inPush) //Si el jugador está en el rango de visión del enemigo, y demasiado cerca, el enemigo embiste.
        {
            attack();
        }
        else if (distance.magnitude <= 0 && distance.magnitude >= maximunDistance && detected && !inPush) //Si el jugador está en el rango de visión del enemigo, y demasiado cerca, el enemigo embiste.
        {
            attack();
        }else if (preparing)
        {
            attack();
        }
        else if(!inPush) //Si no se detecta al jugador, el enemigo se queda quieto.
        {
            rb.velocity = new Vector3(0, 0);
            inPush = false;
        }


        if (inPush)
        {
            timerPush += Time.deltaTime;
            if (timerPush >= 0.7)
            {
                timerPush = 0;
                inPush = false;
            }
        }
        
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
    }

    void attack()
    {
        preparing = true;
        attackTimer += Time.deltaTime;
        if (attackTimer >= attackTime)
        {
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
}
