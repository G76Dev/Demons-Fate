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
    private float shootCooldown = 0.2f;

    private PlayerController playerController;
    [SerializeField] private GameObject demonicShootWeapon;
    [SerializeField] private GameObject sacredShootWeapon;
    [SerializeField] private GameObject DemonicBulletPrefab;
    [SerializeField] private GameObject SacredBulletPrefab;
    private GameObject defaultWeapon;
    private GameObject defaultBullet;

    Quaternion d1 = Quaternion.Euler(new Vector3(0, 0, 15));
    Quaternion d2 = Quaternion.Euler(new Vector3(0, 0, 30));
    Quaternion d3 = Quaternion.Euler(new Vector3(0, 0, 45));
    Quaternion d4 = Quaternion.Euler(new Vector3(0, 0, -15));
    Quaternion d5 = Quaternion.Euler(new Vector3(0, 0, -30));
    Quaternion d6 = Quaternion.Euler(new Vector3(0, 0, -45));

    private bool auxDem = false, auxSac = false;

    public AudioSource audioSource;
    public AudioClip[] shootSounds;

    private Sprite defaultSprite;

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
        shootCooldown = bulletPrefab.GetComponent<bulletBehaviour>().cooldown;
        postMeleeCooldown = GetComponent<meleeController>().weaponPrefab.GetComponent<slashBehaviour>().postMeleeCd;
        playerController = GetComponent<PlayerController>();

        defaultSprite = weaponPrefab.GetComponent<SpriteRenderer>().sprite;
        defaultBullet = bulletPrefab;

        //weaponPrefab.GetComponent<SpriteRenderer>().sprite = demonicShootWeapon.GetComponent<SpriteRenderer>().sprite;
        //bulletPrefab = DemonicBulletPrefab;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2") && canShoot && !attackingMelee)
        {
            Shoot();
        }

        if (playerController.DemonicShooter)
        {
            weaponPrefab.GetComponent<SpriteRenderer>().sprite = demonicShootWeapon.GetComponent<SpriteRenderer>().sprite;
            bulletPrefab = DemonicBulletPrefab;
            auxDem = true;
        }
        if (playerController.SacredShooter)
        {
            auxSac = true;
            weaponPrefab.GetComponent<SpriteRenderer>().sprite = sacredShootWeapon.GetComponent<SpriteRenderer>().sprite;
            bulletPrefab = SacredBulletPrefab;
        }
        if (playerController.eliminateDemonic)
        {
            if (auxSac)
            {
                weaponPrefab.GetComponent<SpriteRenderer>().sprite = sacredShootWeapon.GetComponent<SpriteRenderer>().sprite;
                bulletPrefab = SacredBulletPrefab;
            }
            else
            {
                weaponPrefab.GetComponent<SpriteRenderer>().sprite = defaultSprite;
                bulletPrefab = defaultBullet;
            }
        }
    }

    private void Shoot()
    {
        shootCooldown = bulletPrefab.GetComponent<bulletBehaviour>().cooldown;

        int random = UnityEngine.Random.Range(0, 4);
        audioSource.PlayOneShot(shootSounds[random]);

        GameObject bullet = Instantiate(bulletPrefab, weaponPrefab.transform.position, weaponPrefab.transform.rotation);
        Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();
        rb2d.AddForce(weaponPrefab.transform.up * bulletForce, ForceMode2D.Impulse);
        canShoot = false;
        StartCoroutine(cooldown(shootCooldown));

        if (playerController.DemonicShooter)
        {
            GameObject bulletExtra = Instantiate(bulletPrefab, weaponPrefab.transform.position, Quaternion.Euler(weaponPrefab.transform.rotation.eulerAngles - d2.eulerAngles));
            rb2d = bulletExtra.GetComponent<Rigidbody2D>();
            rb2d.AddForce(bulletExtra.transform.up * bulletForce, ForceMode2D.Impulse);
            canShoot = false;
            StartCoroutine(cooldown(shootCooldown));

            bulletExtra = Instantiate(bulletPrefab, weaponPrefab.transform.position, Quaternion.Euler(weaponPrefab.transform.rotation.eulerAngles + d2.eulerAngles));
            rb2d = bulletExtra.GetComponent<Rigidbody2D>();
            rb2d.AddForce(bulletExtra.transform.up * bulletForce, ForceMode2D.Impulse);
            canShoot = false;
            StartCoroutine(cooldown(shootCooldown));
        }

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
