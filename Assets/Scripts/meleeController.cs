using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeController : MonoBehaviour
{
    [SerializeField] private Transform slashPoint;
    [SerializeField] private GameObject weaponPrefab;
    [SerializeField] private float offset;
    private bool canAttack;
    [SerializeField] private float slashCooldown = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            Slash();
        }
    }

    private void Slash()
    {
        if (canAttack)
        {
            GameObject slash = Instantiate(weaponPrefab, slashPoint.position, slashPoint.rotation, this.transform);
            Rigidbody2D rb2d = slash.GetComponent<Rigidbody2D>();
            canAttack = false;
            StartCoroutine(cooldown());
        }
        else
        {
            //do nothing
        }

    }

    IEnumerator cooldown()
    {
        yield return new WaitForSeconds(slashCooldown);
        if (!canAttack)
            canAttack = true;
    }
}
