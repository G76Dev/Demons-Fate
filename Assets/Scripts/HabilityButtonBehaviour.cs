using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilityButtonBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onPointerIn()
    {
        transform.localScale = new Vector3(transform.localScale.x * 1.3f, transform.localScale.y * 1.3f, transform.localScale.z);
    }

    public void onPointerOut()
    {
        transform.localScale = new Vector3(transform.localScale.x / 1.3f, transform.localScale.y / 1.3f, transform.localScale.z);
    }
}
