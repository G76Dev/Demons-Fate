using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    [SerializeField] GameObject hitFX;
    public bool shootedByIA = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!shootedByIA || collision.gameObject.tag != "ShootingEnemy")
        {
            GameObject FX = Instantiate(hitFX, transform.position, Quaternion.identity);
            Destroy(FX, 2f);
            Destroy(gameObject);
        }   
    }

}
