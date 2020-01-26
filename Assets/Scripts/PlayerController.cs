using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    [Header("Player Variables")]
    [SerializeField] float speed;
    [SerializeField] float weaponDistance;
    [SerializeField] Transform weapon;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float mouseVectorX = (Input.mousePosition.x - Screen.width / 2) - transform.position.x;
        float mouseVectorY = (Input.mousePosition.y - Screen.height / 2) - transform.position.y;
        Vector3 mouseVector = new Vector3(mouseVectorX, mouseVectorY, 0);
        mouseVector.Normalize();

        weapon.position = transform.position + mouseVector * weaponDistance;
        if(mouseVectorY >= 0)
            weapon.rotation = Quaternion.Euler(0,0, Vector3.Angle(mouseVector, Vector3.right) - 90);
        else
            weapon.rotation = Quaternion.Euler(0, 0, -Vector3.Angle(mouseVector, Vector3.right) - 90);

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speed;
    }
}
