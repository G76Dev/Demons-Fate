using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnerBehaviour : MonoBehaviour
{
    [SerializeField] GameObject[] bosses;

    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, bosses.Length);
        Instantiate(bosses[random], transform.position, transform.rotation);
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
