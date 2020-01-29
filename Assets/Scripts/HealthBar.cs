using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public int health = 100;
    private int currentHealth;
    [SerializeField] Transform bar;
    [SerializeField] GameObject floatingText;

    private void Start()
    {
        currentHealth = health;
        //transform.localScale = new Vector3(health / 100, transform.localScale.y, transform.localScale.z);
    }

    void initHealth(int mH)
    {
        health = Mathf.Max(mH, 0);
        currentHealth = health;
        //transform.localScale = new Vector3(health / 100, transform.localScale.y, transform.localScale.z);
    }

    public int getCurrentHealth()
    {
        return currentHealth;
    }

    void setHealth(int h)
    {
        currentHealth = Mathf.Clamp(h, 0, health);
        adjustBar(currentHealth, health);
    }

    public void changeHealth(int h)
    {
        setHealth(currentHealth + h);
        var hp = Instantiate(floatingText, transform.position, transform.rotation, transform);
        hp.GetComponent<TextMesh>().text = h.ToString();
    }

    void adjustBar(int h, int mH)
    {
        bar.localScale = new Vector3((float)h / (float)mH, transform.localScale.y, transform.localScale.z);
    }

    /*private void Start()
    {
        StartCoroutine(test());
    }

    IEnumerator test()
    {
        yield return new WaitForSeconds(1);
        changeHealth(-20);
        StartCoroutine(test());
    }*/
}
