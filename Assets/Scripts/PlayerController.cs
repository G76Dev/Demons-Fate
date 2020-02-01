using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("Player Variables")]
    [Tooltip("Velocidad de movimiento del jugador")] [SerializeField] float speed;
    [Tooltip("Distancia entre el arma a distancia y el jugador")] [SerializeField] float weaponDistance;
    [Tooltip("Distancia entre el jugador y el arma cuerpo a cuerpo")] [SerializeField] float bladeDistance;
    [Tooltip("Referencia al punto donde se encuentra el arma a distancia")] [SerializeField] Transform weapon;
    [Tooltip("Referencia al punto donde se instanciarán los ataques cuerpo a cuerpo")] [SerializeField] Transform blade;
    private float thrust = 0.5f;
    [HideInInspector] public Vector3 mouseVector;
    private bool canMove;
    private meleeController melee;
    private Animator animator;
    [HideInInspector]public bool DemonicSword, profaneHealing, DemonicShooter;
    //[HideInInspecto]public bool demonicDash;

    [Tooltip("Rozamiento del knockback del jugador")] [SerializeField] float kFriction;
    Vector3 knockback;
    float speedModifierX = 1;
    float speedModifierY = 1;

    public int demonicHabilities = 0;
    //EVENTOS/DELEGATES

    void OnEnable() //Subscribe la funcion al evento cuando se crea este objeto
    {
        meleeController.PlayerAttack += pushPlayer;
    }

    void OnDisable() //Cuando se destruye o desactiva este objeto, quita la funcion del evento
    {
        meleeController.PlayerAttack -= pushPlayer;
    }



    void Start()
    {
        DontDestroyOnLoad(gameObject);
        animator = GetComponent<Animator>();
        canMove = true;
        rb = GetComponent<Rigidbody2D>();
        melee = GetComponent<meleeController>();
        thrust = melee.weaponPrefab.GetComponent<slashBehaviour>().getThrust();
        DemonicShooter = DemonicSword = profaneHealing = false;
    }



    void Update()
    {
        float mouseVectorX = (Input.mousePosition.x - Screen.width / 2) - transform.position.x;
        float mouseVectorY = (Input.mousePosition.y - Screen.height / 2) - transform.position.y;
        mouseVector = new Vector3(mouseVectorX, mouseVectorY, 0);
        mouseVector.Normalize();

        weapon.position = transform.position + mouseVector * weaponDistance;
        if(mouseVectorY >= 0)
            weapon.rotation = Quaternion.Euler(0,0, Vector3.Angle(mouseVector, Vector3.right) - 90);
        else
            weapon.rotation = Quaternion.Euler(0, 0, -Vector3.Angle(mouseVector, Vector3.right) - 90);

        blade.position = transform.position + mouseVector * bladeDistance;
        if (mouseVectorY >= 0)
            blade.rotation = Quaternion.Euler(0, 0, Vector3.Angle(mouseVector, Vector3.right) - 90);
        else
            blade.rotation = Quaternion.Euler(0, 0, -Vector3.Angle(mouseVector, Vector3.right) - 90);


        //fisicas adicionales de knockback
        float previousKnockbackL = knockback.magnitude - kFriction;
        if (previousKnockbackL < 0.01f)
            previousKnockbackL = 0;
        knockback = knockback.normalized * previousKnockbackL;
    }

    private void pushPlayer()
    {
        //canMove = false;
        rb.velocity = new Vector2(0,0);
        this.transform.SetPositionAndRotation(new Vector3(this.transform.position.x + mouseVector.x * thrust, this.transform.position.y + mouseVector.y * thrust),this.transform.rotation);

        //ASStartCoroutine(stopWhileAttacking(melee.getSlashDuration())); //Obtiene la longitud de la animacion del ataque del script de melee, 
        //y hace que el jugador no se pueda mover durante ese periodo de tiempo
        Debug.Log("push realizado");
    }

    public void knockBackPlayer(Vector2 dir, float force)
    {
        StartCoroutine(stopAdvancing(force / 2.5f));  //tiempo de knockback a ojo;
        rb.velocity = new Vector2(0, 0);
        knockback = new Vector3(dir.normalized.x * force, dir.normalized.y * force, 0);
    }

    IEnumerator stopAdvancing(float sec)
    {
        speedModifierX = 0;
        speedModifierY = 0;

        yield return new WaitForSeconds(sec);
        speedModifierX = 1;
        speedModifierY = 1;
    }

 
    IEnumerator stopWhileAttacking(float sec)
    {
        //Debug.Log(sec);

        yield return new WaitForSeconds(sec);
        canMove = true;
    }


    void FixedUpdate()
    {
        if (canMove)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticallInput = Input.GetAxis("Vertical");
            rb.velocity = new Vector3(horizontalInput * speedModifierX, verticallInput * speedModifierY, 0) * speed;
            animator.SetBool("isMoving", (horizontalInput != 0 || verticallInput != 0));
            GetComponent<SpriteRenderer>().flipX = (mouseVector.x >= 0) ? false : true;
        }

        transform.position += knockback;
    }
}
