using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelBehaviour : MonoBehaviour
{
    //Estas 2 listas se deben llenar cada una con las habilidades que se quieran en el juego. Cada lista debe tener solo habilidades del tipo correspondiente para garantizar que siempre aparece una opcion de cada una.
    public List<GameObject> sacredHabilities;
    public List<GameObject> profaneHabilities;

    public GameObject HSCanvas;

    public GameObject hability1;
    public GameObject hability2;
    public GameObject hability3;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        DontDestroyOnLoad(this);

        if (Input.GetKeyDown(KeyCode.P))
        {
            habilitiesSelector();
        }   
    }

    public void habilitiesSelector()
    {
        //Se configura el apartado visual para que aparezcan botones con habilidades aleatorias.

        Time.timeScale = 0;
        int index1 = Random.Range(0, sacredHabilities.Count);
        int index2 = Random.Range(0, profaneHabilities.Count);

        hability1.GetComponent<Text>().text = sacredHabilities[index1].GetComponent<Text>().text;
        hability1.GetComponentInChildren<Image>().sprite = sacredHabilities[index1].GetComponentInChildren<Image>().sprite;

        hability2.GetComponent<Text>().text = profaneHabilities[index2].GetComponent<Text>().text;
        hability2.GetComponentInChildren<Image>().sprite = profaneHabilities[index2].GetComponentInChildren<Image>().sprite;

        sacredHabilities.RemoveAt(index1);
        profaneHabilities.RemoveAt(index2);


        HSCanvas.GetComponent<Animator>().Play("HSIn");
        Debug.Log("Dale carla");

    } 

}
