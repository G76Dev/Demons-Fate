using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private int maxHealth = 100;
    private int health = 100;
    [SerializeField] Transform bar;
    [SerializeField] GameObject floatingText;

    void initHealth(int mH)
    {
        maxHealth = Mathf.Max(mH, 0);
        health = maxHealth;
        transform.localScale = new Vector3(maxHealth / 100, transform.localScale.y, transform.localScale.z);
    }

    void setHealth(int h)
    {
        health = Mathf.Clamp(h, 0, maxHealth);
        adjustBar(health, maxHealth);
    }

    void changeHealth(int h)
    {
        setHealth(health + h);
        GameObject hp = Instantiate(floatingText, transform.position, transform.rotation, transform);
        hp.GetComponent<TextMesh>().text = h.ToString();
    }

    void adjustBar(int h, int mH)
    {
        bar.localScale = new Vector3((float)h / (float)mH, transform.localScale.y, transform.localScale.z);
    }

    private void Start()
    {
        StartCoroutine(test());
    }

    IEnumerator test()
    {
        yield return new WaitForSeconds(2);
        changeHealth(-20);
    }
}
