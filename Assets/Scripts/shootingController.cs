using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingController : MonoBehaviour
{

    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject bulletPrefab;

    [SerializeField] private float bulletForce = 29f;
    private bool canShoot;
    [SerializeField] private float shootCooldown = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        if (canShoot)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb2d = bullet.GetComponent<Rigidbody2D>();
            rb2d.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            canShoot = false;
            StartCoroutine(cooldown());
        } else
        {
            //do nothing
        }

    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(shootCooldown);
        if(!canShoot)
        canShoot = true;
    }
}
