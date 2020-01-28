using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyIA : MonoBehaviour
{
    public float speed;
    public float detectDistance;
    public float maximunDistance;
    public float maximunShootingDistance;
    public float shootingTime;
    public float bulletSpeed;

    private float shootingTimer;

    public GameObject bullet;
    private GameObject playerReference;
    private Vector3 direction, distance;
    private bool detected;

    // Start is called before the first frame update
    void Start()
    {
        playerReference = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        shootingTimer += Time.deltaTime;

        distance = playerReference.transform.position - transform.position;
        direction = Vector3.Normalize(distance);
        //Debug.Log("X: " + direction.x + " Y: " + direction.y + " Z: " + direction.z);

        if (shootingTimer >= shootingTime)
        {
            if ((distance.magnitude >0 && distance.magnitude <= maximunShootingDistance) || (distance.magnitude <= 0 && distance.magnitude >= -maximunShootingDistance))
            {
                       
                GameObject bulletIn = Instantiate(bullet);

                bulletIn.transform.position = transform.position;
                // bulletIn.transform.LookAt(playerReference.transform);
                float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
                bulletIn.transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
                bulletIn.GetComponent<Rigidbody2D>().velocity = Vector3.Normalize(playerReference.transform.position-transform.position) * bulletSpeed;
                shootingTimer = 0;
            }
        }

        if (distance.magnitude <= 0 && distance.magnitude <= -maximunDistance-1 && distance.magnitude >= -detectDistance && detected) //Si el jugador está en el rango de vision del enemigo, el enemigo le persigue
        {
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        else if (distance.magnitude > 0 && distance.magnitude >= maximunDistance+1 && distance.magnitude <= detectDistance && detected) //Si el jugador está en el rango de vision del enemigo,
        {
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        else if(distance.magnitude > 0 && distance.magnitude <= maximunDistance && detected) //Si el jugador está en el rango de visión del enemigo, y demasiado cerca, el enemigo se aleja.
        {
            GetComponent<Rigidbody2D>().velocity = -direction * speed;
        }
        else if (distance.magnitude < 0 && distance.magnitude >= maximunDistance && detected) //Si el jugador está en el rango de visión del enemigo, y demasiado cerca, el enemigo se aleja.
        {
            GetComponent<Rigidbody2D>().velocity = -direction * speed;
        }
        else //Si no se detecta al jugador, el enemigo se queda quieto.
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
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
}
