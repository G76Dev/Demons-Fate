using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meleeController : MonoBehaviour
{
    [Tooltip("Punto invisible donde se instancia el ataque")] [SerializeField] private Transform slashPoint;
    [Tooltip("Prefab del arma, que contiene sus atributos")] public GameObject weaponPrefab;
    private bool canAttack;
    private bool slashDirection;
    [SerializeField] private float slashCooldown = 0.2f;
    private float slashDuration;

    //EVENTOS
    public delegate void Melee(); //Delegate creado expresamente para eventos de combate cuerpo a cuerpo
    public static event Melee PlayerAttack; //Evento que siempre se dispara cuando el jugador ataca

    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
        slashDirection = true;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Slash();
        }
    }

    public float getSlashDuration()
    {
        return slashDuration;
    }

    private void Slash()
    {
        if (canAttack)
        {
            if (slashDirection)
            { //si el booleano es true, ataca en una direccion
                GameObject slash = Instantiate(weaponPrefab, slashPoint.position, slashPoint.rotation, this.transform);
                slashDuration = slash.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length;
                slashDirection = false; //y pone el booleano a false para que el siguiente ataque se haga desde la otra direccion
                PlayerAttack(); //finalmente se llama al evento correspondiente para que el resto de entidades reaccione como es debido.
            } else
            {   //y si resulta ser false, ataca en el otro sentido.
                GameObject slash = Instantiate(weaponPrefab, slashPoint.position, slashPoint.rotation, this.transform);
                Vector3 theScale = slash.transform.localScale; 
                theScale.x *= -1; //Esto hará que cambie el sentido del ataque
                slash.transform.localScale = theScale;
                slashDirection = true; //y pone el booleano a true para que el siguiente ataque se haga desde la otra direccion
                PlayerAttack(); 
            }
            canAttack = false;
            StartCoroutine(cooldown()); //No se podrá volver a atacar hasta que se acabe el cooldown.
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
