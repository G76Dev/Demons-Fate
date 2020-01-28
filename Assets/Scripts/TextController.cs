using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField] float destroyTime = 0.4f;
    [SerializeField] float offsetY;
    [SerializeField] float randomOffsetX;

    void Start()
    {
        Destroy(gameObject, destroyTime);

        float offsetX = Random.Range(-randomOffsetX, randomOffsetX);
        transform.localPosition += new Vector3(offsetX, offsetY, 0);
    }
}
