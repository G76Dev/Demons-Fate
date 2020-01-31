using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBehaviour : MonoBehaviour
{
    public Sprite heart;
    public Sprite halfheart;

    public Transform targetPoint;

    public GameObject imagen;

    private List<GameObject> hearts;

    public int maxHP;
    public int actualHP;
    public int distanciaEntreCorazones;

    // Start is called before the first frame update
    void Start()
    {
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
        actualHP -= amount;
        recalculateHP();
    }
    public void damage(int amount,float force, GameObject inflictor)
    {
        damage(amount);
        GetComponent<PlayerController>().knockBackPlayer(transform.position - inflictor.transform.position, force);
    }

    // Update is called once per frame
    void Update()
    {
        if (actualHP <= 0)
        {
            die();
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
        //programar lo que sea que ocurre cuando se muere. Por ejemplo, se podría poner el timescale a 0, y mostrar por pantalla un texto de derrota, 
        //y un boton de volver a jugar, junto a otro de volver al menú principal
        Debug.Log("Muerte");
        Time.timeScale = 0;
        GameObject.Find("Death background").GetComponent<Animator>().Play("HSIn");

    }
}
