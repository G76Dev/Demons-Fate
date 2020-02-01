using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingController : MonoBehaviour
{
    [Tooltip("Referencia al objeto del arma a distancia")] public GameObject weaponPrefab;
    [Tooltip("Referencia al objeto de la bala")] [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bulletForce = 29f;
    private float postMeleeCooldown = 3f;
    private bool canShoot;
    private bool attackingMelee;
    [SerializeField] private float shootCooldown = 0.2f;

    public AudioSource audioSource;
    public AudioClip[] shootSounds;

    //SISTEMA DE EVENTOS Y DELEGATES

    void OnEnable() //Subscribe la funcion al evento cuando se crea este objeto
    {
        meleeController.PlayerAttack += stopShooting;
    }

    void OnDisable() //Cuando se destruye o desactiva este objeto, quita la funcion del evento
    {
        meleeController.PlayerAttack -= stopShooting;
    }

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
        attackingMelee = false;

        postMeleeCooldown = GetComponent<meleeController>().weaponPrefab.GetComponent<slashBehaviour>().postMeleeCd;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2") && canShoot && !attackingMelee)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        int random = UnityEngine.Random.Range(0, 4);
        audioSource.PlayOneShot(shootSounds[random]);

        GameObject bullet = Instantiate(bulletPrefab, weaponPrefab.transform.position, weaponPrefab.transform.rotation);
        Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();
        rb2d.AddForce(weaponPrefab.transform.up * bulletForce, ForceMode2D.Impulse);
        canShoot = false;
        StartCoroutine(cooldown(shootCooldown));


    }

    private void stopShooting()
    {
        if (!attackingMelee)
        {
            attackingMelee = true;
            float attack_duration = GetComponent<meleeController>().getSlashDuration();
            Debug.Log(attack_duration);
            StartCoroutine(cooldownMelee(attack_duration + postMeleeCooldown));
        }
    }

    IEnumerator cooldownMelee(float time)
    {
        yield return new WaitForSeconds(time);
        if (attackingMelee)
            attackingMelee = false;
    }

    IEnumerator cooldown(float time)
    {
        yield return new WaitForSeconds(time);
        if (!canShoot)
            canShoot = true;
    }
}
