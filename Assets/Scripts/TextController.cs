using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour
{
    [SerializeField] float destroyTime = 0.4f;
    [SerializeField] Vector3 offset;

    void Start()
    {
        Destroy(gameObject, destroyTime);

        transform.localPosition += offset;
    }
}
