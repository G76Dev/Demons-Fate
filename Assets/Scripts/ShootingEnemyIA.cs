using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyIA : MonoBehaviour
{
    public float speed;
    public float maximunDistance;
    public float maximunShootingDistance;
    public float shootingTime;
    public float bulletSpeed;

    private float shootingTimer;

    public GameObject bullet;
    private GameObject playerReference;
    private Vector3 direction, distance;

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
            Debug.Log("Dentro primer if");
            if ((distance.magnitude >0 && distance.magnitude <= maximunShootingDistance) || (distance.magnitude <= 0 && distance.magnitude >= -maximunShootingDistance))
            {
                Debug.Log("Dentro segundo if");
                       
                GameObject bulletIn = Instantiate(bullet);

                bulletIn.transform.position = transform.position;
                // bulletIn.transform.LookAt(playerReference.transform);
                float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
                bulletIn.transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
                bulletIn.GetComponent<Rigidbody2D>().velocity = Vector3.Normalize(playerReference.transform.position-transform.position) * bulletSpeed;
                shootingTimer = 0;
            }
        }

        if (distance.magnitude <= 0 && distance.magnitude <= -maximunDistance-1)
        {
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        else if (distance.magnitude > 0 && distance.magnitude >= maximunDistance+1)
        {
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        else if(distance.magnitude > 0 && distance.magnitude <= maximunDistance)
        {
            GetComponent<Rigidbody2D>().velocity = -direction * speed;
        }
        else if (distance.magnitude < 0 && distance.magnitude >= maximunDistance)
        {
            GetComponent<Rigidbody2D>().velocity = -direction * speed;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
        }



    }
}
