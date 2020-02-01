using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBehaviour : MonoBehaviour
{
    [SerializeField] AudioClip[] impactAudios;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip death;

    public Sprite heart;
    public Sprite halfheart;

    private Transform targetPoint;

    public GameObject imagen;

    private List<GameObject> hearts;

    bool firstTime=false;

    public int maxHP;
    public int actualHP;
    public int distanciaEntreCorazones;

    [SerializeField] GameObject HitFX;
    [SerializeField] float invulenrabilityTime;
    Color originalTint;
    SpriteRenderer sr;

    [HideInInspector] public bool vulnerable = true;

    // Start is called before the first frame update
    void Start()
    {
        targetPoint = GameObject.Find("TargetPoint1").transform;
        sr = GetComponent<SpriteRenderer>();
        originalTint = sr.color;
        hearts = new List<GameObject>();

        hearts.Clear();

        int aux = actualHP / 2;

        for (int i = 0; i < aux; i++)
        {
            hearts.Add(Instantiate(imagen, targetPoint.position + Vector3.right*distanciaEntreCorazones*i, Quaternion.identity, GameObject.Find("Canvas").transform));
            hearts[i].GetComponent<RectTransform>().localPosition.Set(targetPoint.position.x + i * distanciaEntreCorazones, targetPoint.position.y, targetPoint.position.z);
            hearts[i].GetComponent<Image>().sprite = heart;
        }
        if (actualHP % 2 == 1)
        {
            hearts.Add(Instantiate(imagen, targetPoint.position + Vector3.right*distanciaEntreCorazones*aux, Quaternion.identity, GameObject.Find("Canvas").transform));
            hearts[aux].GetComponent<RectTransform>().localPosition.Set(targetPoint.position.x + aux * distanciaEntreCorazones, targetPoint.position.y, targetPoint.position.z);
            hearts[aux].GetComponent<Image>().sprite = halfheart;
        }
    }

    public void recalculateHP()
    {
        targetPoint = GameObject.Find("TargetPoint1").transform;
        for (int i = 0; i < hearts.Count; i++)
        {
            Destroy(hearts[i]);
        }
        hearts.Clear();

        int aux = actualHP / 2;

        for (int i = 0; i < aux; i++)
        {
            hearts.Add(Instantiate(imagen, targetPoint.position + Vector3.right * distanciaEntreCorazones * i, Quaternion.identity, GameObject.Find("Canvas").transform));
            hearts[i].GetComponent<RectTransform>().localPosition.Set(targetPoint.position.x + i * distanciaEntreCorazones, targetPoint.position.y, targetPoint.position.z);
            hearts[i].GetComponent<Image>().sprite = heart;
        }
        if (actualHP % 2 == 1)
        {
            hearts.Add(Instantiate(imagen, targetPoint.position + Vector3.right * distanciaEntreCorazones * aux, Quaternion.identity, GameObject.Find("Canvas").transform));
            hearts[aux].GetComponent<RectTransform>().localPosition.Set(targetPoint.position.x + aux * distanciaEntreCorazones, targetPoint.position.y, targetPoint.position.z);
            hearts[aux].GetComponent<Image>().sprite = halfheart;
        }
    }

    public void damage(int amount)
    {
        StartCoroutine(InvulnerableTime());
        sr.color = new Color(originalTint.r, originalTint.g, originalTint.b, 0.25f);
        StartCoroutine(blinking2());

        actualHP -= amount;
        recalculateHP();
        Destroy(Instantiate(HitFX, this.transform.position, Quaternion.identity), 2);
    }
    public void damage(int amount,float force, GameObject inflictor)
    {

        if (vulnerable)
        {
            int random = UnityEngine.Random.Range(0, 4);
            audioSource.PlayOneShot(impactAudios[random]);
            damage(amount);
            GetComponent<PlayerController>().knockBackPlayer(transform.position - inflictor.transform.position, force);
        }
    }
    IEnumerator InvulnerableTime()
    {
        vulnerable = false;
        yield return new WaitForSeconds(invulenrabilityTime);
        vulnerable = true;
    }
    IEnumerator blinking1()
    {
        sr.color = new Color(originalTint.r, originalTint.g, originalTint.b, 0.25f);
        yield return new WaitForSeconds(0.1f);
        if (vulnerable)
        {
            sr.color = new Color(originalTint.r, originalTint.g, originalTint.b, 1);
        }
        else{
            StartCoroutine(blinking2());
        }
    }

    IEnumerator blinking2()
    {
        sr.color = new Color(originalTint.r, originalTint.g, originalTint.b, 1);
        yield return new WaitForSeconds(0.1f);
        if (vulnerable)
        {
            sr.color = new Color(originalTint.r, originalTint.g, originalTint.b, 1);
        }
        else
        {
            StartCoroutine(blinking1());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (actualHP <= 0 && !firstTime)
        {
            die();
            firstTime = true;
        }
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("dmgObstacle"))
        {
            damage(1, 0.4f, collision.gameObject);
        }
    }*/

    private void die()
    {
        audioSource.PlayOneShot(death);
        //programar lo que sea que ocurre cuando se muere. Por ejemplo, se podría poner el timescale a 0, y mostrar por pantalla un texto de derrota, 
        //y un boton de volver a jugar, junto a otro de volver al menú principal
        Debug.Log("Muerte");
        Time.timeScale = 0;
        GameObject.Find("Death background").GetComponent<Animator>().Play("HSIn");
        Destroy(gameObject,3);
    }
}
