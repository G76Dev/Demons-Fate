using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float offsetSpeed;
    [SerializeField] Vector3 offset;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        target.position = new Vector3Int(0,0,0);
        target.gameObject.GetComponent<HPBehaviour>().recalculateHP();
    }
    void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, offsetSpeed);
    }
}
