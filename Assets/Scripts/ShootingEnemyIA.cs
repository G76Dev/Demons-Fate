using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(EnemyGenericController))]
public class ShootingEnemyIA : MonoBehaviour
{
    EnemyGenericController enemyController;

    public AudioSource audioSource;
    public AudioClip[] shootSounds;

    public float speed;
    public float detectDistance;
    public float maximunDistance;
    public float maximunShootingDistance;
    public float shootingTime;
    public float bulletSpeed;


    private EnemyGenericController egc;
    private bool movement = true;

    private float shootingTimer;

    public GameObject bullet;
    private GameObject playerReference;
    private Vector3 direction, distance;
    private bool detected;

    [SerializeField] Transform shootingPoint;

    [Tooltip("Rozamiento del knockback del jugador")] [SerializeField] float kFriction;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.volume = 0.2f;
        enemyController = GetComponent<EnemyGenericController>();

        playerReference = GameObject.Find("Player");
        egc = this.GetComponent<EnemyGenericController>();
    }


    // Update is called once per frame
    void Update()
    {
        this.movement = egc.movement;

        shootingTimer += Time.deltaTime;

        if (playerReference != null)
            distance = playerReference.transform.position - transform.position;
        direction = Vector3.Normalize(distance);
        //Debug.Log("X: " + direction.x + " Y: " + direction.y + " Z: " + direction.z);

        if (shootingTimer >= shootingTime && detected && movement)
        {
            if ((distance.magnitude >0 && distance.magnitude <= maximunShootingDistance) || (distance.magnitude <= 0 && distance.magnitude >= -maximunShootingDistance))
            {
                       
                GameObject bulletIn = Instantiate(bullet, shootingPoint.position, Quaternion.identity);

                int random = UnityEngine.Random.Range(0, 4);
                audioSource.PlayOneShot(shootSounds[random]);

                // bulletIn.transform.LookAt(playerReference.transform);
                float angle = Mathf.Atan2(distance.y, distance.x) * Mathf.Rad2Deg;
                bulletIn.transform.rotation = Quaternion.AngleAxis(angle-90, Vector3.forward);
                bulletIn.GetComponent<Rigidbody2D>().velocity = Vector3.Normalize(playerReference.transform.position-transform.position) * bulletSpeed;
                bulletIn.GetComponent<bulletBehaviour>().shootedByIA = true;
                shootingTimer = 0;
            }
        }

        if (distance.magnitude <= 0 && distance.magnitude <= -maximunDistance-1 && distance.magnitude >= -detectDistance && detected && movement) //Si el jugador está en el rango de vision del enemigo, el enemigo le persigue
        {
            Debug.Log("Cambio de velocidad");
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        else if (distance.magnitude > 0 && distance.magnitude >= maximunDistance+1 && distance.magnitude <= detectDistance && detected && movement) //Si el jugador está en el rango de vision del enemigo,
        {
            //Debug.Log("Cambio de velocidad");
            GetComponent<Rigidbody2D>().velocity = direction * speed;
        }
        else if(distance.magnitude > 0 && distance.magnitude <= maximunDistance && detected && movement) //Si el jugador está en el rango de visión del enemigo, y demasiado cerca, el enemigo se aleja.
        {
            Debug.Log("Cambio de velocidad");
            GetComponent<Rigidbody2D>().velocity = -direction * speed;
        }
        else if (distance.magnitude < 0 && distance.magnitude >= maximunDistance && detected && movement) //Si el jugador está en el rango de visión del enemigo, y demasiado cerca, el enemigo se aleja.
        {
            Debug.Log("Cambio de velocidad");
            GetComponent<Rigidbody2D>().velocity = -direction * speed;
        }
        else if(movement) //Si no se detecta al jugador, el enemigo se queda quieto.
        {
            //Debug.Log("Quieto");
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0);
        }

        if(distance.x >= 0 && distance.magnitude <= detectDistance && detected)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        if (distance.x < 0 && distance.magnitude <= detectDistance && detected)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
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
}
