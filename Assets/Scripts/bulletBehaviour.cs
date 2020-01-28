using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletBehaviour : MonoBehaviour
{
    [SerializeField] GameObject hitFX;

    private void OnCollisionEnter2D(Collision2D collision)
    {

        GameObject FX = Instantiate(hitFX, transform.position, Quaternion.identity);
        Destroy(FX, 2f);
        Destroy(gameObject);

    }

}
